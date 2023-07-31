using Hellang.Middleware.ProblemDetails;

using Serilog;

using System.Threading.RateLimiting;

using Wego.Api.Middleware;
using Wego.Application;
using Wego.Identity;
using Wego.Infrastructure.Extensions;
using Wego.Infrastructure.HealthCheck;
using Wego.Infrastructure.Logging;
using Wego.Persistence;
using Wego.Persistence.EF;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddRateLimiter(options =>
{
    options.GlobalLimiter = PartitionedRateLimiter.Create<HttpContext, string>(httpContext =>
        RateLimitPartition.GetFixedWindowLimiter(
            partitionKey: httpContext.User.Identity?.Name ?? httpContext.Request.Headers.Host.ToString(),
            factory: partition => new FixedWindowRateLimiterOptions
            {
                AutoReplenishment = true,
                PermitLimit = 600,
                QueueLimit = 0,
                Window = TimeSpan.FromMinutes(1),
            }));
    options.RejectionStatusCode = 429;
    options.OnRejected = async (context, token) =>
    {
        context.HttpContext.Response.StatusCode = 429;
        if (context.Lease.TryGetMetadata(MetadataName.RetryAfter, out var retryAfter))
        {
            await context.HttpContext.Response.WriteAsync(
                $"Too many requests. Please try again after {retryAfter.TotalMinutes} minute(s). " +
                $"...", cancellationToken: token);
        }
        else
        {
            await context.HttpContext.Response.WriteAsync(
                "Too many requests. Please try again later. " +
                "...", cancellationToken: token);
        }
    };

});
Log.Logger = new LoggerConfiguration()
   .ReadFrom.Configuration(builder.Configuration).CreateBootstrapLogger();
builder.Host.UseLogging(builder.Configuration,"WegoApi");

builder.Services.AddHttpContextAccessor();
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
builder.Services.AddSwagger("WegoApi");

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

//if (app.Environment.IsDevelopment())
//{
//    app.UseSwagger();
//    app.UseSwaggerUI();
//}

app.UseSerilogRequestLogging();
app.UseHttpsRedirection();
app.UseCors("_tekoPolicy");

app.UseProblemDetails();
app.UseRouting();
app.UseRateLimiter();
app.UseAuthentication();
app.UseSwagger();
app.UseSwaggerUI(c =>
{
    c.SwaggerEndpoint("../swagger/v1/swagger.json", "Wego Api");
});

app.UseResponseCompression();


app.UseAuthorization();
app.MapControllers();
app.UseCustomHealthCheck();
app.UseSecureHttpHeader();

app.Run();
