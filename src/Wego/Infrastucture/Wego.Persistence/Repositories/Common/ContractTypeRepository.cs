using Dapper;
using Wego.Application.IRepo;
using Wego.Domain.Common;

namespace Wego.Persistence.Repositories.Common
{
    public class ContractTypeRepository : IContractTypeRepository
    {
        private readonly DapperContext _context;
        public ContractTypeRepository(DapperContext context)
        {
            _context = context;
        }
        public async Task<IEnumerable<ContractTypeModel>> GetAllAsync()
        {
            var sql = "SELECT * FROM config.ContractTypes";
            using (var connection = _context.CreateConnection())
            {
                return await connection.QueryAsync<ContractTypeModel>(sql);
            }
        }
    }
}
