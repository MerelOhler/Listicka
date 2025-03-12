using System;
using ListickAPI.Data;
using ListickAPI.Interceptors;
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

        services.AddSingleton<ChangeHistoryInterceptor>();
        services.AddDbContext<DataContext>(
            (sp, options) =>
            {
                var changeHistoryInterceptor = sp.GetService<ChangeHistoryInterceptor>();
                options
                    .UseSqlServer(config.GetConnectionString("ListickaConnection"))
                    .AddInterceptors(
                        changeHistoryInterceptor
                            ?? throw new ArgumentNullException(nameof(changeHistoryInterceptor))
                    );
            }
        );

        services.AddCors();
        services.AddScoped<ITokenService, TokenService>();
        return services;
    }
}
