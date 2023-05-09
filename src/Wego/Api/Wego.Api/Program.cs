


using Hellang.Middleware.ProblemDetails;
using Microsoft.AspNetCore.Identity;

using Serilog;

using Wego.Api.Middleware;
using Wego.Api.Services;
using Wego.Application;
using Wego.Application.Contracts;
using Wego.Application.Extensions;
using Wego.Application.LogEnrichers;
using Wego.Application.Models.Authentification;
using Wego.Identity;
using Wego.Identity.Seed;
using Wego.Persistence;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddSwagger();
builder.Services.AddDistributedMemoryCache();
builder.Services.AddResponseCompression(options => { options.EnableForHttps = true; });
builder.Services.AddApplicationServices();
builder.Services.AddPersistenceServices(builder.Configuration);
builder.Services.AddIdentityServices(builder.Configuration);
builder.Services.AddCustomProblemDetails(builder.Environment);
builder.Services.AddScoped<ILoggedInUserService, LoggedInUserService>();

builder.Services.AddCors(options =>
{
    options.AddPolicy("Open", builder => builder.AllowAnyOrigin().AllowAnyHeader().AllowAnyMethod());
});

Log.Logger = new LoggerConfiguration()
   .ReadFrom.Configuration(builder.Configuration).CreateBootstrapLogger();

builder.Host.UseSerilogConfiguration(builder.Configuration);

var app = builder.Build();


// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseSerilogRequestLogging();
app.UseHttpsRedirection();
app.UseProblemDetails();
app.UseRouting();
app.UseAuthentication();

app.UseSwagger();
app.UseSwaggerUI(c =>
{
    c.SwaggerEndpoint("../swagger/v1/swagger.json", "Wego API");
});

app.UseResponseCompression();
app.UseSerilogRequestLogging();

app.UseCors("Open");
app.UseAuthorization();

app.MapControllers();

using (var scope = app.Services.CreateScope())
{
    var services = scope.ServiceProvider;
    var loggerFactory = services.GetRequiredService<ILoggerFactory>();

    try
    {
        var userManager = services.GetRequiredService<UserManager<ApplicationUser>>();
        await UserCreator.SeedAsync(userManager);
        Log.Information("Application Starting");
    }
    catch (Exception ex)
    {
        Log.Warning(ex, "An error occured while starting the application");
    }
}

app.Run();
