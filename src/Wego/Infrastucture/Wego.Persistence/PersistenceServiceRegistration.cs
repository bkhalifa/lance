using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Wego.Application.IRepo;
using Wego.Application.IRepository;
using Wego.Persistence.Repositories.Common;
using Wego.Persistence.Repositories.OfferProfile;
using Wego.Persistence.Repositories.Offers;
using Wego.Persistence.Repositories.Profile;

namespace Wego.Persistence;

public static class PersistenceServiceRegistration
{
    public static IServiceCollection AddPersistenceServices(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddSingleton<DapperContext>();
        services.AddScoped<ICategoryRepository, CategoryRepository>();
        services.AddScoped<IProfileRepository, ProfileRepository>();
        services.AddScoped<ILocationRepository, LocationRepository>();
        services.AddScoped<ISkillRepository, SkillRepository>();
        services.AddScoped<IOfferRepository, OfferRepository>();
        services.AddScoped<IOfferProfileRepository, OfferProfileRepository>();
        services.AddScoped<IWorkTypeRepository, WorkTypeRepository>();
        services.AddScoped<IContractTypeRepository, ContractTypeRepository>();
        services.AddScoped<IJobLevelRepository, JobLevelRepository>();
        services.AddScoped<ICandidateRepository, CandidateRepository>();
        return services;
    }
}