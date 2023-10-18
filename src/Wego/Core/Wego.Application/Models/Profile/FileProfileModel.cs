namespace WegoPro.Domain.Profile;


public record FileResponse
{
    public FileResponse()
    {

    }
    public FileResponse(long id, string contentType, byte[] fileData, string name)
    {
        Id = id;
        ContentType = contentType;
        FileData = fileData;
        FileName = name;
    }
    public long Id { get; set; }
    public string ContentType { get; set; }
    public string FileName { get; set; }
    public byte[] FileData { get; set; }
}

