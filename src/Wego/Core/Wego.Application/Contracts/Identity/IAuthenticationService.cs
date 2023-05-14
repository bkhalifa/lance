using Wego.Application.Models.Authentification;

namespace Wego.Application.Contracts.Identity;

public interface IAuthenticationService
{
    Task<AuthenticationResponse> LoginAsync(AuthenticationRequest request);
    Task<RegistrationResponse> RegisterAsync(RegistrationRequest request);
    Task<bool> ChangePasswordAsync(string oldPassword, string newPassword);
    Task LogoutAsync();
    Task<TokenModel> RefreshAsync(string refreshToken);
}