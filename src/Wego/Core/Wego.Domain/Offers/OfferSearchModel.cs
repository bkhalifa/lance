namespace Wego.Domain.Offers
{
    public class OfferSearchModel
    {
        public long Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string CustomerName { get; set; }
        public decimal? AmountMax { get; set; }
        public decimal? AmountMin { get; set; }
        public AmountUnitType AmountUnit { get; set; }
        public int? Duration { get; set; }
        public string LocationName { get; set; }
        public string ContractTypeCode { get; set; }
        public string SeniorityCode { get; set; }
        public string WorkTypeCode { get; set; }
        public string SkillNames { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime? PublicationDate { get; set; }
        public int RowCount { get; set; }
    }

    public enum AmountUnitType
    {
        day = 1,
        month = 2,
        year = 3,
    }

    public enum OrderByType
    {
        DateAsc = 1,
        DateDesc = 1,
        Relevance = 3
    }
}
