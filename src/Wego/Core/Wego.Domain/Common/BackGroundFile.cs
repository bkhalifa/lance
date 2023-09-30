namespace Wego.Domain.Common
{
    public class BackGroundFile
    {
        public long Id { get; set; }
        public long ParentId { get; set; }
        public long ProfileId { get; set; }
        public string FileName { get; set; }
        public string ContentType { get; set; }
        public byte[] BigData { get; set; }
        public byte[] LittleData { get; set; }
        public int Width { get; set; }
        public int Height { get; set; }
        public DateTime? CreationDate { get; set; }
        public bool FileType { get; set; }

    }
}
