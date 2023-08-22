using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.WebUtilities;
using Microsoft.Extensions.Logging;

using System.Security.Policy;
using System.Text;
using System.Text.Encodings.Web;

using Wego.Application.Contracts.Common;
using Wego.Application.Contracts.Context;
using Wego.Application.Contracts.Identity;
using Wego.Application.Contracts.Infrastructure.Captcha;
using Wego.Application.Contracts.Persistence;
using Wego.Application.Exceptions;
using Wego.Application.Models.Authentification;
using Wego.Application.Models.Mail;
using Wego.Domain.Entities;
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
    private readonly IBaseRepository<UserProfile> _profileRepository;
    private readonly IBaseRepository<Candidate> _candidateRepository;
    private readonly IGoogleCapthaService _googleCaptchaService;

    public AuthenticationService(UserManager<ApplicationUser> userManager,
        SignInManager<ApplicationUser> signInManager,
         IJwtTokenService jwtTokenService,
         ILogger<IAuthenticationService> logger,
         IEmailSender emailSender,
         ICurrentContext currentContext,
         IBaseRepository<UserProfile> profileRepository,
         IBaseRepository<Candidate> candidateRepository,
         IGoogleCapthaService googleCaptchaService
         )
    {
        _userManager = userManager;
        _signInManager = signInManager;
        _jwtTokenService = jwtTokenService;
        _logger = logger;
        _emailSender = emailSender;
        _currentContext = currentContext;
        _profileRepository = profileRepository;
        _candidateRepository = candidateRepository;
        _googleCaptchaService = googleCaptchaService;
    }

    public async Task<AuthenticationResponse> LoginAsync(AuthenticationRequest request)
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

        var profile = await _profileRepository.FirstOrDefaultAsync(x => x.Email == request.Email).ConfigureAwait(false);
        if (profile is null)
            throw new UserNotFoundException($"User profile not found for '{request.Email}.");

        var jwtSecurityToken = await _jwtTokenService.GenerateTokenAsync(user);

        return new AuthenticationResponse
        {
            Id = user.Id,
            ProfileId = profile.Id,
            Token = jwtSecurityToken.AccessToken,
            InitialUserName = request.Email.GetInitials(),
            RefreshToken = jwtSecurityToken.RefreshToken,
            Email = user.Email!
        };
    }
    public async Task<RegistrationResponse> RegisterAsync(RegistrationRequest request)
    {
        if (request is null)
            ArgumentNullException.ThrowIfNull(nameof(request));

        var captchaResult = await _googleCaptchaService.VerifiyToken(request.Token);

        //if (!captchaResult)
        //    throw new CaptchaException($"Captcha Exception {captchaResult}"); 

        var existingUser = await _userManager.FindByNameAsync(request!.Email);

        if (existingUser is not null)
            throw new UserAlreadyExistsException($"Email '{request.Email}' already exists.");

        var profile = await _profileRepository.FirstOrDefaultAsync(x => x.Email == request.Email);

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

            var resultProfile = await _profileRepository.AddAsync(new UserProfile
            {
                UserId = user.Id,
                Email = request.Email,
                UsId = string.Concat(request.Email.SplitMail(), IdentityHelpers.GetRandomId()),
                InitialUserName = request.Email.GetInitials(),
                CreationDate = DateTime.UtcNow,
                UpdateDate = DateTime.UtcNow,
            });

            await _candidateRepository.AddAsync(new Candidate
            {
                CandidateEmail = request.Email,
                CandidateName = request.Email.Substring(0,request.Email.IndexOf("@")),
                IsConnected = false,
                ProfileId = resultProfile.Id,
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

    public async Task<RegistrationResponse> ConfirmRegistration(ConfirmRegisterModel request)
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
            var resultProfile = await _profileRepository.FirstOrDefaultAsync(x => x.UserId.Equals(encodedUserId)).ConfigureAwait(false);

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
                RefreshToken = jwtSecurityToken.RefreshToken
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
          {"token",WebEncoders.Base64UrlEncode(Encoding.UTF8.GetBytes(token))},
          {"email", forgotPassword!.Email! }
        };
        var callback = QueryHelpers.AddQueryString(forgotPassword.ClientURI!, param);
        await _emailSender.SendMailAsync(new Email(user.Email!, "Reset password token",
                   $"Please confirm your account by <a href='{HtmlEncoder.Default.Encode(callback)}'>click here</a>."));

        return true;

    }
    public async Task<RegistrationResponse> ResetRegistration(ResetPasswordModel request)
    {
        if (request is null)
            ArgumentNullException.ThrowIfNull(nameof(request));

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
           $"Reset Password are Ok !"));

            var resultProfile = await _profileRepository.FirstOrDefaultAsync(x => x.Email.Equals(request.Email)).ConfigureAwait(false);

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

        return default!;

    }
    public async Task<TokenModel> RefreshAsync(TokenModel tokenModel)
    {
        var principal = _jwtTokenService.GetPrincipalFromExpiredToken(tokenModel.AccessToken);
        if (principal is null) throw new UserNotAuthentificatedException("User not Authentificated");

        var userName = principal.Claims.FirstOrDefault()?.Value;

        if (string.IsNullOrEmpty(userName)) throw new UserNotAuthentificatedException("User not Authentificated");

        var user = await _userManager.FindByEmailAsync(userName);
        if (user == null) throw new UserNotFoundException($"Email '{_currentContext.Identity.Email}' not found");

        var profile = await _profileRepository.FirstOrDefaultAsync(x => x.Email == user.Email).ConfigureAwait(false);
        if (profile is null)
            throw new UserNotFoundException($"User profile not found for '{user.Email}.");

        return await _jwtTokenService.GenerateTokenAsync(user);
    }

}
