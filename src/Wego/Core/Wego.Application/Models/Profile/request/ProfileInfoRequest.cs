namespace Wego.Application.Models.Profile.request;

public record ProfileInfoRequest
{
    public long Id { get; set; } = 0;
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public int? PhoneNumber { get; set; }
    public string Position { get; set; }
    public int CountryId { get; set; }
    public string LinkedInLink { get; set; }
    public string RegionCode { get; set; }
}
