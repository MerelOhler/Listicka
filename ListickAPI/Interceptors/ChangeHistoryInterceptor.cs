using System;
using ListickAPI.Entities;
using ListickAPI.Entities.ChangeHistory;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using Microsoft.EntityFrameworkCore.Diagnostics;

namespace ListickAPI.Interceptors;

public sealed class ChangeHistoryInterceptor : SaveChangesInterceptor
{
    public override ValueTask<InterceptionResult<int>> SavingChangesAsync(
        DbContextEventData eventData,
        InterceptionResult<int> result,
        CancellationToken cancellationToken = default
    )
    {
        DbContext? dbContext = eventData.Context;
        if (dbContext is null)
        {
            return base.SavingChangesAsync(eventData, result, cancellationToken);
        }

        this.getToDoChangeHistories(dbContext);

        return base.SavingChangesAsync(eventData, result, cancellationToken);
    }

    private void getToDoChangeHistories(DbContext dbContext)
    {
        var toDoEntries = dbContext.ChangeTracker.Entries<ToDo>().ToList();
        if (toDoEntries.Count == 0)
        {
            return;
        }

        foreach (var entry in toDoEntries)
        {
            List<ToDoChangeHistory> changeHistories = [];

            if (entry.State == EntityState.Added)
            {
                foreach (var property in entry.CurrentValues.Properties)
                {
                    if (
                        property.Name == "ToDoId"
                        || property.Name == "DateCreated"
                        || property.Name == "DateModified"
                        || property.Name == "DateDeleted"
                        || property.Name == "ModifiedByLoginUserId"
                        || property.Name == "DeletedByLoginUserId"
                        || property.Name == "CreatedByLoginUserId"
                    )
                    {
                        continue;
                    }
                    if (entry.CurrentValues[property] == null)
                    {
                        continue;
                    }
                    changeHistories.Add(
                        new ToDoChangeHistory
                        {
                            EventType = "CREATED",
                            ColumnName = property.Name,
                            OriginalValue = null,
                            NewValue = entry.CurrentValues[property]?.ToString() ?? string.Empty,
                            ModifiedBy = entry.Entity.CreatedBy,
                            DateModified = DateTime.UtcNow,
                            ToDo = entry.Entity,
                        }
                    );
                }
            }
            else if (entry.State == EntityState.Modified && entry.Entity.DateDeleted == null)
            {
                foreach (var property in entry.OriginalValues.Properties)
                {
                    var originalValue = entry.OriginalValues[property];
                    var currentValue = entry.CurrentValues[property];
                    if (originalValue != currentValue)
                    {
                        changeHistories.Add(
                            new ToDoChangeHistory
                            {
                                EventType = "MODIFIED",
                                ColumnName = property.Name,
                                OriginalValue = originalValue?.ToString(),
                                NewValue = currentValue?.ToString(),
                                ModifiedBy = entry.Entity.ModifiedBy ?? entry.Entity.CreatedBy,
                                DateModified = DateTime.UtcNow,
                                ToDo = entry.Entity,
                            }
                        );
                    }
                }
            }
            dbContext.AddRange(changeHistories);
        }
    }
}
