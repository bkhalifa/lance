using Wego.Application.Features.Categories.Queries;

namespace Wego.Application.IRepo;

public interface ICategoryRepository 
{
    Task<IEnumerable<CategoryModel>> GetAllAsync(CancellationToken cancellationToken = default);
}
