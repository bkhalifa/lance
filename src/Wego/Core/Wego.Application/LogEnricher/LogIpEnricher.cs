using Microsoft.AspNetCore.Http;
using Serilog.Core;
using Serilog.Events;

namespace Wego.Application.LogEnrichers
{

    public class LogIpEnricher : ILogEventEnricher
    {
        private readonly IHttpContextAccessor _contextAccessor;
        public LogIpEnricher(IHttpContextAccessor contextAccessor)
        {
            _contextAccessor = contextAccessor;
        }

        public void Enrich(LogEvent logEvent, ILogEventPropertyFactory propertyFactory)
        {
            if (_contextAccessor?.HttpContext?.Connection == null)
                return;
            logEvent.AddPropertyIfAbsent(
           propertyFactory.CreateProperty("IP", _contextAccessor.HttpContext.Connection.RemoteIpAddress, false));
        }
    }
}
