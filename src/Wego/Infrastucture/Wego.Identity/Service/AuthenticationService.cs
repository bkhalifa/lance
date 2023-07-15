using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.WebUtilities;
using Microsoft.Extensions.Logging;

using System.Text;
using System.Text.Encodings.Web;

using Wego.Application.Contracts.Common;
using Wego.Application.Contracts.Context;
using Wego.Application.Contracts.Identity;
using Wego.Application.Contracts.Persistence;
using Wego.Application.Exceptions;
using Wego.Application.Models.Authentification;
using Wego.Application.Models.Common;
using Wego.Application.Models.Mail;
using Wego.Domain.Entities;
using Wego.Identity.Helpers;

using YamlDotNet.Core.Tokens;

using static Org.BouncyCastle.Crypto.Engines.SM2Engine;

namespace Wego.Identity.Service;

public class AuthenticationService : IAuthenticationService
{
    private readonly UserManager<ApplicationUser> _userManager;
    private readonly SignInManager<ApplicationUser> _signInManager;
    private readonly IJwtTokenService _jwtTokenService;
    private readonly ILogger<IAuthenticationService> _logger;
    private readonly IEmailSender _emailSender;
    private readonly ICurrentContext _currentContext;
    private readonly IWebSettings _webSettings;
    private readonly IBaseRepository<UserProfile> _profileRepository;
    private readonly IHttpContextAccessor _httpContextAccessor;

    public AuthenticationService(UserManager<ApplicationUser> userManager,
        SignInManager<ApplicationUser> signInManager,
         IJwtTokenService jwtTokenService,
         ILogger<IAuthenticationService> logger,
         IEmailSender emailSender,
         ICurrentContext currentContext,
         IWebSettings webSettings,
         IBaseRepository<UserProfile> profileRepository,
         IHttpContextAccessor httpContextAccessor
         )
    {
        _userManager = userManager;
        _signInManager = signInManager;
        _jwtTokenService = jwtTokenService;
        _logger = logger;
        _emailSender = emailSender;
        _currentContext = currentContext;
        _webSettings = webSettings;
        _profileRepository = profileRepository;
        _httpContextAccessor = httpContextAccessor;
    }

    public async Task<AuthenticationResponse> LoginAsync(AuthenticationRequest request)
    {
        var user = await _userManager.FindByEmailAsync(request.Email);

        if (user is null)
            throw new CredentialInvalidException($"Credentials for '{request.Email} aren't valid'.");

        var result = await _signInManager.PasswordSignInAsync(user.UserName!, request.Password, request.IsPersistent, lockoutOnFailure: false);

        if (!result.Succeeded)
            throw new CredentialInvalidException($"Credentials for '{request.Email} aren't valid'.");


        var jwtSecurityToken = await _jwtTokenService.GenerateTokenAsync(user);

        return new AuthenticationResponse
        {
            Id = user.Id,
            Token = jwtSecurityToken.AccessToken,
            InitialUserName = request.Email.GetInitials(),
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
            Email = request.Email,

        };

        var existingEmail = await _userManager.FindByEmailAsync(user.Email);

        if (existingEmail == null)
        {
            var result = await _userManager.CreateAsync(user, request.Password);
            if (result.Succeeded)
            {
                var code = await _userManager.GenerateEmailConfirmationTokenAsync(user);
       
                var param = new Dictionary<string, string>
                {
                    {"id",  WebEncoders.Base64UrlEncode(Encoding.UTF8.GetBytes(user.Id)) },
                    {"code",  WebEncoders.Base64UrlEncode(Encoding.UTF8.GetBytes(code)) },
                };
                var callback = QueryHelpers.AddQueryString(request.ClientURI!, param);

                await _emailSender.SendMailAsync(new Email(user.Email, "Confirm your Account",
                    $"Please confirm your account by <a href='{HtmlEncoder.Default.Encode(callback)}'>click here</a>."));

                _logger.LogInformation("User Created: {email}", user.Email);

                var resultProfile = await _profileRepository.AddAsync(new UserProfile
                {
                    UserId = user.Id,
                    Email = request.Email,
                    UsId = String.Concat(request.Email.SplitMail(), IdentityHelpers.GetRandomId()),
                    InitialUserName = request.Email.GetInitials(),
                    CreationDate = DateTime.UtcNow,
                    UpdateDate = DateTime.UtcNow,
                });

                return new RegistrationResponse()
                {
                    Email = user.Email!,
                    ConfirmedMail = false,
                    InitialUserName = resultProfile.InitialUserName!
                };
            }

            throw new ValidationException(result.Errors.ToDictionary(x => x.Code, x => x.Description));
        }

        else
            throw new UserAlreadyExistsException($"Email {request.Email} already exists.");

    }
    public async Task<RegistrationResponse> ConfirmRegistration(ConfirmRegisterModel request)
    {
        if (request is null)
            ArgumentNullException.ThrowIfNull(nameof(request));

        var encodedUserId =  Encoding.UTF8.GetString(WebEncoders.Base64UrlDecode(request?.UserId!));
        var user = await _userManager.FindByIdAsync(encodedUserId);

        if (user is null)
            throw new UserNotFoundException($"Email '{_currentContext.Identity.Email}' not found");

        if (user.EmailConfirmed)
            throw new UserNotFoundException($"Email '{_currentContext.Identity.Email}'déja confirmé");

        var encodedCode = Encoding.UTF8.GetString(WebEncoders.Base64UrlDecode(request?.Code!));

        var result = await _userManager.ConfirmEmailAsync(user, encodedCode!).ConfigureAwait(false);

        if (result.Succeeded)
        {
            var resultProfile = await _profileRepository.SingleOrDefaultAsync(x => x.UserId.Equals(encodedUserId)).ConfigureAwait(false);

            if (resultProfile is null)
                throw new UserNotFoundException($"Profile not found .");

            var jwtSecurityToken = await _jwtTokenService.GenerateTokenAsync(user);

            return new RegistrationResponse()
            {
                UserId = user.Id,
                Email = user.Email!,
                ConfirmedMail = true,
                InitialUserName = resultProfile.InitialUserName!,
                ProfileId = resultProfile.Id,
                Token = jwtSecurityToken.AccessToken,
                RefreshToken = jwtSecurityToken.RefreshToken,
            };
        }

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
    public async Task<bool> ForgotPassword([FromBody] ForgotPasswordModel forgotPassword)
    {
        if (forgotPassword is null)
            ArgumentNullException.ThrowIfNull(nameof(forgotPassword));

        var user = await _userManager.FindByEmailAsync(forgotPassword?.Email!);
      
        if (user == null)
            throw new UserNotFoundException($"Email '{_currentContext.Identity.Email}' not found");

        var token = await _userManager.GeneratePasswordResetTokenAsync(user);
        var param = new Dictionary<string, string?>
        {
          {"token", token },
          {"email", forgotPassword!.Email! }
        };
        var callback = QueryHelpers.AddQueryString(forgotPassword.ClientURI!, param);
        await _emailSender.SendMailAsync(new Email(user.Email!, "Reset password token",
                   $"Please confirm your account by <a href='{HtmlEncoder.Default.Encode(callback)}'>click here</a>."));

        return true;

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

}
