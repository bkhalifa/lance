using MediatR;
using Microsoft.Data.SqlClient;
using System.ComponentModel.DataAnnotations;
using Wego.Application.Contracts.Persistence;


namespace Wego.Application.Features.Locations.Queries
{
    public record GetLocationsByQueryListQuery([Required][StringLength(20, MinimumLength = 2)] string Query) : IRequest<List<GetLocationsByQueryModel>>;

    public class GetLocationsByQueryListQueryHandler : IRequestHandler<GetLocationsByQueryListQuery, List<GetLocationsByQueryModel>>
    {
        private readonly IDataManager _dataManager;

        public GetLocationsByQueryListQueryHandler(IDataManager dataManager)
        {
            _dataManager = dataManager;
        }

        public async Task<List<GetLocationsByQueryModel>> Handle(GetLocationsByQueryListQuery request, CancellationToken cancellationToken)
        {
            var sqlParams = new List<SqlParameter>
            {
                new SqlParameter("Query", request.Query)
            };

            return await _dataManager.GetListAsync<GetLocationsByQueryModel>("LocationSearchEngine", sqlParams);
        }
    }
}
