using Wego.Application.Features.Categories.Queries;
using Wego.Domain.Common;

namespace Wego.Application.IRepo;

public interface ILocationRepository 
{
    Task<IEnumerable<LocationModel>> GetByCodesAsync(string codes, CancellationToken cancellationToken = default);
    Task<IEnumerable<LocationModel>> GetByQueryAsync(string query, CancellationToken cancellationToken = default);
    Task<IEnumerable<RegionModel>> GetAllRegionsAsync(CancellationToken cancellationToken = default);
    Task<IEnumerable<CountryModel>> GetAllCountriesAsync(CancellationToken cancellationToken = default);

}
