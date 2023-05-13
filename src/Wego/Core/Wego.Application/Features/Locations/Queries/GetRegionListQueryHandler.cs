using MediatR;
using System.ComponentModel.DataAnnotations;
using Wego.Application.Contracts.Persistence;
using Wego.Application.Extensions;
using Wego.Application.Models.Common;
using Wego.Domain.Entities;

namespace Wego.Application.Features.Locations.Queries
{
    public class GetRegionModel : BaseReferentialModel { }
    public record GetRegionListQuery() : IRequest<List<GetRegionModel>>;

    public class GetRegionListQueryHandler : IRequestHandler<GetRegionListQuery, List<GetRegionModel>>
    {
        private readonly IBaseRepository<Region> _repository;

        public GetRegionListQueryHandler(IBaseRepository<Region> repository)
        {
            _repository = repository;
        }

        public async Task<List<GetRegionModel>> Handle(GetRegionListQuery request, CancellationToken cancellationToken)
        {
            var result = await _repository.GetAllAsync(CacheDuration.OneMonth, cancellationToken);
            return result.MapTo<List<GetRegionModel>>();
        }
    }
}
