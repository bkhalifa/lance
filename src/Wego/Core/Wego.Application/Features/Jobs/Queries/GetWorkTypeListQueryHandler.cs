using MediatR;
using Wego.Application.Contracts.Persistence;
using Wego.Application.Extensions;
using Wego.Application.Models.Common;
using Wego.Domain.Entities;

namespace Wego.Application.Features.Jobs.Queries
{
    public class GetWorkTypeModel : BaseReferentialModel { }
    public record GetWorkTypeListQuery() : IRequest<List<GetWorkTypeModel>>;

    public class GetWorkTypeListQueryHandler : IRequestHandler<GetWorkTypeListQuery, List<GetWorkTypeModel>>
    {
        private readonly IBaseRepository<WorkType> _repository;

        public GetWorkTypeListQueryHandler(IBaseRepository<WorkType> repository)
        {
            _repository = repository;
        }

        public async Task<List<GetWorkTypeModel>> Handle(GetWorkTypeListQuery request, CancellationToken cancellationToken)
        {
            var result= await _repository.GetAllAsync(CacheDuration.OneMonth, cancellationToken);
            return result.MapTo<List<GetWorkTypeModel>>();
        }
    }
}
