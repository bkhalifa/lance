using Dapper;
using Wego.Application.IRepo;
using Wego.Domain.Common;

namespace Wego.Persistence.Repositories.Common
{
    public class JobLevelRepository : IJobLevelRepository
    {
        private readonly DapperContext _context;
        public JobLevelRepository(DapperContext context)
        {
            _context = context;
        }
        public async Task<IEnumerable<JobLevelModel>> GetAllAsync()
        {
            var sql = "SELECT * FROM config.JobLevel";
            using (var connection = _context.CreateConnection())
            {
                return await connection.QueryAsync<JobLevelModel>(sql);
            }
        }
    }
}
