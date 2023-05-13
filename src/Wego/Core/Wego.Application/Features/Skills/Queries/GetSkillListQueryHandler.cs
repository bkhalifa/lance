using MediatR;
using Wego.Application.Contracts.Persistence;
using Wego.Application.Extensions;
using Wego.Application.Models.Common;
using Wego.Domain.Entities;

namespace Wego.Application.Features.Skills.Queries
{
    public class GetSkillModel : BaseReferentialModel { }
    public record GetSkillListQuery() : IRequest<List<GetSkillModel>>;

    public class GetSkillListQueryHandler : IRequestHandler<GetSkillListQuery, List<GetSkillModel>>
    {
        private readonly IBaseRepository<Skill> _repository;

        public GetSkillListQueryHandler(IBaseRepository<Skill> repository)
        {
            _repository = repository;
        }

        public async Task<List<GetSkillModel>> Handle(GetSkillListQuery request, CancellationToken cancellationToken)
        {
            var result= await _repository.GetAllAsync(CacheDuration.OneMonth, cancellationToken);
            return result.MapTo<List<GetSkillModel>>();
        }
    }

}
