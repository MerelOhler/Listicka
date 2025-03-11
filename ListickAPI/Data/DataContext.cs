using ListickAPI.Entities;
using ListickAPI.Entities.ChangeHistory;
using ListickAPI.Entities.LookupEntities;
using Microsoft.EntityFrameworkCore;

namespace ListickAPI.Data;

public class DataContext(DbContextOptions options) : DbContext(options)
{
    public DbSet<LoginUser> LoginUser { get; set; }
    public DbSet<Cadence> Cadence { get; set; }
    public DbSet<WeekDays> WeekDays { get; set; }
    public DbSet<Status> Status { get; set; }
    public DbSet<Priority> Priority { get; set; }
    public DbSet<Project> Project { get; set; }
    public DbSet<ToDo> ToDo { get; set; }
    public DbSet<ToDoRecurrance> ToDoRecurrance { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder
            .Entity<ToDoRecurrance>()
            .HasMany(p => p.WeekDays)
            .WithMany(r => r.ToDoRecurance)
            .UsingEntity<Dictionary<string, object>>(
                "ToDoRecurranceWeekDays",
                r => r.HasOne<WeekDays>().WithMany().HasForeignKey("WeekDayId"),
                l => l.HasOne<ToDoRecurrance>().WithMany().HasForeignKey("ToDoRecurranceId")
            );
    }
}
