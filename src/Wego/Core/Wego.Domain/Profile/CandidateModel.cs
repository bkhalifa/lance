namespace Wego.Domain.Profile
{
    public class CandidateModel
    {
        public long ProfileId { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public bool IsConnected { get; set; }
        public string ConnectionId { get; set; }
        public DateTime CreationDate { get; set; }
        public DateTime UpdateDate { get; set; }
    }
}
