using Wego.Domain.Common;

namespace Wego.Application.IRepo;

public interface ISkillRepository
{
    Task<IEnumerable<SkillModel>> GetAllAsync(CancellationToken cancellationToken = default);
}
