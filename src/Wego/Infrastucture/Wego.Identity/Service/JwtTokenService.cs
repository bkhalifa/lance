using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Net;
using System.Security.Claims;
using System.Text;
using Wego.Application.Contracts.Identity;
using Wego.Application.Exceptions;
using Wego.Application.Models.Authentification;


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
            var roles = await _userManager.GetRolesAsync(user);

            var roleClaims = new List<Claim>();

            for (int i = 0; i < roles.Count; i++)
            {
                roleClaims.Add(new Claim("roles", roles[i]));
            }

            var claims = new[]
            {
            new Claim(JwtRegisteredClaimNames.Sub, user.UserName),
            new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
            new Claim(JwtRegisteredClaimNames.Email, user.Email),
            new Claim("uid", user.Id)
        }
            .Union(userClaims)
            .Union(roleClaims);

            var symmetricSecurityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_jwtSettings.Key));
            var symmetricSecurityRefreshKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_jwtSettings.RefreshKey));

            var jwtSecurityToken = GetSecurityToken(claims, symmetricSecurityKey);
            var jwtSecurityRefreshToken = GetSecurityToken(claims, symmetricSecurityRefreshKey);

            var result = new TokenModel
            {
                AccessToken = new JwtSecurityTokenHandler().WriteToken(jwtSecurityToken),
                RefreshToken = new JwtSecurityTokenHandler().WriteToken(jwtSecurityRefreshToken),
            };
            await _userManager.SetAuthenticationTokenAsync(user, _jwtSettings.Name, _jwtSettings.RefreshName, result.RefreshToken);

            return result;
        }

        public async Task<TokenModel> RefreshTokenAsync(ApplicationUser user, string refreshToken)
        {
            if (string.IsNullOrEmpty(user?.UserName) || string.IsNullOrEmpty(user?.Email)) throw new UserNotFoundException("User Token not found");

            var validationParameters = new TokenValidationParameters
            {
                ValidateIssuerSigningKey = true,
                ValidateIssuer = true,
                ValidateAudience = true,
                ValidateLifetime = true,
                ClockSkew = TimeSpan.Zero,
                IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_jwtSettings.RefreshKey)),
                ValidIssuer = _jwtSettings.Issuer,
                ValidAudience = _jwtSettings.Audience,
            };

            JwtSecurityTokenHandler jwtSecurityTokenHandler = new();

            try
            {
                jwtSecurityTokenHandler.ValidateToken(refreshToken, validationParameters, out var _);
            }
            catch (SecurityTokenSignatureKeyNotFoundException)
            {
                throw new TokenInvalidException("Refresh token invalid");
            }

            return await GenerateTokenAsync(user);
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

    }
}
