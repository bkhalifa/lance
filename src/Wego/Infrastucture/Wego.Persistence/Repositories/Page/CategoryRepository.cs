using Dapper;

using Wego.Application.Features.Categories.Queries;
using Wego.Application.IRepo;


namespace Wego.Persistence.Repositories.Page
{
    public class CategoryRepository : ICategoryRepository
    {
        private readonly DapperContext _context;
        public CategoryRepository(DapperContext context)
        {
            _context = context;
        }
        public async Task<IEnumerable<GetCategoriesModel>> GetAllAsync()
        {
            var sql = "SELECT * FROM config.Categories";
            using (var connection = _context.CreateConnection())
            {
                var result = await connection.QueryAsync<GetCategoriesModel>(sql);
                return result;
            }
        }
    }
}
