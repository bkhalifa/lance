using MediatR;
using Microsoft.Data.SqlClient;
using System.ComponentModel.DataAnnotations;
using Wego.Application.Contracts.Persistence;
using Wego.Application.IRepo;
using Wego.Domain.Common;

namespace Wego.Application.Features.Locations.Queries
{
    public record GetLocationsByQueryListQuery([Required][StringLength(20, MinimumLength = 2)] string Query) : IRequest<List<LocationModel>>;

    public class GetLocationsByQueryListQueryHandler : IRequestHandler<GetLocationsByQueryListQuery, List<LocationModel>>
    {
        private readonly ILocationRepository _repository;

        public GetLocationsByQueryListQueryHandler(ILocationRepository repository)
        {
            _repository = repository;
        }

        public async Task<List<LocationModel>> Handle(GetLocationsByQueryListQuery request, CancellationToken cancellationToken)
        {
            var result = await _repository.GetByQueryAsync(request.Query);
            return result.ToList();
        }
    }
}
