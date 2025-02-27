using System;
using ListickAPI.Entities;
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
}
