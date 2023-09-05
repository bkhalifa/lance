using Dapper;
using Wego.Application.Contracts.Infrastructure;
using Wego.Application.IRepo;
using Wego.Application.Models.Common;
using Wego.Domain.Common;

namespace Wego.Persistence.Repositories.Common
{
    public class ContractTypeRepository : IContractTypeRepository
    {
        private readonly DapperContext _context;
        private readonly ICacheManager _cacheManager;
        public ContractTypeRepository(DapperContext context, ICacheManager cacheManager)
        {
            _context = context;
            _cacheManager = cacheManager;
        }
        public async Task<IEnumerable<ContractTypeModel>> GetAllAsync(CancellationToken cancellationToken = default)
        {
            return await _cacheManager.GetAsync(nameof(ContractTypeModel), async () =>
            {
                var sql = "SELECT * FROM config.ContractTypes";
                using (var connection = _context.CreateConnection())
                {
                    return await connection.QueryAsync<ContractTypeModel>(sql);
                }
            }, CacheDuration.OneDay, cancellationToken);
        }
    }
}
