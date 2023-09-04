using Wego.Domain.Common;

namespace Wego.Application.IRepo
{
    public interface IContractTypeRepository
    {
        Task<IEnumerable<ContractTypeModel>> GetAllAsync();
    }
}
