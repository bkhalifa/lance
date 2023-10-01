namespace Wego.Domain.Common
{
    public class BackGroundResponse
    {
        public BackGroundResponse()
        {

        }
        public BackGroundResponse(long id, string contentType, byte[] bigData, byte[] littleData)
        {
            Id = id;
            ContentType = contentType;
            BigData = bigData;
            LittleData = littleData;
        }
        public long Id { get; set; }
        public string ContentType { get; set; }
        public  string Extension { get; set; }
        public byte[] BigData { get; set; }
        public byte[] LittleData { get; set; }
    }
}
