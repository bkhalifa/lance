using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.WebUtilities;
using Microsoft.Extensions.Logging;

using System.Text;
using System.Text.Encodings.Web;
using System.Threading;

using Wego.Application.Contracts.Captcha;
using Wego.Application.Contracts.Common;
using Wego.Application.Contracts.Context;
using Wego.Application.Contracts.Identity;
using Wego.Application.Exceptions;
using Wego.Application.IRepo;
using Wego.Application.IService.Feature.Profile;
using Wego.Application.Models.Authentification;
using Wego.Application.Models.Mail;
using Wego.Domain.Profile;
using Wego.Identity.Helpers;

namespace Wego.Identity.Service;

public class AuthenticationService : IAuthenticationService
{
    private readonly UserManager<ApplicationUser> _userManager;
    private readonly SignInManager<ApplicationUser> _signInManager;
    private readonly IJwtTokenService _jwtTokenService;
    private readonly ILogger<IAuthenticationService> _logger;
    private readonly IEmailSender _emailSender;
    private readonly ICurrentContext _currentContext;
    private readonly IProfileService _profileService;
    private readonly ICandidateRepository _candidateRepository;
    private readonly IGoogleCapthaService _googleCaptchaService;

    public AuthenticationService(UserManager<ApplicationUser> userManager,
        SignInManager<ApplicationUser> signInManager,
         IJwtTokenService jwtTokenService,
         ILogger<IAuthenticationService> logger,
         IEmailSender emailSender,
         ICurrentContext currentContext,
         IProfileService profileService,
         ICandidateRepository candidateRepository,
         IGoogleCapthaService googleCaptchaService
         )
    {
        _userManager = userManager;
        _signInManager = signInManager;
        _jwtTokenService = jwtTokenService;
        _logger = logger;
        _emailSender = emailSender;
        _currentContext = currentContext;
        _profileService = profileService;
        _candidateRepository = candidateRepository;
        _googleCaptchaService = googleCaptchaService;
    }

    public async Task<AuthenticationResponse> LoginAsync(AuthenticationRequest request, CancellationToken cancellationToken = default)
    {
        if (request is null)
            ArgumentNullException.ThrowIfNull(nameof(request));

        var user = await _userManager.FindByEmailAsync(request.Email);

        if (user is null)
            throw new UserNotFoundException($"User not found '{request.Email} not found'.");

        var result = await _signInManager.PasswordSignInAsync(user.UserName!, request.Password, request.IsPersistent, true);
        if (result.IsLockedOut)
        {
            await _emailSender.SendMailAsync(new Email(user.Email!, "Account is locked out",
                        $"Your account is locked out. Kindly wait for 10 minutes and try again ."));
            throw new LockedOutException($"account is locked out => '{request.Email} '.");
        }

        if (!result.Succeeded)
            throw new CredentialInvalidException($"Credentials for '{request.Email} aren't valid'.");

        var profile = await _profileService.GetProfileByEmailAsync(request.Email, cancellationToken).ConfigureAwait(false);

        if (profile is null)
            throw new UserNotFoundException($"User profile not found for '{request.Email}.");

        var jwtSecurityToken = await _jwtTokenService.GenerateTokenAsync(user, profile.Id);
        await _candidateRepository.SetConnected(profile.Id, true, cancellationToken);

        return new AuthenticationResponse
        {
            Id = user.Id,
            ProfileId = profile.Id,
            UsId = profile.UsId,
            Token = jwtSecurityToken.AccessToken,
            InitialUserName = request.Email.GetInitials(),
            RefreshToken = jwtSecurityToken.RefreshToken,
            Email = user.Email!
        };
    }
    public async Task<RegistrationResponse> RegisterAsync(RegistrationRequest request, CancellationToken cancellationToken = default)
    {
        if (request is null)
            ArgumentNullException.ThrowIfNull(nameof(request));
        var captchaResult = await _googleCaptchaService.VerifiyToken(request.Token);

        if (!captchaResult)
            throw new GoogleCaptchaException($"captcha '{request}' exception.");

        var existingUser = await _userManager.FindByNameAsync(request!.Email);

        if (existingUser is not null)
            throw new UserAlreadyExistsException($"Email '{request.Email}' already exists.");

        var profile = await _profileService.GetProfileByEmailAsync(request.Email, cancellationToken).ConfigureAwait(false);

        if (profile is not null)
            throw new UserAlreadyExistsException($"Email '{request.Email}' already exists.");

        var user = new ApplicationUser
        {
            UserName = request.Email,
            Email = request.Email,
        };

        var result = await _userManager.CreateAsync(user, request.Password);

        if (result.Succeeded)
        {
            var code = await _userManager.GenerateEmailConfirmationTokenAsync(user);

            var param = new Dictionary<string, string>
                {
                    {"id",    IdentityHelpers.Base64Encode(user.Id) },
                    {"code",  IdentityHelpers.Base64Encode(code) },
                };
            var callback = QueryHelpers.AddQueryString(request.ClientURI!, param);

            await _emailSender.SendMailAsync(new Email(user.Email, "Confirm your Account",
                $"Please confirm your account by <a href='{HtmlEncoder.Default.Encode(callback)}'>click here</a>."));

            _logger.LogInformation("User Created: {email}", user.Email);

            var newProfile = new ProfileModel(user.Id, request.Email);

            var resultProfile = await _profileService.AddProfileInfoAsync(newProfile, cancellationToken);

            await _candidateRepository.AddAsync(new CandidateModel
            {
                ProfileId = resultProfile,
                Email = request.Email,
                IsConnected = false,
                Name = request.Email.Substring(0, request.Email.IndexOf("@"))
            }, cancellationToken);

            return new RegistrationResponse()
            {
                Email = user.Email!,
                ConfirmedMail = false,
                InitialUserName = newProfile.InitialUserName!
            };
        }

        throw new ValidationException(result.Errors.ToDictionary(x => x.Code, x => x.Description));
    }
    public async Task<RegistrationResponse> ConfirmRegistration(ConfirmRegisterModel request, CancellationToken cancellationToken = default)
    {
        if (request is null)
            ArgumentNullException.ThrowIfNull(nameof(request));

        var encodedUserId = IdentityHelpers.Base64Decode(request.UserId);
        var user = await _userManager.FindByIdAsync(encodedUserId);

        if (user is null)
            throw new UserNotFoundException($"Email '{_currentContext.Identity.Email}' not found");

        if (user.EmailConfirmed)
            throw new UserNotFoundException($"Email '{_currentContext.Identity.Email}'déja confirmé");

        var encodedCode = Encoding.UTF8.GetString(WebEncoders.Base64UrlDecode(request?.Code!));

        var result = await _userManager.ConfirmEmailAsync(user, encodedCode!).ConfigureAwait(false);

        if (result.Succeeded)
        {
            var resultProfile = await _profileService.GetProfileByUserIdAsync(encodedUserId, cancellationToken).ConfigureAwait(false);

            if (resultProfile is null)
                throw new UserNotFoundException($"Profile not found .");

            var jwtSecurityToken = await _jwtTokenService.GenerateTokenAsync(user, resultProfile.Id);

            return new RegistrationResponse()
            {
                UserId = user.Id,
                Email = user.Email!,
                UsId = resultProfile?.UsId,
                ConfirmedMail = true,
                InitialUserName = resultProfile.InitialUserName!,
                ProfileId = resultProfile.Id,
                Token = jwtSecurityToken.AccessToken,
                RefreshToken = jwtSecurityToken.RefreshToken
            };
        }

        throw new ValidationException(result.Errors.ToDictionary(x => x.Code, x => x.Description));
    }
    public async Task LogoutAsync(LogoutModel logoutModel, CancellationToken cancellationToken = default)
    {
        var user = await _userManager.FindByEmailAsync(logoutModel.Email);
        if (user == null) throw new UserNotFoundException($"Email '{_currentContext.Identity.Email}' not found");

        var profile = await _profileService.GetProfileByEmailAsync(logoutModel.Email, cancellationToken).ConfigureAwait(false);
        await _candidateRepository.SetConnected(profile.Id, false, cancellationToken);

        await _signInManager.SignOutAsync();
        await _userManager.UpdateSecurityStampAsync(user);
        await _userManager.RemoveAuthenticationTokenAsync(user, "JWT", "JWT Token");
    }
    public async Task<bool> ForgotPassword([FromBody] ForgotPasswordModel forgotPassword)
    {
        if (forgotPassword is null)
            ArgumentNullException.ThrowIfNull(nameof(forgotPassword));

        var captchaResult = await _googleCaptchaService.VerifiyToken(forgotPassword.Token);

        if (!captchaResult)
            throw new GoogleCaptchaException($"captcha '{captchaResult}' exception.");

        var user = await _userManager.FindByEmailAsync(forgotPassword?.Email!);

        if (user == null)
            throw new UserNotFoundException($"Email '{_currentContext.Identity.Email}' not found");

        var token = await _userManager.GeneratePasswordResetTokenAsync(user);
        var param = new Dictionary<string, string?>
        {
          {"token",WebEncoders.Base64UrlEncode(Encoding.UTF8.GetBytes(token))},
          {"email", forgotPassword!.Email! }
        };
        var callback = QueryHelpers.AddQueryString(forgotPassword.ClientURI!, param);
        await _emailSender.SendMailAsync(new Email(user.Email!, "Reset password token",
                   $"Please confirm your account by <a href='{HtmlEncoder.Default.Encode(callback)}'>click here</a>."));

        return true;

    }
    public async Task<RegistrationResponse> ResetRegistration(ResetPasswordModel request, CancellationToken cancellationToken = default)
    {
        if (request is null)
            ArgumentNullException.ThrowIfNull(nameof(request));

        var captchaResult = await _googleCaptchaService.VerifiyToken(request.TokenCaptcha);

        if (!captchaResult)
            throw new GoogleCaptchaException($"captcha '{request}' exception.");

        var user = await _userManager.FindByEmailAsync(request.Email);

        if (user == null)
            throw new UserNotFoundException($"user not found .");

        var encodedCode = Encoding.UTF8.GetString(WebEncoders.Base64UrlDecode(request.Token!));

        var result = await _userManager.ResetPasswordAsync(user, encodedCode, request.Password);
        if (result.Succeeded)
        {
            if (user.EmailConfirmed == false)
            {
                var code = await _userManager.GenerateEmailConfirmationTokenAsync(user);
                await _userManager.ConfirmEmailAsync(user, code);
            }

            await _emailSender.SendMailAsync(new Email(user.Email!, "Reset Password Ok",
           "Reset Password are Ok !"));

            var resultProfile = await _profileService.GetProfileByEmailAsync(request.Email, cancellationToken).ConfigureAwait(false);

            if (resultProfile is null)
                throw new UserNotFoundException($"Profile not found .");

            var jwtSecurityToken = await _jwtTokenService.GenerateTokenAsync(user, resultProfile.Id);

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

        return default!;

    }
    public async Task<TokenModel> RefreshAsync(TokenModel tokenModel, CancellationToken cancellationToken = default)
    {
        var principal = _jwtTokenService.GetPrincipalFromExpiredToken(tokenModel.AccessToken);
        if (principal is null) throw new UserNotAuthentificatedException("User not Authentificated");

        var userName = principal.Claims.FirstOrDefault()?.Value;

        if (string.IsNullOrEmpty(userName)) throw new UserNotAuthentificatedException("User not Authentificated");

        var user = await _userManager.FindByEmailAsync(userName);
        if (user == null) throw new UserNotFoundException($"Email '{_currentContext.Identity.Email}' not found");

        var profile = await _profileService.GetProfileByEmailAsync(user.Email, cancellationToken).ConfigureAwait(false);
        if (profile is null)
            throw new UserNotFoundException($"User profile not found for '{user.Email}.");

        return await _jwtTokenService.GenerateTokenAsync(user, profile.Id);
    }


    

}
