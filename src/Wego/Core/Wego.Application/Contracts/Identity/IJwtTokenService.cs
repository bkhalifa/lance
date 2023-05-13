using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using Wego.Application.Models.Authentification;

namespace Wego.Application.Contracts.Identity
{
    public interface IJwtTokenService
    {
        Task<JwtSecurityToken> GenerateTokenAsync(ApplicationUser user);
    }
}
