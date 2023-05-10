using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;

namespace Wego.Application.Contracts.Persistence
{
    public interface IDataManager
    {
        Task<List<TEntity>> GetListAsync<TEntity>(string storedProcedure, IEnumerable<SqlParameter> parameters, CancellationToken cancellationToken = default) where TEntity : class;
    }
}
