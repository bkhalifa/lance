using System.Security.Claims;

using Wego.Application.Contracts.Context;

namespace Wego.Infrastructure.Context
{
    public class IdentityContext : IIdentityContext
    {
        public bool IsAuthenticated { get; }
        public string Email { get; }
        public string UserId { get; }
        public long ProfileId { get; }
        public IEnumerable<string> Roles { get; } = new List<string>();
        public Dictionary<string, IEnumerable<string>> Claims { get; } = new();

        public IdentityContext(ClaimsPrincipal? principal)
        {
            if (principal?.Identity is null)
            {
                return;
            }

            long.TryParse(principal.FindFirstValue("profileId"), out var profileId);
            IsAuthenticated = principal.Identity?.IsAuthenticated is true;
            Email = principal.FindFirstValue(ClaimTypes.Email);
            UserId = principal.FindFirstValue("uid");
            ProfileId = profileId;
            Roles = principal.FindAll(claim => claim.Type == ClaimTypes.Role).Select(x => x.Value);
            Claims = principal.Claims.GroupBy(x => x.Type)
                .ToDictionary(x => x.Key, x => x.Select(c => c.Value.ToString()));
        }
    }
}
