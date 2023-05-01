using Wego.Application.Models.Authentification;

namespace Wego.Application.Contracts.Identity;

public interface IAuthenticationService
{
    Task<AuthenticationResponse> AuthenticateAsync(AuthenticationRequest request);
    Task<RegistrationResponse> RegisterAsync(RegistrationRequest request);
}