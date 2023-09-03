namespace Wego.Domain.Profile;


public record ImageProfileResponse
{
    public string ContentType { get; set; }
    public byte[] ImageData { get; set; }

}

