using MediatR;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

using System.Reflection;
using Wego.Application.Behaviours;
using Wego.Application.Contracts;
using Wego.Application.Contracts.Common;
using Wego.Application.Features;
using Wego.Application.Features.Common;
using Wego.Application.Models.Mail;

namespace Wego.Application;

public static class ApplicationServiceRegistration
{
    public static IServiceCollection AddApplicationServices(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddMediatR(cfg => cfg.RegisterServicesFromAssembly(Assembly.GetExecutingAssembly()));
        services.AddTransient(typeof(IPipelineBehavior<,>), typeof(UnhandledExceptionBehaviour<,>));
        services.AddTransient<ILoggedInUserService, LoggedInUserService>();
        services.AddScoped<IEmailSender, EmailSender>();
        services.Configure<EmailSettings>(configuration.GetSection(nameof(EmailSettings)));
        return services;
    }
}