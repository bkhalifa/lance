using Microsoft.AspNetCore.Http;
using Serilog.Core;
using Serilog.Events;

namespace Wego.Application.LogEnrichers
{
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
