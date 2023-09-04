using MediatR;
using Wego.Application.IRepo;
using Wego.Domain.Common;

namespace Wego.Application.Features.Locations.Queries
{
    public record GetCountryListQuery() : IRequest<List<CountryModel>>;

    public class GetCountryListQueryHandler : IRequestHandler<GetCountryListQuery, List<CountryModel>>
    {
        private readonly ILocationRepository _repository;

        public GetCountryListQueryHandler(ILocationRepository repository)
        {
            _repository = repository;
        }

        public async Task<List<CountryModel>> Handle(GetCountryListQuery request, CancellationToken cancellationToken)
        {
            var result = await _repository.GetAllCountriesAsync();
            return result.ToList();
        }
    }
}
