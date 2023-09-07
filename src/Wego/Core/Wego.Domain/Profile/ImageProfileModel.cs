namespace Wego.Domain.Profile;


public record ImageProfileResponse
{
    public long FileId { get; set; }
    public string ContentType { get; set; }
    public byte[] ImageData { get; set; }

}

