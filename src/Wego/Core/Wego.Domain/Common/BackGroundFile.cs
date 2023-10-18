namespace Wego.Domain.Common
{
    public class BackGroundFile
    {
        public long Id { get; set; }
        public long ParentId { get; set; }
        public string Extension { get; set; }
        public string ContentType { get; set; }
        public string FileName { get; set; }
        public int Size { get; set; }
        public byte[] LittleData { get; set; }
        public byte[] BigData { get; set; }
        public int Width { get; set; }
        public int Height { get; set; }
        public DateTime? CreationDate { get; set; }
        public DateTime? UpDateDate { get; set; }
        public bool? FileType { get; set; }
        public long? ProfileId { get; set; }

    }
}
