using MediatR;
using Microsoft.Extensions.Logging;

using System.Diagnostics.CodeAnalysis;

namespace Wego.Application.Behaviours;
[ExcludeFromCodeCoverage]
public class UnhandledExceptionBehaviour<TRequest, TResponse> : IPipelineBehavior<TRequest, TResponse>
    where TRequest : IRequest<TResponse>
    where TResponse : notnull
{
    private readonly ILogger<TRequest> _logger;
    public UnhandledExceptionBehaviour(ILogger<TRequest> logger)
    {
        _logger = logger;

    }

    public async Task<TResponse> Handle(TRequest request, RequestHandlerDelegate<TResponse> next, CancellationToken cancellationToken)
    {
        var requestName = typeof(TRequest).Name;
        try
        {
            return await next();
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Unhandled exception for request: {Name} {@Request}",
                requestName, request);
            throw;
        }
    }
}