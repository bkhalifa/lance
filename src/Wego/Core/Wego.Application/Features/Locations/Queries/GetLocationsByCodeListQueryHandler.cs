using MediatR;
using System.ComponentModel.DataAnnotations;
using Wego.Application.IRepo;

namespace Wego.Application.Features.Locations.Queries
{
    public record GetLocationsByCodeListQuery([Required] string Codes) : IRequest<List<GetLocationsByCodeModel>>;

    public class GetLocationsByCodeListQueryHandler : IRequestHandler<GetLocationsByCodeListQuery, List<GetLocationsByCodeModel>>
    {
        private readonly ILocationRepository _repository;

        public GetLocationsByCodeListQueryHandler(ILocationRepository repository)
        {
            _repository = repository;
        }

        public async Task<List<GetLocationsByCodeModel>> Handle(GetLocationsByCodeListQuery request, CancellationToken cancellationToken)
        {
            var result = await _repository.GetByCodesAsync(request.Codes);

            return result.GroupBy(x => x.Code).Select(x => new GetLocationsByCodeModel
            {
                Code = x.Key,
                Name = x.First().Name,
                ParentName = x.First().ParentName,
            }).ToList();
        }
    }
}
