using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Wego.Application.Contracts.Infrastructure
{
    public interface ICacheManager
    {
        Task SetAsync<T>(string cacheKey, T cacheValue, int durationMinutes, CancellationToken cancellationToken = default);
        Task<T> GetAsync<T>(string cacheKey, CancellationToken cancellationToken = default);
        Task<T> GetAsync<T>(string cacheKey, Func<Task<T>> func, int durationMinutes, CancellationToken cancellationToken);
        Task RemoveAsync(string cacheKey, CancellationToken cancellationToken = default);
        Task<bool> ExistsAsync(string cacheKey, CancellationToken cancellationToken = default);
        Task<bool> TrySetAsync<T>(string cacheKey, T cacheValue, int durationMinutes, CancellationToken cancellationToken = default);
        Task RemoveByPatternAsync(string pattern, CancellationToken cancellationToken = default);
    }
}
