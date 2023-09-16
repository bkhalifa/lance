namespace Wego.Domain.Profile;


public class ImageProfileResponse
{
    public ImageProfileResponse()
    {
        
    }
    public ImageProfileResponse(long id, string contentType, byte[] imageData)
    {
        Id = id;
        ContentType = contentType;
        ImageData = imageData;
    }
    public long Id { get; set; }
    public string ContentType { get; set; }
    public byte[] ImageData { get; set; }
}


