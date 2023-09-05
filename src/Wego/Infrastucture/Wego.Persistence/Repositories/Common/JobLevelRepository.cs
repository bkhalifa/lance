using Dapper;
using Wego.Application.Contracts.Infrastructure;
using Wego.Application.IRepo;
using Wego.Application.Models.Common;
using Wego.Domain.Common;

namespace Wego.Persistence.Repositories.Common
{
    public class JobLevelRepository : IJobLevelRepository
    {
        private readonly DapperContext _context;
        private readonly ICacheManager _cacheManager;
        public JobLevelRepository(DapperContext context, ICacheManager cacheManager)
        {
            _context = context;
            _cacheManager = cacheManager;
        }
        public async Task<IEnumerable<JobLevelModel>> GetAllAsync(CancellationToken cancellationToken = default)
        {
            return await _cacheManager.GetAsync(nameof(JobLevelModel), async () =>
            {
                var sql = "SELECT * FROM config.JobLevel";
                using (var connection = _context.CreateConnection())
                {
                    return await connection.QueryAsync<JobLevelModel>(sql);
                }
            }, CacheDuration.OneDay, cancellationToken);
        }
    }
}
