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

        services.AddIdentity<ApplicationUser, IdentityRole>()
                .AddEntityFrameworkStores<InetDbContext>()
                .AddDefaultTokenProviders();

        services.AddTransient<IAuthenticationService, AuthenticationService>();
        services.AddScoped<IJwtTokenService, JwtTokenService>();

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
