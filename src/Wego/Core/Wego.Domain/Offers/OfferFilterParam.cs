

namespace Wego.Domain.Offers
{
    public class OfferFilterParam
    {

        public string Query { get; set; }
        public string Locations { get; set; }
        public string Skills { get; set; }
        public string Seniorities { get; set; }
        public string ContractTypes { get; set; }
        public string Categories { get; set; }
        public string WorkTypes { get; set; }
        public OrderByType? OrderBy { get; set; }
        public decimal? SalaryMin { get; set; }
        public decimal? DailyRateMin { get; set; }
        public int PageIndex { get; set; } = 1;
        public int PageSize { get; set; } = 10;
    }
}
