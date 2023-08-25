using System.ComponentModel.DataAnnotations;

namespace Wego.Application.Models.Authentification;

public record ForgotPasswordModel
{
    [Required]
    [EmailAddress]
    public string? Email { get; set; }
    public string Token { get; set; }
    [Required]
    public string? ClientURI { get; set; }
}
