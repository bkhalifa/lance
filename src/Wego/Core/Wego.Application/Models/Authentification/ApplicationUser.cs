using Microsoft.AspNetCore.Identity;

namespace Wego.Application.Models.Authentification
{
    public class ApplicationUser : IdentityUser
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
    }
}
