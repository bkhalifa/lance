using System.ComponentModel.DataAnnotations;

namespace Wego.Application.Models.Authentification
{
    public record ForgotPasswordModel
    {
        [Required]
        [EmailAddress]
        public string? Email { get; set; }
        [Required]
        public string? ClientURI { get; set; }
    }
}
