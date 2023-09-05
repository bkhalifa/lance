using MediatR;
using Wego.Application.Contracts.Persistence;
using Wego.Application.Extensions;
using Wego.Application.IRepo;
using Wego.Application.Models.Common;
using Wego.Domain.Common;
using Wego.Domain.Entities;

namespace Wego.Application.Features.Jobs.Queries
{
    public record GetWorkTypeListQuery() : IRequest<List<WorkTypeModel>>;

    public class GetWorkTypeListQueryHandler : IRequestHandler<GetWorkTypeListQuery, List<WorkTypeModel>>
    {
        private readonly IWorkTypeRepository _repository;

        public GetWorkTypeListQueryHandler(IWorkTypeRepository repository)
        {
            _repository = repository;
        }

        public async Task<List<WorkTypeModel>> Handle(GetWorkTypeListQuery request, CancellationToken cancellationToken)
        {
            var result= await _repository.GetAllAsync(cancellationToken);
            return result.ToList();
        }
    }
}
