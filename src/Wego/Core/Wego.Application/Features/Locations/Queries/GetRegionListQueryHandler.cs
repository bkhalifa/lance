using MediatR;
using Wego.Application.IRepo;
using Wego.Domain.Common;

namespace Wego.Application.Features.Locations.Queries
{
    public record GetRegionListQuery() : IRequest<List<RegionModel>>;

    public class GetRegionListQueryHandler : IRequestHandler<GetRegionListQuery, List<RegionModel>>
    {
        private readonly ILocationRepository _repository;

        public GetRegionListQueryHandler(ILocationRepository repository)
        {
            _repository = repository;
        }

        public async Task<List<RegionModel>> Handle(GetRegionListQuery request, CancellationToken cancellationToken)
        {
            var result = await _repository.GetAllRegionsAsync();
            return result.ToList();
        }
    }
}
