using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Wego.Application.Contracts.Infrastructure;
using Wego.Infrastructure.Log;

namespace Wego.Persistence;

public static class InfrastructureServiceRegistration
{
    public static IServiceCollection AddInfrastructureServices(this IServiceCollection services)
    {
        services.AddScoped<ICacheManager, CacheManager>();
        //configuration
        services.AddEasyCaching(options => options.UseInMemory("default"));
        return services;
    }
}