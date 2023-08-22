using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;
using Microsoft.Extensions.Options;

using System.Configuration;

using Wego.Application.Contracts.Context;
using Wego.Application.Contracts.Infrastructure;
using Wego.Application.Contracts.Infrastructure.Captcha;
using Wego.Application.Models.Common;
using Wego.Infrastructure.Context;
using Wego.Infrastructure.Log;

namespace Wego.Persistence;

public static class InfrastructureServiceRegistration
{
    public static IServiceCollection AddInfrastructureServices(this IServiceCollection services, IConfiguration configuration)
    {
        services.Configure<WebSettings>(configuration.GetSection("WEBENV"));


        services.AddScoped<ICacheManager, CacheManager>();
        services.AddScoped<ICurrentContext, CurrentContext>();
        services.AddEasyCaching(options => options.UseInMemory("default"));

        services.TryAddSingleton<IWebSettings>(sp => sp.GetRequiredService<IOptions<WebSettings>>().Value);
        return services;
    }

    public static IServiceCollection AddGoogleCaptchaServices(this IServiceCollection services, IConfiguration configuration)
    {
        services.Configure<GoogleCapthaConfig>(configuration.GetSection("GoogleRecaptcha"));

        services.TryAddSingleton<IGoogleCapthaConfig>(sp => sp.GetRequiredService<IOptions<GoogleCapthaConfig>>().Value);
        return services;
    }
}