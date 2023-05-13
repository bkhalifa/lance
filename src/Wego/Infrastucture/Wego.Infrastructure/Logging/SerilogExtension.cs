using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Serilog;


namespace Wego.Infrastructure.Logging
{
    public static class SerilogExtension
    {
        public static IHostBuilder UseLogging(this IHostBuilder host, IConfiguration configuration)
        {
            host.UseSerilog((_, serviceProvider, loggerConfiguration) => loggerConfiguration
                    .ReadFrom.Configuration(configuration)
                    .Enrich.FromLogContext()
                    .Enrich.With(new LogIpEnricher(serviceProvider.GetRequiredService<IHttpContextAccessor>()),
                                 new UserNameEnricher(serviceProvider.GetRequiredService<IHttpContextAccessor>()),
                                 new TraceIdEnricher(serviceProvider.GetRequiredService<IHttpContextAccessor>()))
                    .Enrich.WithProperty("Application", "WebApi")
                    .Enrich.WithProperty("Environment", Environment.GetEnvironmentVariable("ASPNETCORE_ENVIRONMENT") ?? string.Empty));

            return host;
        }
    }
}
