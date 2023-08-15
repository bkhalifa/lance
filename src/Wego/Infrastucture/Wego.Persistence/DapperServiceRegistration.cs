using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

using Wego.Application.IRepository;
using Wego.Persistence.Repositories.Page;

namespace Wego.Persistence;

public static class DapperServiceRegistration
{
    public static IServiceCollection AddDapperPersistenceServices(this IServiceCollection services)
    {
        services.AddSingleton<DapperContext>();
        services.AddTransient<ICategoryRepository, CategoryRepository>();

        return services;
    }
}