using Microsoft.AspNetCore.Http;
using Serilog.Core;
using Serilog.Events;

namespace Wego.Application.LogEnrichers
{
    public class TraceIdEnricher : ILogEventEnricher
    {
        readonly IHttpContextAccessor _httpContextAccessor;

        // IHttpContextAccessor supplied through constructor injection
        public TraceIdEnricher(IHttpContextAccessor httpContextAccessor)
        {
            _httpContextAccessor = httpContextAccessor;
        }

        public void Enrich(LogEvent logEvent, ILogEventPropertyFactory factory)
        {
            if (_httpContextAccessor.HttpContext== null)
                return;

            var userNameProperty = factory.CreateProperty("TraceId", _httpContextAccessor.HttpContext.TraceIdentifier);
            logEvent.AddPropertyIfAbsent(userNameProperty);
        }
    }
}
