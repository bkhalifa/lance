using MediatR;
using Wego.Application.Contracts.Persistence;
using Wego.Application.Extensions;
using Wego.Application.IRepo;
using Wego.Application.Models.Common;
using Wego.Domain.Common;
using Wego.Domain.Entities;

namespace Wego.Application.Features.Jobs.Queries
{
    public record GetContractTypeListQuery() : IRequest<List<ContractTypeModel>>;

    public class GetContractTypeListQueryHandler : IRequestHandler<GetContractTypeListQuery, List<ContractTypeModel>>
    {
        private readonly IContractTypeRepository _repository;

        public GetContractTypeListQueryHandler(IContractTypeRepository repository)
        {
            _repository = repository;
        }

        public async Task<List<ContractTypeModel>> Handle(GetContractTypeListQuery request, CancellationToken cancellationToken)
        {
            var result= await _repository.GetAllAsync(cancellationToken);
            return result.ToList();
        }
    }

}
