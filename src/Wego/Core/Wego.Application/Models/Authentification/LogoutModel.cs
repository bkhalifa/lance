namespace Wego.Application.Models.Authentification
{
    public record LogoutModel
    {
        public string Email { get; set; } 
        public string UserId { get; set; }
        public string AccessToken { get; set; }
        public string RefreshToken { get; set; }
    }
}
