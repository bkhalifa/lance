using EasyCaching.Core;

using Wego.Application.Contracts.Infrastructure;

namespace Wego.Infrastructure.Log;

public class CacheManager : ICacheManager
{
    private readonly IEasyCachingProvider _cacheProvider;

    public CacheManager(IEasyCachingProvider cacheProvider)
    {
        _cacheProvider = cacheProvider;
    }

    public async Task SetAsync<T>(string cacheKey, T cacheValue, int durationMinutes, CancellationToken cancellationToken = default)
    {
        await _cacheProvider.SetAsync(cacheKey, cacheValue, TimeSpan.FromMinutes(durationMinutes), cancellationToken);
    }

    public async Task<T> GetAsync<T>(string cacheKey, CancellationToken cancellationToken = default)
    {
        var result = await _cacheProvider.GetAsync<T>(cacheKey, cancellationToken);

        return result.HasValue ? result.Value : default;
    }

    public async Task<T> GetAsync<T>(string cacheKey, Func<Task<T>> func, int durationMinutes, CancellationToken cancellationToken)
    {
        var result = await _cacheProvider.GetAsync(cacheKey, func, TimeSpan.FromMinutes(durationMinutes), cancellationToken);

        return result.HasValue ? result.Value : default;
    }

    public async Task RemoveAsync(string cacheKey, CancellationToken cancellationToken = default)
    {
        await _cacheProvider.RemoveAsync(cacheKey, cancellationToken);
    }

    public async Task<bool> ExistsAsync(string cacheKey, CancellationToken cancellationToken = default)
    {
        return await _cacheProvider.ExistsAsync(cacheKey, cancellationToken);
    }

    public async Task<bool> TrySetAsync<T>(string cacheKey, T cacheValue, int durationMinutes, CancellationToken cancellationToken = default)
    {
        return await _cacheProvider.TrySetAsync(cacheKey, cacheValue, TimeSpan.FromMinutes(durationMinutes), cancellationToken);
    }

    public async Task RemoveByPatternAsync(string pattern, CancellationToken cancellationToken = default)
    {
        await _cacheProvider.RemoveByPatternAsync(pattern, cancellationToken);
    }

}

