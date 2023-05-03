using Microsoft.AspNetCore.Identity;
using Wego.Application.Models.Authentification;

namespace Wego.Identity.Seed;

 public static class UserCreator
{
    public static async Task SeedAsync(UserManager<ApplicationUser> userManager)
    {
        var applicationUser = new ApplicationUser
        {
            FirstName = "BB",
            LastName = "King",
            UserName = "BBking",
            Email = "BBking@test.fr",
            EmailConfirmed = true
        };

        var user = await userManager.FindByEmailAsync(applicationUser.Email);
        if (user is null)
        {
            await userManager.CreateAsync(applicationUser, "Admin123@");
        }
    }
}



