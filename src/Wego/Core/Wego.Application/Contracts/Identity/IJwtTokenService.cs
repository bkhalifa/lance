using System.Security.Claims;

using Wego.Application.Models.Authentification;

namespace Wego.Application.Contracts.Identity
{
    public interface IJwtTokenService
    {
        Task<TokenModel> GenerateTokenAsync(ApplicationUser user);
        ClaimsPrincipal? GetPrincipalFromExpiredToken(string token);
    }
}
