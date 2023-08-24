using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;
using Microsoft.Extensions.Options;

using Wego.Application.Contracts.Captcha;
using Wego.Application.Response;
using Wego.Infrastructure.Captcha;

namespace Wego.Infrastructure.Extensions;

public static class GoogleCaptchaServiceRegistration
{

    public static IServiceCollection AddGoogleServices(this IServiceCollection services, IConfiguration configuration)
    {
        services.Configure<GoogleCapthaConfig>(configuration.GetSection("GoogleRecaptcha"));
        services.TryAddSingleton<IGoogleCapthaConfig>(sp => sp.GetRequiredService<IOptions<GoogleCapthaConfig>>().Value);

        services.AddScoped<IGoogleCapthaService, GoogleCapthaService>();
        return services;
    }

}
