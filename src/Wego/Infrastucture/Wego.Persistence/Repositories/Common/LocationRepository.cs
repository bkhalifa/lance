using Dapper;
using System.Data;
using Wego.Application.IRepo;
using Wego.Domain.Common;

namespace Wego.Persistence.Repositories.Common
{
    public class LocationRepository : ILocationRepository
    {
        private readonly DapperContext _context;
        public LocationRepository(DapperContext context)
        {
            _context = context;
        }

      
        public async Task<IEnumerable<LocationModel>> GetByCodesAsync(string codes)
        {
            var sql = "SELECT * FROM dbo.LocationsSearch WHERE code in (@codes)";
            var parameters = new DynamicParameters();
            parameters.Add("codes", codes?.Replace('|',','), DbType.String);
            using (var connection = _context.CreateConnection())
            {
                return await connection.QueryAsync<LocationModel>(sql, parameters);
            }
        }

        public async Task<IEnumerable<LocationModel>> GetByQueryAsync(string query)
        {
            var parameters = new DynamicParameters();
            parameters.Add("query", query, DbType.String);
            using (var connection = _context.CreateConnection())
            {
                return await connection.QueryAsync<LocationModel>("LocationSearchEngine", parameters, commandType: CommandType.StoredProcedure);

            }
        }

        public async Task<IEnumerable<RegionModel>> GetAllRegionsAsync()
        {
            var sql = "SELECT * FROM Config.Regions";
            using (var connection = _context.CreateConnection())
            {
                return await connection.QueryAsync<RegionModel>(sql);
            }
        }

        public async Task<IEnumerable<CountryModel>> GetAllCountriesAsync()
        {
            var sql = "SELECT * FROM Config.Countries";
            using (var connection = _context.CreateConnection())
            {
                return await connection.QueryAsync<CountryModel>(sql);
            }
        }
    }
}
