namespace Wego.Domain.OfferProfile
{
    public class ProfileModel
    {
        public long Id { get; set; }
        public string UserId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string Adress { get; set; }
        public int? PhoneNumber { get; set; }
        public bool IsActif { get; set; }
        public bool? IsVisible { get; set; }
        public DateTime CreationDate { get; set; }
        public DateTime UpdateDate { get; set; }
        public string UsId { get; set; }
        public string Country { get; set; }
        public string Region { get; set; }
        public string City { get; set; }
        public string Position { get; set; }
        public string Skills { get; set; }
        public string Comment { get; set; }
        public string Category { get; set; }
        public string ContractType { get; set; }
        public string CategoryType { get; set; }
        public byte[] Picture { get; set; }
        public int Completion { get; set; }
        public string InitialUserName { get; set; }
    }
}
