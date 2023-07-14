namespace Wego.Application.Models.Authentification
{
    public record RegisterResponse
    {
        public string Email { get; set; }
        public bool ConfirmedMail { get; set; } = false;

    }
}
