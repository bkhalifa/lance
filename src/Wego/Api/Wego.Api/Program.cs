using Hellang.Middleware.ProblemDetails;

using Serilog;

using Wego.Api.Middleware;
using Wego.Application;
using Wego.Identity;
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
    options.AddPolicy(name: "_tekoPolicy",
                      policy =>
                      {
                          policy.WithOrigins("http://localhost:4200",
                                              "http://www.tekojob.com")
                                              .AllowAnyHeader()
                                              .AllowAnyMethod()
                                              .SetIsOriginAllowed(origin => true) // allow any origin
                                              .AllowCredentials(); // allow credentials
                      });
});

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseSerilogRequestLogging();
app.UseHttpsRedirection();
app.UseCors("_tekoPolicy");

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


app.UseAuthorization();
app.MapControllers();
app.UseCustomHealthCheck();

app.Run();
