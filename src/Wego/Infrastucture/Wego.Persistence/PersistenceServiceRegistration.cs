using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

using Wego.Application.Contracts.Persistence;
using Wego.Persistence.EF;
using Wego.Persistence.Respositories;

namespace Wego.Persistence;

public static class PersistenceServiceRegistration
{
    public static IServiceCollection AddPersistenceServices(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddDbContext<PortoDbContext>(options =>
            options.UseSqlServer(configuration.GetConnectionString("PortoDb")));
        services.AddScoped(typeof(IBaseRepository<>), typeof(BaseRepository<>));
        services.AddScoped<IDataManager, DataManager>();
        return services;
    }
}