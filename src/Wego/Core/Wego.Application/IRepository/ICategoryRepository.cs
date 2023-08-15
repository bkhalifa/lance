using Wego.Application.Features.Categories.Queries;

namespace Wego.Application.IRepository;

public interface ICategoryRepository
{
    Task<IEnumerable<GetCategoriesModel>> GetAllAsync();
}
