using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Logging;

using System.IdentityModel.Tokens.Jwt;
using Wego.Application.Contracts.Common;
using Wego.Application.Contracts.Identity;
using Wego.Application.Exceptions;
using Wego.Application.Models.Authentification;
using Wego.Application.Models.Mail;
using Wego.Application.Contracts.Context;

namespace Wego.Identity.Service;

public class AuthenticationService : IAuthenticationService
{
    private readonly UserManager<ApplicationUser> _userManager;
    private readonly SignInManager<ApplicationUser> _signInManager;
    private readonly IJwtTokenService _jwtTokenService;
    private readonly ILogger<IAuthenticationService> _logger;
    private readonly IEmailSender _emailSender;
    private readonly ICurrentContext _currentContext;

    public AuthenticationService(UserManager<ApplicationUser> userManager,
        SignInManager<ApplicationUser> signInManager,
         IJwtTokenService jwtTokenService,
         ILogger<IAuthenticationService> logger,
         IEmailSender emailSender,
         ICurrentContext currentContext)
    {
        _userManager = userManager;
        _signInManager = signInManager;
        _jwtTokenService = jwtTokenService;
        _logger = logger;
        _emailSender = emailSender;
        _currentContext = currentContext;
    }

    public async Task<AuthenticationResponse> LoginAsync(AuthenticationRequest request)
    {
        var user = await _userManager.FindByEmailAsync(request.Email);

        if (user is null)
            throw new CredentialInvalidException($"Credentials for '{request.Email} aren't valid'.");

        var result = await _signInManager.PasswordSignInAsync(user.UserName, request.Password, false, lockoutOnFailure: false);

        if (!result.Succeeded)
            throw new CredentialInvalidException($"Credentials for '{request.Email} aren't valid'.");


        var jwtSecurityToken = await _jwtTokenService.GenerateTokenAsync(user);

        return new AuthenticationResponse
        {
            Id = user.Id,
            Token = jwtSecurityToken.AccessToken,
            RefreshToken = jwtSecurityToken.RefreshToken,
            Email = user.Email,
            UserName = user.UserName
        };
    }

    public async Task<RegistrationResponse> RegisterAsync(RegistrationRequest request)
    {
        var existingUser = await _userManager.FindByNameAsync(request.UserName);

        if (existingUser != null)
            throw new UserAlreadyExistsException($"Username '{request.UserName}' already exists.");

        var user = new ApplicationUser
        {
            Email = request.Email,
            FirstName = request.FirstName,
            LastName = request.LastName,
            UserName = request.UserName,
            EmailConfirmed = true
        };

        var existingEmail = await _userManager.FindByEmailAsync(request.Email);

        if (existingEmail == null)
        {
            var result = await _userManager.CreateAsync(user, request.Password);

            if (result.Succeeded)
            {
                await _emailSender.SendMailAsync(new Email(user.Email, "User Created", "New user created successfully!"));
                _logger.LogInformation("User Created: {email}", user.Email);
                return new RegistrationResponse() { UserId = user.Id };
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

    public async Task LogoutAsync()
    {
        if (string.IsNullOrEmpty(_currentContext.Identity?.Email)) throw new UserNotAuthentificatedException("User not Authentificated");

        var user = await _userManager.FindByEmailAsync(_currentContext.Identity.Email);

        if (user == null) throw new UserNotFoundException($"Email '{_currentContext.Identity.Email}' not found");

        await _signInManager.SignOutAsync();
        //await _userManager.UpdateSecurityStampAsync(user);
        //await _userManager.RemoveAuthenticationTokenAsync(user, "JWT", "JWT Token");
    }
    public async Task<TokenModel> RefreshAsync(string refreshToken)
    {
        if (string.IsNullOrEmpty(_currentContext.Identity?.Email)) throw new UserNotAuthentificatedException("User not Authentificated");

        var user = await _userManager.FindByEmailAsync(_currentContext.Identity.Email);
        if (user == null) throw new UserNotFoundException($"Email '{_currentContext.Identity.Email}' not found");

        return await _jwtTokenService.RefreshTokenAsync(user, refreshToken);
    }

}
