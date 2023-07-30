using Serilog;


namespace Wego.HubApi.Extensions
{
    public static class SerilogExtension
    {
        public static IHostBuilder UseLogging(this IHostBuilder host, IConfiguration configuration, string applicationName)
        {
            host.UseSerilog((_, serviceProvider, loggerConfiguration) => loggerConfiguration
                    .ReadFrom.Configuration(configuration)
                    .Enrich.FromLogContext()
                    .Enrich.With(new LogIpEnricher(serviceProvider.GetRequiredService<IHttpContextAccessor>()),
                                 new UserNameEnricher(serviceProvider.GetRequiredService<IHttpContextAccessor>()),
                                 new TraceIdEnricher(serviceProvider.GetRequiredService<IHttpContextAccessor>()))
                    .Enrich.WithProperty("Application", applicationName)
                    .Enrich.WithProperty("Environment", Environment.GetEnvironmentVariable("ASPNETCORE_ENVIRONMENT") ?? string.Empty));

            return host;
        }
    }
}
