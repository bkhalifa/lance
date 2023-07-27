using Microsoft.Extensions.DependencyInjection;
using Microsoft.OpenApi.Models;
using Swashbuckle.AspNetCore.SwaggerGen;

namespace Wego.Infrastructure.Extensions
{
    public static class SwaggerExtension
    {
        public static void AddSwagger(this IServiceCollection services, string title)
        {
            services.AddSwaggerGen(c =>
            {
                c.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
                {
                    Description = @"JWT Authorization header using the Bearer scheme. \r\n\r\n 
                      Enter 'Bearer' [space] and then your token in the text input below.
                      \r\n\r\nExample: 'Bearer 12345abcdef'",
                    Name = "Authorization",
                    In = ParameterLocation.Header,
                    Type = SecuritySchemeType.ApiKey,
                    Scheme = "Bearer"
                });

                c.AddSecurityRequirement(new OpenApiSecurityRequirement()
                  {
                    {
                      new OpenApiSecurityScheme
                      {
                        Reference = new OpenApiReference
                          {
                            Type = ReferenceType.SecurityScheme,
                            Id = "Bearer"
                          },
                          Scheme = "oauth2",
                          Name = "Bearer",
                          In = ParameterLocation.Header,

                        },
                        new List<string>()
                      }
                    });

                c.SwaggerDoc("v1", new OpenApiInfo
                {
                    Version = "v1",
                    Title = title,

                });

                c.OperationFilter<FileResultContentTypeOperationFilter>();
            });
        }

    }
}

[AttributeUsage(AttributeTargets.Method)]
public class FileResultContentTypeAttribute : Attribute
{
    public FileResultContentTypeAttribute(string contentType)
    {
        ContentType = contentType;
    }

    public string ContentType { get; }
}

public class FileResultContentTypeOperationFilter : IOperationFilter
{
    public void Apply(OpenApiOperation operation, OperationFilterContext context)
    {
        var requestAttribute = context.MethodInfo.GetCustomAttributes(typeof(FileResultContentTypeAttribute), false)
            .Cast<FileResultContentTypeAttribute>()
            .FirstOrDefault();

        if (requestAttribute == null) return;

        operation.Responses.Clear();
        operation.Responses.Add("200", new OpenApiResponse
        {
            Content = new Dictionary<string, OpenApiMediaType>
            {
                {
                    requestAttribute.ContentType, new OpenApiMediaType
                    {
                        Schema = new OpenApiSchema
                        {
                            Type = "string",
                            Format = "binary"
                        }
                    }
                }
            }
        });
    }
}
