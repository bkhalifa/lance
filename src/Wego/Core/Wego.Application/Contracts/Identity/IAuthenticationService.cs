using Wego.Application.Models.Authentification;

namespace Wego.Application.Contracts.Identity;

public interface IAuthenticationService
{
    Task<AuthenticationResponse> LoginAsync(AuthenticationRequest request);
    Task<RegistrationResponse> RegisterAsync(RegistrationRequest request);
    Task<bool> ChangePasswordAsync(string oldPassword, string newPassword);
    Task LogoutAsync(LogoutModel tokenModel);
    Task<TokenModel> RefreshAsync(TokenModel tokenModel);
    Task<RegistrationResponse> ConfirmRegistration(ConfirmRegisterModel request);
}