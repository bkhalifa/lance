using Microsoft.AspNetCore.Http;
using Serilog.Core;
using Serilog.Events;

namespace Wego.Infrastructure.Logging
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
            if (_httpContextAccessor.HttpContext == null)
                return;

            var userNameProperty = factory.CreateProperty("TraceId", _httpContextAccessor.HttpContext.TraceIdentifier);
            logEvent.AddPropertyIfAbsent(userNameProperty);
        }
    }

    public class UserNameEnricher : ILogEventEnricher
    {
        readonly IHttpContextAccessor _httpContextAccessor;

        // IHttpContextAccessor supplied through constructor injection
        public UserNameEnricher(IHttpContextAccessor httpContextAccessor)
        {
            _httpContextAccessor = httpContextAccessor;
        }

        public void Enrich(LogEvent logEvent, ILogEventPropertyFactory factory)
        {
            if (!(_httpContextAccessor.HttpContext?.User.Identity.IsAuthenticated ?? false))
                return;

            // Access the name of the logged-in user
            var userName = _httpContextAccessor.HttpContext.User.Identity.Name;
            var userNameProperty = factory.CreateProperty("UserName", userName);
            logEvent.AddPropertyIfAbsent(userNameProperty);
        }
    }
}
