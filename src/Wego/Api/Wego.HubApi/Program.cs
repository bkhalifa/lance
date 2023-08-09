using Microsoft.EntityFrameworkCore;
using Serilog;
using Wego.HubApi.Extensions;
using Wego.HubApi.Hubs;
using Wego.HubApi.Middlewares;
using Wego.HubApi.Persistence;
using Wego.HubApi.Services;

var builder = WebApplication.CreateBuilder(args);

Log.Logger = new LoggerConfiguration()
   .ReadFrom.Configuration(builder.Configuration).CreateBootstrapLogger();
builder.Host.UseLogging(builder.Configuration, "NotificationHub");

builder.Services.AddDistributedMemoryCache();
builder.Services.AddResponseCompression(options => { options.EnableForHttps = true; });
builder.Services.AddHttpContextAccessor();
builder.Services.AddControllers();
builder.Services.AddSignalR();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddCors(options =>
{
    options.AddPolicy("Open", builder => builder.AllowAnyOrigin().AllowAnyHeader().AllowAnyMethod());
});
builder.Services.AddDbContext<PortoDbContext>(options =>
           options.UseSqlServer(builder.Configuration.GetConnectionString("PortoDb")));
builder.Services.AddScoped<IChatService, ChatService>();

var app = builder.Build();

//if (app.Environment.IsDevelopment())
//{
app.UseSwagger();
app.UseSwaggerUI();
//}

app.UseCustomExceptionHandler();
app.UseSerilogRequestLogging();
app.UseHttpsRedirection();
app.UseRouting();
app.UseSecureHttpHeader();
app.UseResponseCompression();

app.UseCors("Open");
app.MapControllers();
app.MapHub<ChatHub>("/hubs/chat");

app.Run();