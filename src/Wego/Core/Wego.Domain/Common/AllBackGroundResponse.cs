namespace Wego.Domain.Common
{
    public record AllBackGroundResponse
    {
        public long Id { get; set; }
        public long ParentId { get; set; }
        public string FileName { get; set; }
        public string Extension { get; set; }
        public long ProfileId { get; set; }
    }
}
