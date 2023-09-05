using Wego.Domain.Common;

namespace Wego.Application.IRepo
{
    public interface IWorkTypeRepository
    {
        Task<IEnumerable<WorkTypeModel>> GetAllAsync(CancellationToken cancellationToken = default);
    }
}
