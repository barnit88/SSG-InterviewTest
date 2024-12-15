using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;
using SSG.Application.Common.Interface;
using SSG.Infrastructure.Data;
using SSG.Infrastructure.Options;

namespace SSG.Infrastructure;

public static class DependencyInjection
{
    public static IServiceCollection AddInfrastructure(this IServiceCollection services)
    {
        services.ConfigureOptions<DatabaseOptionSetup>();
        services.AddDbContext<ApplicationDbContext>((serviceProvider, options) =>
        {
            var databaseOptions = serviceProvider.GetService<IOptionsMonitor<DatabaseOption>>().CurrentValue;
            options.UseSqlServer(databaseOptions.ConnectionString, options =>
            {
                options.EnableRetryOnFailure(databaseOptions.EnableRetryOnFailure);
                options.CommandTimeout(databaseOptions.CommandTimeout);
            });
            options.EnableDetailedErrors(databaseOptions.EnableDetailedErrors);
            options.EnableSensitiveDataLogging(databaseOptions.EnableSensitiveDataLogging);
        });
        using var serviceProvider = services.BuildServiceProvider();
        var dbContext = serviceProvider.GetRequiredService<ApplicationDbContext>();
        dbContext.Database.Migrate();

        services.AddScoped<IApplicationDbContext, ApplicationDbContext>();
        return services;
    }
}