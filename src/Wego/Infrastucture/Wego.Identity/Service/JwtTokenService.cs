using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;

using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

using Wego.Application.Contracts.Identity;
using Wego.Application.Exceptions;
using Wego.Application.Models.Authentification;
using Wego.Identity.Helpers;

namespace Wego.Identity.Service
{
    public class JwtTokenService : IJwtTokenService
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly JwtSettings _jwtSettings;


        public JwtTokenService(UserManager<ApplicationUser> userManager,
            IOptions<JwtSettings> jwtSettings)
        {
            _userManager = userManager;
            _jwtSettings = jwtSettings.Value;

        }

        public async Task<TokenModel> GenerateTokenAsync(ApplicationUser user)
        {
            if (string.IsNullOrEmpty(user?.UserName) || string.IsNullOrEmpty(user?.Email)) throw new UserNotFoundException("User Token not found");

            var userClaims = await _userManager.GetClaimsAsync(user);

            var claims = new[]
            {
            new Claim(JwtRegisteredClaimNames.Sub, user.UserName),
            new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
            new Claim(JwtRegisteredClaimNames.Email, user.Email),
            new Claim("uid", user.Id),
            }
            .Union(userClaims);

            var symmetricSecurityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_jwtSettings.Key));
            var symmetricSecurityRefreshKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_jwtSettings.RefreshKey));

            var jwtSecurityToken = GetSecurityToken(claims, symmetricSecurityKey);
            var jwtSecurityRefreshToken = GetSecurityToken(claims, symmetricSecurityRefreshKey);

            var result = new TokenModel
            {
                AccessToken = new JwtSecurityTokenHandler().WriteToken(jwtSecurityToken),
                RefreshToken = new JwtSecurityTokenHandler().WriteToken(jwtSecurityRefreshToken),
                Email = user.Email,
                InitialUserName = user.Email.GetInitials(),
            };
            await _userManager.SetAuthenticationTokenAsync(user, _jwtSettings.Name, _jwtSettings.RefreshName, result.RefreshToken);

            return result;
        }

        private JwtSecurityToken GetSecurityToken(IEnumerable<Claim> claims, SymmetricSecurityKey symmetricSecurityKey)
        {
            return new JwtSecurityToken(
                issuer: _jwtSettings.Issuer,
                audience: _jwtSettings.Audience,
                claims: claims,
                expires: DateTime.UtcNow.AddMinutes(_jwtSettings.DurationInMinutes),
                signingCredentials: new SigningCredentials(symmetricSecurityKey, SecurityAlgorithms.HmacSha256));
        }

        public ClaimsPrincipal? GetPrincipalFromExpiredToken(string? token)
        {
            var tokenValidationParameters = new TokenValidationParameters
            {
                ValidateAudience = false,
                ValidateIssuer = false,
                ValidateIssuerSigningKey = true,
                IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_jwtSettings.Key)),
                ValidateLifetime = false
            };

            var tokenHandler = new JwtSecurityTokenHandler();
            try
            {
                var principal = tokenHandler.ValidateToken(token, tokenValidationParameters, out SecurityToken securityToken);
                if (securityToken is not JwtSecurityToken jwtSecurityToken || !jwtSecurityToken.Header.Alg.Equals(SecurityAlgorithms.HmacSha256, StringComparison.InvariantCultureIgnoreCase))
                    throw new SecurityTokenException("Invalid token");

                return principal;
            }
            catch (Exception ex)
            {

                throw ex;
            }



        }

        public static class TokenLifetimeValidator
        {
            public static bool Validate(
                DateTime? notBefore,
                DateTime? expires,
                SecurityToken tokenToValidate,
                TokenValidationParameters @param
            )
            {
                return (expires != null && expires > DateTime.UtcNow);
            }
        }
    }
}
