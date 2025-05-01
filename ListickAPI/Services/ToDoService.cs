using System;
using Humanizer;
using ListickAPI.Data;
using ListickAPI.DataObjects;
using ListickAPI.Entities;
using ListickAPI.Services.IServices;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace ListickAPI.Services;

public class ToDoService(DataContext context) : IToDoService
{
    public async Task<ToDoDto> Create(ToDoDto toDoDto)
    {
        var user = await context.LoginUser.FirstOrDefaultAsync(u =>
            u.LoginUserId == toDoDto.LoginUserId
        );
        if (user == null)
        {
            throw new Exception("User not found");
        }
        var toDo = new ToDo
        {
            ToDoName = toDoDto.ToDoName,
            Description = toDoDto.Description,
            StartDate = toDoDto.StartDate,
            EndDate = toDoDto.EndDate,
            TimeNeeded = toDoDto.TimeNeeded,
            ColorHexCode = toDoDto.ColorHexCode,
            Notes = toDoDto.Notes,
            PercentComplete = toDoDto.PercentComplete,
            CreatedBy = user,
            DateCreated = DateTime.UtcNow,
        };
        context.ToDo.Add(toDo);
        await context.SaveChangesAsync();
        toDoDto.ToDoId = toDo.ToDoId;
        return toDoDto;
    }

    public async Task<ToDoDto?> GetById(int id)
    {
        var todo = await context
            .ToDo.Include(t => t.CreatedBy)
            .Include(t => t.Status)
            .FirstOrDefaultAsync(t => t.ToDoId == id);
        if (todo == null)
        {
            return null;
        }
        return ToDoEntityToToDoDto(todo);
    }

    public async Task<List<ToDoDto>> GetByUserId(
        int userId,
        int page = 1,
        int pageSize = 10,
        string? search = null,
        bool? completed = null
    )
    {
        var query = context.ToDo.Where(t => t.CreatedBy.LoginUserId == userId);
        if (search != null)
        {
            query = query.Where(t => t.ToDoName.Contains(search));
        }
        if (completed != null)
        {
            query = query.Where(t => t.Status != null && t.Status.IsDone == (completed == true));
        }
        var toDos = await query
            .OrderBy(t => t.ToDoName)
            .Skip((page - 1) * pageSize)
            .Take(pageSize)
            .Include(t => t.CreatedBy)
            .Include(t => t.Status)
            .ToListAsync();
        return [.. toDos.Select(ToDoEntityToToDoDto)];
    }

    private ToDoDto ToDoEntityToToDoDto(ToDo toDo)
    {
        return new ToDoDto
        {
            ToDoId = toDo.ToDoId,
            ToDoName = toDo.ToDoName,
            Description = toDo.Description,
            StartDate = toDo.StartDate,
            EndDate = toDo.EndDate,
            TimeNeeded = toDo.TimeNeeded,
            ColorHexCode = toDo.ColorHexCode,
            Notes = toDo.Notes,
            PercentComplete = toDo.PercentComplete,
            LoginUserId = toDo.CreatedBy.LoginUserId,
            CreatedBy = new UserDto
            {
                LoginUserId = toDo.CreatedBy.LoginUserId,
                UserName = toDo.CreatedBy.UserName,
                Token = null,
                FirstName = toDo.CreatedBy.FirstName,
                LastName = toDo.CreatedBy.LastName,
                Email = toDo.CreatedBy.Email,
                Language = toDo.CreatedBy.Language,
            },
            DateCreated = toDo.DateCreated,
        };
    }
}
