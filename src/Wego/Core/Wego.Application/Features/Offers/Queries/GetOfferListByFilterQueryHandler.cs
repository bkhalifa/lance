
using MediatR;
using Microsoft.Data.SqlClient;
using Wego.Application.Contracts.Persistence;
using Wego.Application.Features.Offers.Queries;

namespace Wego.Application.Features.Jobs.Queries
{
    public record GetOfferListByFilterQuery(string? Query, string? Locations, string? Skills, string? JobLevels, string? BusinessSkills,
    string? Categories, string? ContractTypes, string? WorkTypes, OrderByType? OrderBy, int? PostedDays,
    decimal? SalaryMin, decimal? DailyRateMin, string? RemoteDays, int PageIndex = 1, int PageSize = 10) : IRequest<List<GetOfferListByFilterModel>>;

    public class GetOfferListByFilterQueryHandler : IRequestHandler<GetOfferListByFilterQuery, List<GetOfferListByFilterModel>>
    {
        private readonly IDataManager _dataManager;

        public GetOfferListByFilterQueryHandler(IDataManager dataManager)
        {
            _dataManager = dataManager;
        }

        public async Task<List<GetOfferListByFilterModel>> Handle(GetOfferListByFilterQuery request, CancellationToken cancellationToken)
        {
            var sqlParams = new List<SqlParameter>
            {
                new SqlParameter("SearchText", CheckField(request.Query)),
                new SqlParameter("OrderBy", CheckField(request.OrderBy?.ToString())),
                new SqlParameter("LocationCodes", CheckField(request.Locations)),
                new SqlParameter("ContractTypeCodes",CheckField( request.ContractTypes)),
                new SqlParameter("JobLevelCodes", CheckField(request.JobLevels)),
                new SqlParameter("SkillCodes", CheckField(request.Skills)),
                new SqlParameter("BusinessSkillCodes", CheckField(request.BusinessSkills)),
                new SqlParameter("WorkTypeCodes", CheckField(request.WorkTypes)),
                new SqlParameter("CategorYCodes", CheckField(request.Categories)),
                new SqlParameter("RemoteDays", CheckField(request.RemoteDays)),
                new SqlParameter("FilterDate", GetFilterDate(request.PostedDays)),
                new SqlParameter("DailyRateMin", request.DailyRateMin),
                new SqlParameter("SalaryMin", request.SalaryMin),
                new SqlParameter("PageIndex", request.PageIndex),
                new SqlParameter("PageSize", request.PageSize),
            };

            return await _dataManager.GetListAsync<GetOfferListByFilterModel>("OfferSearchEngine", sqlParams, cancellationToken: cancellationToken);

        }

        private static DateTime? GetFilterDate(int? postedDays)
        {
            DateTime? filterDate = null;
            if (postedDays.HasValue)
            {
                switch (postedDays)
                {
                    case 0:
                        filterDate = null;
                        break;
                    case var n when n <= 30:
                        filterDate = DateTime.Now.AddDays(postedDays.Value);
                        break;
                    case var n when n > 30:
                        filterDate = DateTime.Now.AddYears(-2);
                        break;
                    default:
                        break;
                }
            }

            return filterDate;
        }

        private static string? CheckField(string field)
        {
            if (string.IsNullOrWhiteSpace(field))
                return null;
            else return field;
        }
    }

}
