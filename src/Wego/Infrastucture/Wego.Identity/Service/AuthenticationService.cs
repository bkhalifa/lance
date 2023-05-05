using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;

using System.IdentityModel.Tokens.Jwt;
using Wego.Application.Contracts.Common;
using Wego.Application.Contracts.Identity;
using Wego.Application.Exceptions;
using Wego.Application.Models.Authentification;
using Wego.Application.Models.Mail;

namespace Wego.Identity.Service;

public class AuthenticationService : IAuthenticationService
{
    private readonly UserManager<ApplicationUser> _userManager;
    private readonly SignInManager<ApplicationUser> _signInManager;
    private readonly IJwtTokenService _jwtTokenService;
    private readonly ILogger<IAuthenticationService> _logger;
    private readonly IEmailSender _emailSender;

    public AuthenticationService(UserManager<ApplicationUser> userManager,
        SignInManager<ApplicationUser> signInManager,
         IJwtTokenService jwtTokenService,
         ILogger<IAuthenticationService> logger,
         IEmailSender emailSender)
    {
        _userManager = userManager;
        _signInManager = signInManager;
        _jwtTokenService = jwtTokenService;
        _logger = logger;
        _emailSender = emailSender;
    }

    public async Task<AuthenticationResponse> AuthenticateAsync(AuthenticationRequest request)
    {
        var user = await _userManager.FindByEmailAsync(request.Email);

        if (user is null)
        {
            throw new UserNotFoundException($"User with {request.Email} not found.");
        }

        var result = await _signInManager.PasswordSignInAsync(user.UserName, request.Password, false, lockoutOnFailure: false);

        if (!result.Succeeded)
        {
            throw new CredentialInvalidException($"Credentials for '{request.Email} aren't valid'.");
        }

        var jwtSecurityToken = await _jwtTokenService.GenerateTokenAsync(user);

        AuthenticationResponse response = new AuthenticationResponse
        {
            Id = user.Id,
            Token = new JwtSecurityTokenHandler().WriteToken(jwtSecurityToken),
            Email = user.Email,
            UserName = user.UserName
        };

        return response;
    }

    public async Task<RegistrationResponse> RegisterAsync(RegistrationRequest request)
    {
        var existingUser = await _userManager.FindByNameAsync(request.UserName);

        if (existingUser != null)
        {
            throw new UserNotFoundException($"Username '{request.UserName}' already exists.");
        }

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

            throw new ValidationException(result.Errors.Select(x => x.Description).ToList());
        }
        else
            throw new UserAlreadyExistsException($"Email {request.Email} already exists.");

    }

}
