namespace Wego.Application.Models.Authentification;

public class AuthenticationRequest
{
    public string Email { get; set; }
    public string Password { get; set; }
    public bool IsPersistent { get; set; }
}
