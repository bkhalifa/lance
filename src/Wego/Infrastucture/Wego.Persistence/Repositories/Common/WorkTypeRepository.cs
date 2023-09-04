using Dapper;

using Wego.Application.Features.Categories.Queries;
using Wego.Application.IRepo;
using Wego.Domain.Common;

namespace Wego.Persistence.Repositories.Common
{
    public class WorkTypeRepository : IWorkTypeRepository
    {
        private readonly DapperContext _context;
        public WorkTypeRepository(DapperContext context)
        {
            _context = context;
        }
        public async Task<IEnumerable<WorkTypeModel>> GetAllAsync()
        {
            var sql = "SELECT * FROM config.WorkTypes";
            using (var connection = _context.CreateConnection())
            {
                return await connection.QueryAsync<WorkTypeModel>(sql);
            }
        }
    }
}
