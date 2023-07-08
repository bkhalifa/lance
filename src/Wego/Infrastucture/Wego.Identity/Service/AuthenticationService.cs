using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;

using System.Security.Claims;

using System.Text;

using Wego.Application.Contracts.Common;
using Wego.Application.Contracts.Context;
using Wego.Application.Contracts.Identity;
using Wego.Application.Contracts.Persistence;
using Wego.Application.Exceptions;
using Wego.Application.Models.Authentification;
using Wego.Application.Models.Mail;
using Wego.Domain.Entities;

namespace Wego.Identity.Service;

public class AuthenticationService : IAuthenticationService
{
    private readonly UserManager<ApplicationUser> _userManager;
    private readonly SignInManager<ApplicationUser> _signInManager;
    private readonly IJwtTokenService _jwtTokenService;
    private readonly ILogger<IAuthenticationService> _logger;
    private readonly IEmailSender _emailSender;
    private readonly ICurrentContext _currentContext;
    private readonly IConfiguration _configuration;
    private readonly IBaseRepository<UserProfile> _profileRepository;

    public AuthenticationService(UserManager<ApplicationUser> userManager,
        SignInManager<ApplicationUser> signInManager,
         IJwtTokenService jwtTokenService,
         ILogger<IAuthenticationService> logger,
         IEmailSender emailSender,
         ICurrentContext currentContext,
         IConfiguration configuration,
         IBaseRepository<UserProfile> profileRepository
         )
    {
        _userManager = userManager;
        _signInManager = signInManager;
        _jwtTokenService = jwtTokenService;
        _logger = logger;
        _emailSender = emailSender;
        _currentContext = currentContext;
        _configuration = configuration;
        _profileRepository = profileRepository;
    }

    public async Task<AuthenticationResponse> LoginAsync(AuthenticationRequest request)
    {
        var user = await _userManager.FindByEmailAsync(request.Email);

        if (user is null)
            throw new CredentialInvalidException($"Credentials for '{request.Email} aren't valid'.");

        var result = await _signInManager.PasswordSignInAsync(user.UserName!, request.Password, false, lockoutOnFailure: false);

        if (!result.Succeeded)
            throw new CredentialInvalidException($"Credentials for '{request.Email} aren't valid'.");


        var jwtSecurityToken = await _jwtTokenService.GenerateTokenAsync(user);

        return new AuthenticationResponse
        {
            Id = user.Id,
            Token = jwtSecurityToken.AccessToken,
            RefreshToken = jwtSecurityToken.RefreshToken,
            Email = user.Email!
        };
    }

    public async Task<RegistrationResponse> RegisterAsync(RegistrationRequest request)
    {
        var existingUser = await _userManager.FindByNameAsync(request.Email);

        if (existingUser != null)
            throw new UserAlreadyExistsException($"Email '{request.Email}' already exists.");

        var profile = await _profileRepository.SingleOrDefaultAsync(x => x.Email == request.Email);
        if (profile != null)
            throw new UserAlreadyExistsException($"Email '{request.Email}' already exists.");

        var user = new ApplicationUser
        {
            UserName = request.Email,
            Email = request.Email
        };

        var existingEmail = await _userManager.FindByEmailAsync(user.Email);

        if (existingEmail == null)
        {
            var result = await _userManager.CreateAsync(user, request.Password);

            if (result.Succeeded)
            {
                await _emailSender.SendMailAsync(new Email(user.Email, "User Created", "New user created successfully!"));
                _logger.LogInformation("User Created: {email}", user.Email);

                var resultProfile = await _profileRepository.AddAsync(new UserProfile
                {
                    UserId = user.Id,
                    Email = request.Email,
                });

                return new RegistrationResponse() { UserId = user.Id, Email = user.Email, ProfileId = resultProfile.Id };
            }

            throw new ValidationException(result.Errors.ToDictionary(x => x.Code, x => x.Description));
        }
        else
            throw new UserAlreadyExistsException($"Email {request.Email} already exists.");

    }
    public async Task<bool> ChangePasswordAsync(string oldPassword, string newPassword)
    {
        if (string.IsNullOrEmpty(_currentContext.Identity?.Email)) throw new UserNotAuthentificatedException("User not Authentificated");


        var user = await _userManager.FindByEmailAsync(_currentContext.Identity.Email);

        if (user == null) throw new UserNotFoundException($"Email '{_currentContext.Identity.Email}' not found");

        if (_userManager.PasswordHasher.VerifyHashedPassword(user, user.PasswordHash, newPassword) == PasswordVerificationResult.Success)
            throw new PasswordsEqualsException("Password are equals");

        var result = await _userManager.ChangePasswordAsync(user, oldPassword, newPassword);
        if (result.Succeeded)
        {
            await _emailSender.SendMailAsync(new Email(_currentContext.Identity.Email, "Change Password", "Password updated successfully!"));
            return true;
        }
        else
            throw new ValidationException(result.Errors.ToDictionary(x => x.Code, x => x.Description));
    }

    public async Task LogoutAsync(LogoutModel logoutModel)
    {
        var user = await _userManager.FindByEmailAsync(logoutModel.Email);

        if (user == null) throw new UserNotFoundException($"Email '{_currentContext.Identity.Email}' not found");

        await _signInManager.SignOutAsync();
        await _userManager.UpdateSecurityStampAsync(user);
        await _userManager.RemoveAuthenticationTokenAsync(user, "JWT", "JWT Token");
    }
    public async Task<TokenModel> RefreshAsync(TokenModel tokenModel)
    {
        var principal = _jwtTokenService.GetPrincipalFromExpiredToken(tokenModel.AccessToken);
        if (principal is null) throw new UserNotAuthentificatedException("User not Authentificated");

        var userName = principal.Claims.FirstOrDefault()?.Value;

        if (string.IsNullOrEmpty(userName)) throw new UserNotAuthentificatedException("User not Authentificated");

        var user = await _userManager.FindByEmailAsync(userName);
        if (user == null) throw new UserNotFoundException($"Email '{_currentContext.Identity.Email}' not found");

        return await _jwtTokenService.GenerateTokenAsync(user);
    }
    public ClaimsPrincipal? GetPrincipalFromExpiredToken(string? token)
    {
        var tokenValidationParameters = new TokenValidationParameters
        {
            ValidateAudience = false,
            ValidateIssuer = false,
            ValidateIssuerSigningKey = true,
            IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["JWT:Secret"])),
            ValidateLifetime = false
        };

        var tokenHandler = new JwtSecurityTokenHandler();
        var principal = tokenHandler.ValidateToken(token, tokenValidationParameters, out SecurityToken securityToken);
        if (securityToken is not JwtSecurityToken jwtSecurityToken || !jwtSecurityToken.Header.Alg.Equals(SecurityAlgorithms.HmacSha256, StringComparison.InvariantCultureIgnoreCase))
            throw new SecurityTokenException("Invalid token");

        return principal;

    }

}
