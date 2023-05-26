using HealthChecks.UI.Client;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Diagnostics.HealthChecks;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Diagnostics.HealthChecks;

namespace Wego.Infrastructure.HealthCheck
{
    public static class HealthCheckExtension
    {
        public static IHealthChecksBuilder AddCustomHealthCheck(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddHealthChecksUI(setupSettings: settings =>
            {
                settings
                    .AddHealthCheckEndpoint("All", "/hc")
                    .DisableDatabaseMigrations()
                    .SetEvaluationTimeInSeconds(300)
                    .SetMinimumSecondsBetweenFailureNotifications(300);
            }).AddInMemoryStorage();

            return services.AddHealthChecks()
                .AddSqlServer(configuration.GetConnectionString("PortoDb"),
                    name: "Porto db",
                    failureStatus: HealthStatus.Degraded,                   
                    healthQuery: "SELECT TOP (1) * FROM dbo.OffersSearch",
                    tags: new string[] { "db", "sqlServer" })

                .AddSqlServer(configuration.GetConnectionString("Inet"),
                    name: "Inet db",
                    failureStatus: HealthStatus.Degraded,                 
                    healthQuery: "SELECT TOP (1) * FROM dbo.Users",
                    tags: new string[] { "db", "sqlServer" })

            .AddCheck<ApiHealthCheck>("ApiHealth");

        }

        public static IApplicationBuilder UseCustomHealthCheck(this WebApplication app)
        {
            app.MapHealthChecks("/hc/Cors", new HealthCheckOptions
            {
                ResponseWriter = UIResponseWriter.WriteHealthCheckUIResponse
            }).RequireCors("Open");

            app.MapHealthChecks("/hc/secure", new HealthCheckOptions
            {
                ResponseWriter = UIResponseWriter.WriteHealthCheckUIResponse
            }).RequireAuthorization();

            app.MapHealthChecks("/hc", new HealthCheckOptions
            {
                ResponseWriter = UIResponseWriter.WriteHealthCheckUIResponse
            });
            app.UseRouting();
            app.MapHealthChecksUI(config =>
            {
                config.UIPath = "/health";
                config.ApiPath = "/health-api";
            });
            return app;
        }
    }
}
