
namespace Wego.Application.Models.Profile;

public record ProfileInfoResponse
{
    public long Id { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string InitialUserName { get; set; }
    public string Email { get; set; }
    public int? PhoneNumber { get; set; }
    public DateTime? UpdateDate { get; set; }
    public string UsId { get; private set; }
    public string Position { get; set; }
    public long fileId { get; set; }
}
