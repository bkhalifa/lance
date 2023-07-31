
namespace Wego.HubApi.Models
{
    public class ChatMessageModel
    {
        public long Id { get; set; }
        public string Code { get; set; }
        public int ProfileFromId { get; set; }
        public int ProfileToId { get; set; }

        public string MsgContent { get; set; }

        public bool IsOpen { get; set; }

        public DateTime CreationDate { get; set; }
    }
}
