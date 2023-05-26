using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Diagnostics.HealthChecks;
using Microsoft.AspNetCore.Http.Extensions;

namespace Wego.Infrastructure.HealthCheck
{
    public class ApiHealthCheck : IHealthCheck
    {
        private readonly IHttpClientFactory _httpClientFactory;
        private readonly IHttpContextAccessor _httpContextAccessor;
        public ApiHealthCheck(IHttpClientFactory httpClientFactory, IHttpContextAccessor httpContextAccessor)
        {
            _httpClientFactory = httpClientFactory;
            _httpContextAccessor = httpContextAccessor;
        }
        public async Task<HealthCheckResult> CheckHealthAsync(HealthCheckContext context,
            CancellationToken cancellationToken = default)
        {
            var request = _httpContextAccessor.HttpContext.Request;
            var uriBuilder = new UriBuilder(request.Scheme, request.Host.Host, request.Host.Port ?? -1);

            using (var httpClient = _httpClientFactory.CreateClient())
            {
                var response = await httpClient.GetAsync(uriBuilder.Uri.AbsoluteUri+ "api/Referential/GetAllContractTypes");
                if (response.IsSuccessStatusCode)
                {
                    return HealthCheckResult.Healthy($"API is running.");
                }

                return HealthCheckResult.Unhealthy("API is not running");
            }
        }
    }
}
