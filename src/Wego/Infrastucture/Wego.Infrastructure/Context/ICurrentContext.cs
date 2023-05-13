using Microsoft.AspNetCore.Http;
using Wego.Application.Contracts.Context;

namespace Wego.Infrastructure.Context
{
    public class CurrentContext : ICurrentContext
    {
        public Guid RequestId { get; } 
        public string IpAddress { get; }
        public string UserAgent { get; }
        public IIdentityContext Identity { get; }

        public CurrentContext(IHttpContextAccessor httpContextAccessor)
        {
            RequestId = Guid.NewGuid();
            Identity = new IdentityContext(httpContextAccessor.HttpContext?.User);
            IpAddress = httpContextAccessor?.HttpContext?.Connection.RemoteIpAddress.ToString();
            UserAgent = httpContextAccessor?.HttpContext?.Request.Headers["user-agent"] ?? string.Empty;
        }
    }
}
