﻿using Dapper;
using System.Data;
using System.Web;
using Wego.Application.IRepo;
using Wego.Domain.Offers;

namespace Wego.Persistence.Repositories.Offers
{
    public class OfferRepository : IOfferRepository
    {
        private readonly DapperContext _context;
        public OfferRepository(DapperContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<OfferSearchModel>> GetOffersByFilterAsync(OfferFilterParam filter, CancellationToken cancellationToken = default)
        {
            var parameters = new DynamicParameters();

            parameters.Add("SearchText", CheckField(HttpUtility.UrlDecode(filter.Query)));
            parameters.Add("LocationCodes", CheckField(filter.Locations));
            parameters.Add("ContractTypeCodes", CheckField(filter.ContractTypes));
            parameters.Add("SkillCodes", CheckField(filter.Skills));
            parameters.Add("SeniorityCodes", CheckField(filter.Seniorities));
            parameters.Add("CategoryCodes", CheckField(filter.Categories));
            parameters.Add("WorkTypeCodes", CheckField(filter.WorkTypes));
            parameters.Add("DailyRateMin", filter.DailyRateMin);
            parameters.Add("SalaryMin", filter.SalaryMin);
            parameters.Add("PageIndex", filter.PageIndex);
            parameters.Add("PageSize", filter.PageSize);
            parameters.Add("OrderBy", CheckField(filter.OrderBy));


            using (var connection = _context.CreateConnection())
            {
                return await connection.QueryAsync<OfferSearchModel>(new CommandDefinition("OfferSearchEngine", parameters,
                    commandType: CommandType.StoredProcedure, cancellationToken: cancellationToken));
            }
        }

        public async Task<OfferModel> GetOffersByIdAsync(int id, CancellationToken cancellationToken = default)
        {
            var sql = "SELECT * FROM dbo.OffersSearch WHERE id = @id";
            var parameters = new DynamicParameters();
            parameters.Add("id", id);

            using (var connection = _context.CreateConnection())
            {
                return await connection.QueryFirstOrDefaultAsync<OfferModel>(new CommandDefinition(sql, parameters, cancellationToken: cancellationToken));
            }
        }
        private static string CheckField(string field)
        {
            if (string.IsNullOrWhiteSpace(field))
                return null;
            else return $"|{field}|";

        }

        private static int? CheckField(OrderByType? field)
        {
            if (field.HasValue)
                return (int)field;
            else return null;
        }

    }
}
