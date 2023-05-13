using MediatR;
using Wego.Application.Contracts.Persistence;
using Wego.Application.Extensions;
using Wego.Application.Models.Common;
using Wego.Domain.Entities;

namespace Wego.Application.Features.Jobs.Queries
{
    public class GetJobLevelModel : BaseReferentialModel { }
    public record GetJobLevelListQuery() : IRequest<List<GetJobLevelModel>>;

    public class GetJobLevelListQueryHandler : IRequestHandler<GetJobLevelListQuery, List<GetJobLevelModel>>
    {
        private readonly IBaseRepository<JobLevel> _repository;

        public GetJobLevelListQueryHandler(IBaseRepository<JobLevel> repository)
        {
            _repository = repository;
        }

        public async Task<List<GetJobLevelModel>> Handle(GetJobLevelListQuery request, CancellationToken cancellationToken)
        {
            var result= await _repository.GetAllAsync(CacheDuration.OneMonth, cancellationToken);
            return result.MapTo<List<GetJobLevelModel>>();
        }
    }
}
