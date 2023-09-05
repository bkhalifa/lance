using Dapper;
using Wego.Application.Contracts.Infrastructure;
using Wego.Application.Features.Categories.Queries;
using Wego.Application.IRepo;
using Wego.Application.Models.Common;
using Wego.Domain.Common;

namespace Wego.Persistence.Repositories.Common
{
    public class WorkTypeRepository : IWorkTypeRepository
    {
        private readonly DapperContext _context;
        private readonly ICacheManager _cacheManager;
        public WorkTypeRepository(DapperContext context, ICacheManager cacheManager)
        {
            _context = context;
            _cacheManager = cacheManager;
        }
        public async Task<IEnumerable<WorkTypeModel>> GetAllAsync(CancellationToken cancellationToken = default)
        {
            return await _cacheManager.GetAsync(nameof(WorkTypeModel), async () =>
            {
                var sql = "SELECT * FROM config.WorkTypes";
                using (var connection = _context.CreateConnection())
                {
                    return await connection.QueryAsync<WorkTypeModel>(sql);
                }
            }, CacheDuration.OneDay, cancellationToken);
        }
    }
}
