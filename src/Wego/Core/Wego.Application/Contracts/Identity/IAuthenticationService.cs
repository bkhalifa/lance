using Microsoft.AspNetCore.Mvc;

using Wego.Application.Models.Authentification;

namespace Wego.Application.Contracts.Identity;

public interface IAuthenticationService
{
    Task<AuthenticationResponse> LoginAsync(AuthenticationRequest request, CancellationToken cancellationToken);
    Task<RegistrationResponse> RegisterAsync(RegistrationRequest request, CancellationToken cancellationToken);
    Task LogoutAsync(LogoutModel tokenModel);
    Task<TokenModel> RefreshAsync(TokenModel tokenModel, CancellationToken cancellationToken);
    Task<RegistrationResponse> ConfirmRegistration(ConfirmRegisterModel request, CancellationToken cancellationToken);
    Task<bool> ForgotPassword([FromBody] ForgotPasswordModel forgotPassword);
    Task<RegistrationResponse> ResetRegistration(ResetPasswordModel request, CancellationToken cancellationToken);
}