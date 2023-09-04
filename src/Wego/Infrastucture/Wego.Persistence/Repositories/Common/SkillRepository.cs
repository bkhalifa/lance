using Dapper;
using Wego.Application.IRepo;
using Wego.Domain.Common;

namespace Wego.Persistence.Repositories.Common
{
    public class SkillRepository : ISkillRepository
    {
        private readonly DapperContext _context;
        public SkillRepository(DapperContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<SkillModel>> GetAllAsync()
        {
            var sql = "SELECT * FROM config.Skills";
            using (var connection = _context.CreateConnection())
            {
                return await connection.QueryAsync<SkillModel>(sql);
            }
        }

    }
}
