using System;
using ListickAPI.Entities;
using Microsoft.EntityFrameworkCore;

namespace ListickAPI.Data;

public class DataContext(DbContextOptions options) : DbContext(options)
{
    public DbSet<LoginUser> LoginUser { get; set; }
}
