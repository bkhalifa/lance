using Microsoft.AspNetCore.Identity;

namespace Wego.Application.Models.Authentification
{
    public class ApplicationUser : IdentityUser
    {
        public Byte[]? Picture { get; set; }
    }
}
