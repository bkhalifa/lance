using Hellang.Middleware.ProblemDetails;

using Microsoft.AspNetCore.Identity;

using Serilog;

using Wego.Api.Middleware;
using Wego.Application;
using Wego.Application.Models.Authentification;
using Wego.Identity;
using Wego.Identity.Seed;
using Wego.Infrastructure.Extensions;
using Wego.Infrastructure.HealthCheck;
using Wego.Infrastructure.Logging;
using Wego.Persistence;
using Wego.Persistence.EF;

var builder = WebApplication.CreateBuilder(args);

Log.Logger = new LoggerConfiguration()
   .ReadFrom.Configuration(builder.Configuration).CreateBootstrapLogger();
builder.Host.UseLogging(builder.Configuration);


builder.Services.AddDistributedMemoryCache();
builder.Services.AddResponseCompression(options => { options.EnableForHttps = true; });
builder.Services.AddApplicationServices(builder.Configuration);
builder.Services.AddInfrastructureServices(builder.Configuration);
builder.Services.AddPersistenceServices(builder.Configuration);
builder.Services.AddIdentityServices(builder.Configuration);
builder.Services.AddCustomProblemDetails(builder.Environment);
builder.Services.AddCustomHealthCheck(builder.Configuration)
    .AddDbContextCheck<InetDbContext>()
    .AddDbContextCheck<PortoDbContext>();

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddSwagger();
builder.Services.AddCors(options =>
{
    options.AddPolicy("Open", builder => builder.AllowAnyOrigin().AllowAnyHeader().AllowAnyMethod());
});

var app = builder.Build();

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
app.UseCustomHealthCheck();

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
