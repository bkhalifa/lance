using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

using Wego.Application.IRepository;
using Wego.Persistence.Repositories.Page;
using Wego.Persistence.Repositories.Profile;

namespace Wego.Persistence;

public static class DapperServiceRegistration
{
    public static IServiceCollection AddDapperPersistenceServices(this IServiceCollection services)
    {
        services.AddSingleton<DapperContext>();
        services.AddScoped<ICategoryRepository, CategoryRepository>();
        services.AddScoped<IProfileRepository, ProfileRepository>();

        return services;
    }
}