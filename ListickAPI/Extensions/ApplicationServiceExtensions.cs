using System;
using ListickAPI.Data;
using ListickAPI.Services;
using ListickAPI.Services.IServices;
using Microsoft.EntityFrameworkCore;

namespace ListickAPI.Extensions;

public static class ApplicationServiceExtensions
{
    public static IServiceCollection AddApplicationServices(
        this IServiceCollection services,
        IConfiguration config
    )
    {
        services.AddControllers();
        services.AddDbContext<DataContext>(options =>
            options.UseSqlServer(config.GetConnectionString("ListickaConnection"))
        );

        services.AddCors();
        services.AddScoped<ITokenService, TokenService>();
        return services;
    }
}
