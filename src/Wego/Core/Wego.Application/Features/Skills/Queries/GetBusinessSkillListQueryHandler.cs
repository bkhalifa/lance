using MediatR;
using Wego.Application.Contracts.Persistence;
using Wego.Application.Extensions;
using Wego.Application.Models.Common;
using Wego.Domain.Entities;

namespace Wego.Application.Features.Skills.Queries
{
    public class GetBusinessSkillModel : BaseReferentialModel { }
    public record GetBusinessSkillListQuery() : IRequest<List<GetBusinessSkillModel>>;

    public class GetBusinessSkillListQueryHandler : IRequestHandler<GetBusinessSkillListQuery, List<GetBusinessSkillModel>>
    {
        private readonly IBaseRepository<BusinessSkill> _repository;

        public GetBusinessSkillListQueryHandler(IBaseRepository<BusinessSkill> repository)
        {
            _repository = repository;
        }

        public async Task<List<GetBusinessSkillModel>> Handle(GetBusinessSkillListQuery request, CancellationToken cancellationToken)
        {
            var result= await _repository.GetAllAsync(CacheDuration.OneMonth, cancellationToken);
            return result.MapTo<List<GetBusinessSkillModel>>();
        }
    }
}
