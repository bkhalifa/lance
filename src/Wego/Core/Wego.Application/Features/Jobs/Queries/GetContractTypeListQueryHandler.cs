using MediatR;
using Wego.Application.Contracts.Persistence;
using Wego.Application.Extensions;
using Wego.Application.Models.Common;
using Wego.Domain.Entities;

namespace Wego.Application.Features.Jobs.Queries
{
    public class GetContractTypeModel : BaseReferentialModel { }
    public record GetContractTypeListQuery() : IRequest<List<GetContractTypeModel>>;

    public class GetContractTypeListQueryHandler : IRequestHandler<GetContractTypeListQuery, List<GetContractTypeModel>>
    {
        private readonly IBaseRepository<ContractType> _repository;

        public GetContractTypeListQueryHandler(IBaseRepository<ContractType> repository)
        {
            _repository = repository;
        }

        public async Task<List<GetContractTypeModel>> Handle(GetContractTypeListQuery request, CancellationToken cancellationToken)
        {
            var result= await _repository.GetAllAsync(CacheDuration.OneMonth, cancellationToken);
            return result.MapTo<List<GetContractTypeModel>>();
        }
    }

}
