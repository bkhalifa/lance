namespace Wego.Application.Contracts.Context;

public interface ICurrentContext
{
    Guid RequestId { get; }
    string IpAddress { get; }
    string UserAgent { get; }
    IIdentityContext Identity { get; }
}