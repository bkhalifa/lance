using Microsoft.AspNetCore.Mvc;

using Wego.Application.Models.Authentification;

namespace Wego.Application.Contracts.Identity;

public interface IAuthenticationService
{
    Task<AuthenticationResponse> LoginAsync(AuthenticationRequest request);
    Task<RegistrationResponse> RegisterAsync(RegistrationRequest request);
    Task LogoutAsync(LogoutModel tokenModel);
    Task<TokenModel> RefreshAsync(TokenModel tokenModel);
    Task<RegistrationResponse> ConfirmRegistration(ConfirmRegisterModel request);
    Task<bool> ForgotPassword([FromBody] ForgotPasswordModel forgotPassword);
}