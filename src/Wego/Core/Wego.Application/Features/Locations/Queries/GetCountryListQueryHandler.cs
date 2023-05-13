using MediatR;
using System.ComponentModel.DataAnnotations;
using Wego.Application.Contracts.Persistence;
using Wego.Application.Extensions;
using Wego.Application.Models.Common;
using Wego.Domain.Entities;

namespace Wego.Application.Features.Locations.Queries
{
    public class GetCountryModel : BaseReferentialModel
    {
        public short? Type { get; set; }
    }
    public record GetCountryListQuery() : IRequest<List<GetCountryModel>>;

    public class GetCountryListQueryHandler : IRequestHandler<GetCountryListQuery, List<GetCountryModel>>
    {
        private readonly IBaseRepository<Country> _repository;

        public GetCountryListQueryHandler(IBaseRepository<Country> repository)
        {
            _repository = repository;
        }

        public async Task<List<GetCountryModel>> Handle(GetCountryListQuery request, CancellationToken cancellationToken)
        {
            var result= await _repository.GetAllAsync(CacheDuration.OneMonth, cancellationToken);
            return result.MapTo<List<GetCountryModel>>();
        }
    }
}
