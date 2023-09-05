using Dapper;
using System.Threading;
using Wego.Application.Contracts.Infrastructure;
using Wego.Application.IRepo;
using Wego.Application.Models.Common;
using Wego.Domain.Common;

namespace Wego.Persistence.Repositories.Common
{
    public class SkillRepository : ISkillRepository
    {
        private readonly DapperContext _context;
        private readonly ICacheManager _cacheManager;
        public SkillRepository(DapperContext context, ICacheManager cacheManager)
        {
            _context = context;
            _cacheManager = cacheManager;
        }

        public async Task<IEnumerable<SkillModel>> GetAllAsync(CancellationToken cancellationToken = default)
        {
            return await _cacheManager.GetAsync(nameof(SkillModel), async () => {
                var sql = "SELECT * FROM config.Skills";
                using (var connection = _context.CreateConnection())
                {
                    return await connection.QueryAsync<SkillModel>(new CommandDefinition(sql, cancellationToken));
                }
            }, CacheDuration.OneHour, cancellationToken);         
        }

    }
}
