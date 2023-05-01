using Microsoft.EntityFrameworkCore;

using Wego.Application.Contracts.Persistence;
using Wego.Domain.Entities;
using Wego.Persistence.EF;

namespace Wego.Persistence.Respositories.Config
{
    public class CategoryRepository : BaseRepository<Category>, ICategoryRepository
    {
        public CategoryRepository(PortoDbContext dbContext) : base(dbContext)
        {
        }

        public async Task<IEnumerable<Category>> GetCategories()
        {
            return  await _dbContext.Categories.ToListAsync();
        }
    }
}
