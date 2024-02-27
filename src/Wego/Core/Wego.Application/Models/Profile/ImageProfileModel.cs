namespace Wego.Application.Models.Profile
{
    public record ImageProfileModel
    {
        public long ProfileId { get; set; }
        public byte[] Base64 { get; set; }
        public string ContentType { get; set; }
        public int Width { get; set; }
        public int Height { get; set; }
    }
}
