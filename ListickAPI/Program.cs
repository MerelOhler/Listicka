using ListickAPI.Data;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
builder.Services.AddDbContext<DataContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("ListickaConnection")));

builder.Services.AddCors();
var app = builder.Build();

// Configure the HTTP request pipeline.
app.UseCors(builder =>
    builder
        .AllowAnyMethod()
        .AllowAnyHeader()
        .WithOrigins("http://localhost:4200", "https://localhost:4200")
);
app.MapControllers();

app.Run();
