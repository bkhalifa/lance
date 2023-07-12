namespace Wego.Application.Models.Authentification
{
    public record RegistrationResponse
    {
        public string Email { get; set; } 
        public string UserId { get; set; }
        public  bool ConfirmedMail { get; set; }
        public string InitialUserName { get; set; }
        public long ProfileId { get; set; }
    }
}
