namespace Wego.Domain.Profile;

public class ProfileModel
{
    public long Id { get; set; }
    public string UserId { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string InitialUserName { get; set; }
    public string Email { get; set; }
    public string? PhoneNumber { get; set; }
    public DateTime CreationDate { get; set; }
    public DateTime? UpdateDate { get; set; }
    public string UsId { get; set; }
    public string Position { get; set; }
    public string Skills { get; set; }
}
