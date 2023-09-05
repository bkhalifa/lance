using Wego.Domain.Common;

namespace Wego.Application.IRepo
{
    public interface IJobLevelRepository
    {
        Task<IEnumerable<JobLevelModel>> GetAllAsync(CancellationToken cancellationToken = default);
    }
}
