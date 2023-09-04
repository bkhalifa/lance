namespace Wego.Application.Contracts.Context;

public interface IIdentityContext
{
    bool IsAuthenticated { get; }
    public string Email { get; }
    public string UserId { get; }
    public long ProfileId { get; }
    IEnumerable<string> Roles { get; }
    Dictionary<string, IEnumerable<string>> Claims { get; }
}