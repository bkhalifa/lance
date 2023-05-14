using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using Wego.Application.Models.Authentification;

namespace Wego.Application.Contracts.Identity
{
    public interface IJwtTokenService
    {
        Task<TokenModel> GenerateTokenAsync(ApplicationUser user);
        Task<TokenModel> RefreshTokenAsync(ApplicationUser user, string refreshToken);
    }
}
