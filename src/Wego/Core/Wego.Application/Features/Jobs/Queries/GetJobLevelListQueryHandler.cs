using MediatR;
using Wego.Application.Contracts.Persistence;
using Wego.Application.Extensions;
using Wego.Application.IRepo;
using Wego.Application.Models.Common;
using Wego.Domain.Common;
using Wego.Domain.Entities;

namespace Wego.Application.Features.Jobs.Queries
{
    public record GetJobLevelListQuery() : IRequest<List<JobLevelModel>>;

    public class GetJobLevelListQueryHandler : IRequestHandler<GetJobLevelListQuery, List<JobLevelModel>>
    {
        private readonly IJobLevelRepository _repository;

        public GetJobLevelListQueryHandler(IJobLevelRepository repository)
        {
            _repository = repository;
        }

        public async Task<List<JobLevelModel>> Handle(GetJobLevelListQuery request, CancellationToken cancellationToken)
        {
            var result= await _repository.GetAllAsync(cancellationToken);
            return result.ToList();
        }
    }
}
