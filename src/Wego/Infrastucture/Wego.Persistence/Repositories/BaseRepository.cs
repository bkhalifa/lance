//using Microsoft.EntityFrameworkCore;
//using System.Linq.Expressions;
//using System.Threading;
//using Wego.Application.Contracts.Infrastructure;
//using Wego.Application.Contracts.Persistence;
//using Wego.Persistence.EF;

//namespace Wego.Persistence.Respositories;

//public class BaseRepository<T> : IBaseRepository<T> where T : class
//{
//    protected readonly PortoDbContext _dbContext;
//    protected readonly ICacheManager _cache;

//    public BaseRepository(PortoDbContext dbContext, ICacheManager cache)
//    {
//        _dbContext = dbContext;
//        _cache = cache;
//    }


//    public async Task<T> GetAsync(object id, int cacheDurationMinutes = 0, CancellationToken cancellationToken = default)
//    {
//        var func = _dbContext.Set<T>().FindAsync(id);
//        if (cacheDurationMinutes == 0)
//            return await func;
//        else
//            return await _cache.GetAsync<T>($"{nameof(T)}-id", async () => await func, cacheDurationMinutes, cancellationToken);
//    }

//    public async Task<IEnumerable<T>> GetAllAsync(int cacheDurationMinutes = 0, CancellationToken cancellationToken = default)
//    {
//        var func = _dbContext.Set<T>().AsNoTracking().ToListAsync();
//        if (cacheDurationMinutes == 0)
//            return await func;
//        else
//            return await _cache.GetAsync<IEnumerable<T>>($"{nameof(T)}s", async () => await func, cacheDurationMinutes, cancellationToken);
//    }

//    public async Task<IEnumerable<T>> FindAsync(Expression<Func<T, bool>> predicate, string cacheKey = null, int cacheDurationMinutes = 0, CancellationToken cancellationToken = default)
//    {
//        var func = _dbContext.Set<T>().AsNoTracking().Where(predicate).ToListAsync(); ;
//        if (cacheDurationMinutes == 0)
//            return await func;
//        else
//            return await _cache.GetAsync<IEnumerable<T>>(cacheKey, async () => await func, cacheDurationMinutes, cancellationToken);
//    }

//    public async Task<T> FirstOrDefaultAsync(Expression<Func<T, bool>> predicate, string cacheKey = null, int cacheDurationMinutes = 0, CancellationToken cancellationToken = default)
//    {
//        var func = _dbContext.Set<T>().AsNoTracking().FirstOrDefaultAsync(predicate);
//        if (cacheDurationMinutes == 0)
//            return await func;
//        else
//            return await _cache.GetAsync<T>(cacheKey, async () => await func, cacheDurationMinutes, cancellationToken);
//    }

//    public async Task<bool> ContainsAsync(Expression<Func<T, bool>> predicate)
//    {
//        return await _dbContext.Set<T>().AsNoTracking().AnyAsync(predicate);
//    }

//    public async Task<int> CountAsync(Expression<Func<T, bool>> predicate)
//    {
//        return await _dbContext.Set<T>().AsNoTracking().CountAsync(predicate);
//    }

//    public async Task<T> AddAsync(T entity)
//    {
//        _dbContext.Set<T>().Add(entity);
//        await _dbContext.SaveChangesAsync();

//        return entity;
//    }

//    public async Task AddRangeAsync(IEnumerable<T> entities)
//    {
//        _dbContext.Set<T>().AddRange(entities);
//        await _dbContext.SaveChangesAsync();
//    }

//    public async Task UpdateAsync(T entity)
//    {
//        _dbContext.Set<T>().Update(entity);
//        await _dbContext.SaveChangesAsync();
//    }

//    public async Task RemoveAsync(T entity)
//    {
//        _dbContext.Set<T>().Remove(entity);
//        await _dbContext.SaveChangesAsync();
//    }

//    public async Task RemoveRangeAsync(IEnumerable<T> entities)
//    {
//        _dbContext.Set<T>().RemoveRange(entities);
//        await _dbContext.SaveChangesAsync();
//    }
//}
