namespace Wego.Application.Models.Authentification
{
    public record TokenModel
    {
        public string AccessToken { get; set; }
        public string RefreshToken { get; set; }
    }
}
