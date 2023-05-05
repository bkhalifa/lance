using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System.Configuration;
using Wego.Application.Contracts.Common;
using Wego.Application.Contracts.Persistence;
using Wego.Application.Features.Common;
using Wego.Application.Models.Mail;
using Wego.Persistence.EF;
using Wego.Persistence.Respositories;
using Wego.Persistence.Respositories.Config;

namespace Wego.Persistence;

public static class PersistenceServiceRegistration
{
    public static IServiceCollection AddPersistenceServices(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddDbContext<PortoDbContext>(options =>
            options.UseSqlServer(configuration.GetConnectionString("PortoDb")));

        services.AddScoped(typeof(IAsyncRepository<>), typeof(BaseRepository<>));

        services.AddScoped<ICategoryRepository, CategoryRepository>();
        services.AddScoped<IEmailSender, EmailSender>();
        services.Configure<EmailSettings>(configuration.GetSection(nameof(EmailSettings)));

        return services;
    }
}