
namespace Wego.HubApi.Models
{
    public class ChatUserModel
    {
        public long Id { get; set; }

        public long ProfileId { get; set; }

        public string CandidateName { get; set; }

        public string CandidateEmail { get; set; }

        public bool IsConnected { get; set; }
    }
}
