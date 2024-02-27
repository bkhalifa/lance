namespace Wego.Application.Models.Profile.request;

public record ProfileInfoRequest
{
    public long Id { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public int? PhoneNumber { get; set; }
    public DateTime? UpdateDate { get; set; }
    public string Position { get; set; }
    public int CountryId { get; set; }
    public string LinkedInLink { get; set; }
}
