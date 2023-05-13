using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Wego.Application.Features.Offers.Queries
{
    public class GetOfferListByFilterModel
    {
        public long Id { get; set; }
        public string Title { get; set; }
        public string ShortDescription { get; set; }
        public string CustomerName { get; set; }
        public decimal? AmountMax { get; set; }
        public decimal? AmountMin { get; set; }
        public AmountUnitType AmountUnit { get; set; }
        public int? Duration { get; set; }
        public string LocationName { get; set; }
        public string ContractTypeName { get; set; }
        public string CatgeoryName { get; set; }
        public string WorkTypeName { get; set; }
        public int? ExperienceYear { get; set; }
        public string SkillNames { get; set; }
        public string JobLevelName { get; set; }
        public string BusinessSkillName { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime? StartDate { get; set; }
        public int RowCount { get; set; }
    }

    public enum AmountUnitType
    {
        day,
        month,
        year,
        task
    }

    public enum OrderByType
    {
        Date = 1,
        Relevance = 2
    }
}
