namespace Wego.Application.Models.Authentification
{
    public record TokenModel
    {
        public string AccessToken { get; set; }
        public string RefreshToken { get; set; }
        public string InitialUserName { get; set; }
        public string Email { get; set; }

    }
}
