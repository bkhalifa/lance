using MediatR;
using Wego.Application.IRepo;
using Wego.Domain.Common;

namespace Wego.Application.Features.Skills.Queries
{
    public record GetSkillListQuery() : IRequest<List<SkillModel>>;

    public class GetSkillListQueryHandler : IRequestHandler<GetSkillListQuery, List<SkillModel>>
    {
        private readonly ISkillRepository _repository;

        public GetSkillListQueryHandler(ISkillRepository repository)
        {
            _repository = repository;
        }

        public async Task<List<SkillModel>> Handle(GetSkillListQuery request, CancellationToken cancellationToken)
        {
            var result = await _repository.GetAllAsync();
            return result.ToList();
        }
    }

}
