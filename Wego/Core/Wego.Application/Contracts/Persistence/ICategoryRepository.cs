using Wego.Domain.Entities;

namespace Wego.Application.Contracts.Persistence;

public interface ICategoryRepository : IAsyncRepository<Category>
{
    Task<IEnumerable<Category>> GetCategories();
}
