namespace Wego.Domain.Offers
{
    public class OfferModel
    {
        public long Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string CustomerName { get; set; }
        public decimal? AmountMin { get; set; }
        public decimal? AmountMax { get; set; }
        public string AmountUnit { get; set; }
        public int? Duration { get; set; }
        public string LocationCode { get; set; }
        public string LocationName { get; set; }
        public string ContractTypeCode { get; set; }
        public string SeniorityCode { get; set; }
        public string WorkTypeCode { get; set; }
        public string SkillCodes { get; set; }
        public string SkillNames { get; set; }
        public DateTime? CreatedDate { get; set; }
        public DateTime? PublicationDate { get; set; }
    }
}
