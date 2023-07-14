namespace Wego.Application.Models.Authentification
{
    public record ConfirmRegisterModel
    {
        public string? UserId { get; set; }
        public string? Code { get; set; }

    }
}
