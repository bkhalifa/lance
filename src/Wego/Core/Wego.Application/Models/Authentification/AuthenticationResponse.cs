namespace Wego.Application.Models.Authentification;

public class AuthenticationResponse
{
    public string Id { get; set; }
    public long ProfileId { get; set; }
    public string Email { get; set; }
    public string Token { get; set; }
    public  string InitialUserName { get; set; }
    public string RefreshToken { get; set; }
}
