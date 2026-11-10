using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Reporting.Application.Clients;
using Reporting.Infrastructure.Persistence;
using Reporting.Infrastructure.Services;

namespace Reporting.Infrastructure;

public static class DependencyInjection
{
    public static IServiceCollection AddInfrastructure(
        this IServiceCollection services,
        IConfiguration configuration)
    {
        var connectionString = configuration.GetConnectionString("ReportingDb")
            ?? throw new InvalidOperationException(
                "Connection string 'ReportingDb' was not found in appsettings.");

        services.AddDbContext<ReportingDbContext>(options =>
            options.UseSqlServer(connectionString));

        services.AddDbContext<AppIdentityDbContext>(options =>
            options.UseSqlServer(connectionString));

        services.AddHealthChecks()
            .AddDbContextCheck<ReportingDbContext>("database");

        services.AddScoped<IClientService, ClientService>();

        return services;
    }
}