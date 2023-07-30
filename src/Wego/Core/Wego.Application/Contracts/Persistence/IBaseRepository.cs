using System.Linq.Expressions;

namespace Wego.Application.Contracts.Persistence;

public interface IBaseRepository<T> where T : class
{

    Task<T?> GetAsync(object id, int cacheDurationMinutes = 0, CancellationToken cancellationToken = default);
    Task<IEnumerable<T>> GetAllAsync(int cacheDurationMinutes = 0, CancellationToken cancellationToken = default);

    Task<T?> FirstOrDefaultAsync(Expression<Func<T, bool>> predicate, string cacheKey = null, int cacheDurationMinutes = 0, CancellationToken cancellationToken = default);
    Task<IEnumerable<T>> FindAsync(Expression<Func<T, bool>> predicate, string cacheKey = null, int cacheDurationMinutes = 0, CancellationToken cancellationToken = default);
    Task<bool> ContainsAsync(Expression<Func<T, bool>> predicate);
    Task<int> CountAsync(Expression<Func<T, bool>> predicate);
    Task<T> AddAsync(T entity);
    Task AddRangeAsync(IEnumerable<T> entities);
    Task UpdateAsync(T entity);
    Task RemoveAsync(T entity);
    Task RemoveRangeAsync(IEnumerable<T> entities);

}
