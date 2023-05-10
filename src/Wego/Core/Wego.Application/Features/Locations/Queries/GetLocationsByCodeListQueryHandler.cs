using MediatR;
using System.ComponentModel.DataAnnotations;
using Wego.Application.Contracts.Persistence;
using Wego.Application.Extensions;
using Wego.Domain.Entities;

namespace Wego.Application.Features.Locations.Queries
{
    public record GetLocationsByCodeListQuery([Required] string Code) : IRequest<List<GetLocationsByCodeModel>>;

    public class GetLocationsByCodeListQueryHandler : IRequestHandler<GetLocationsByCodeListQuery, List<GetLocationsByCodeModel>>
    {
        private readonly IBaseRepository<LocationsSearch> _repository;

        public GetLocationsByCodeListQueryHandler(IBaseRepository<LocationsSearch> repository)
        {
            _repository = repository;
        }

        public async Task<List<GetLocationsByCodeModel>> Handle(GetLocationsByCodeListQuery request, CancellationToken cancellationToken)
        {
            var locationCodes = request.Code?.Split('|');
            var result = await _repository.FindAsync(x => locationCodes.Contains(x.Code));

            return result.GroupBy(x=> x.Code).Select(x=> new GetLocationsByCodeModel
            {
                Code = x.Key,
                Name= x.First().Name,
                ParentName = x.First().ParentName,
            }).ToList();
        }
    }
}
