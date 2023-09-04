using Wego.Application.Features.Categories.Queries;
using Wego.Domain.Common;

namespace Wego.Application.IRepo;

public interface ILocationRepository 
{
    Task<IEnumerable<LocationModel>> GetByCodesAsync(string codes);
    Task<IEnumerable<LocationModel>> GetByQueryAsync(string query);
    Task<IEnumerable<RegionModel>> GetAllRegionsAsync();
    Task<IEnumerable<CountryModel>> GetAllCountriesAsync();

}
