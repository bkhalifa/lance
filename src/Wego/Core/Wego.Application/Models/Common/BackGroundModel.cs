namespace Wego.Application.Models.Common
{
    public class BackGroundModel
    {
        public long Id { get; set; }
        public long ParentId { get; set; }
        public long ProfileId { get; set; }
        public string FileName { get; set; }
        public string ContentType { get; set; }
        public string FileBase64 { get; set; }
        public int Width { get; set; }
        public int Height { get; set; }
        public DateTime? CreationDate { get; set; }
        public bool FileType { get; set; }
    }
}
