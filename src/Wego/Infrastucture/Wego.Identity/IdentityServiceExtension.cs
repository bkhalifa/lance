using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;

using Newtonsoft.Json;

using System.Text;

using Wego.Application.Contracts.Identity;
using Wego.Application.Models.Authentification;
using Wego.Identity.Service;

namespace Wego.Identity;

public static class IdentityServiceExtensions
{
    public static void AddIdentityServices(this IServiceCollection services, IConfiguration configuration)
    {
        services.Configure<JwtSettings>(configuration.GetSection("JwtSettings"));

        services.AddDbContext<InetDbContext>(options => options.UseSqlServer(configuration.GetConnectionString("Inet"),
            b => b.MigrationsAssembly(typeof(InetDbContext).Assembly.FullName)));

        services.AddIdentity<ApplicationUser, IdentityRole>(options =>
           {
               // Password settings  
               options.Password.RequiredLength = 6;
               options.Password.RequireLowercase = false;
               options.Password.RequireUppercase = false;
               options.Password.RequireNonAlphanumeric = false;
               options.Password.RequireDigit = true;
               // Lockout settings  
               options.Lockout.MaxFailedAccessAttempts = 10;
               options.Lockout.AllowedForNewUsers = false;

               // Signin settings  
               options.SignIn.RequireConfirmedEmail = true;

           })
          .AddEntityFrameworkStores<InetDbContext>()
          .AddDefaultTokenProviders();
        services.Configure<DataProtectionTokenProviderOptions>(opt =>
      opt.TokenLifespan = TimeSpan.FromHours(2));

        services.AddScoped<IAuthenticationService, AuthenticationService>();
        services.AddTransient<IJwtTokenService, JwtTokenService>();

        services.AddAuthentication(options =>
        {
            options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
            options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            options.DefaultScheme = JwtBearerDefaults.AuthenticationScheme;
        })// Adding Jwt Bearer
         .AddJwtBearer(options =>
         {
             options.SaveToken = true;
             options.RequireHttpsMetadata = false;
             options.TokenValidationParameters = new TokenValidationParameters()
             {
                 ValidateIssuer = true,
                 ValidateAudience = true,
                 ValidateLifetime = true,
                 ValidateIssuerSigningKey = true,
                 ClockSkew = TimeSpan.Zero,

                 ValidIssuer = configuration["JwtSettings:Issuer"],
                 ValidAudience = configuration["JwtSettings:Audience"],
                 IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(configuration["JwtSettings:Key"]))
             };
         });
    }
}
