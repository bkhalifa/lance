using Hellang.Middleware.ProblemDetails;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Options;
using System.Net;
using Wego.Application.Contracts.Common;
using Wego.Application.Exceptions;
using Wego.Application.Models.Mail;

namespace Wego.Application.Extensions
{
    public static class ProblemDetailExtension
    {
        public static IServiceCollection AddCustomProblemDetails(this IServiceCollection services, IWebHostEnvironment environment)
        {
            services.AddProblemDetails(setup =>
            {
                setup.IncludeExceptionDetails = (_, _) => true;
                setup.ShouldLogUnhandledException = (_, _, _) => false;
                setup.OnBeforeWriteDetails = async (context, pr) =>
                {
                    if (environment.IsProduction() && pr.Status >= 500)
                    {
                        var mailSender = context.RequestServices.GetRequiredService<IEmailSender>();
                        var mailSettings = context.RequestServices.GetRequiredService<IOptions<EmailSettings>>().Value;
                        await mailSender.SendMailAsync(new Email(mailSettings.ErrorEmails,
                            $"Internal error {context.Request.Path} - webapi",
                            $"{context.TraceIdentifier} </br>{pr.Detail}</br>{pr.Instance}"));
                    }
                };

                setup.Map<Exception>(e => e.ToBaseProblemDetails(HttpStatusCode.InternalServerError));
                setup.Map<ValidationException>(e => e.ToBaseProblemDetails(HttpStatusCode.BadRequest));
                setup.Map<UserNotFoundException>(e => e.ToBaseProblemDetails(HttpStatusCode.Conflict));
                setup.Map<CredentialInvalidException>(e => e.ToBaseProblemDetails(HttpStatusCode.Conflict));
                setup.Map<UserAlreadyExistsException>(e => e.ToBaseProblemDetails(HttpStatusCode.Conflict));
                setup.Map<EmailNotFoundException>(e => e.ToBaseProblemDetails(HttpStatusCode.Conflict));
            });

            return services;
        }

        public static BaseProblemDetails ToBaseProblemDetails<T>(this T exception, HttpStatusCode httpCode) where T : Exception
        {
            var result = new BaseProblemDetails
            {
                Title = exception.Message,
                Status = (int?)httpCode,
                Type = HttpCodeToRfc(httpCode),
                Detail = exception.HelpLink,
                Instance = exception.StackTrace,
            };

            switch (exception)
            {
                case ValidationException e:
                    result.ValidationErrors.AddRange(e.ValdationErrors);
                    break;
            }

            return result;
        }

        private static string HttpCodeToRfc(HttpStatusCode httpCode) => httpCode switch
        {
            HttpStatusCode.BadRequest => "https://datatracker.ietf.org/doc/html/rfc7231#section-6.5.1",
            _ => "https://datatracker.ietf.org/doc/html/rfc7231#section-6.5"
        };
    }

    public class BaseProblemDetails : ProblemDetails
    {
        public List<string> ValidationErrors { get; init; } = new();
    }

}
