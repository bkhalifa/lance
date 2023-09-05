using AutoMapper;
using Dapper;
using System.Data;
using Wego.Application.Contracts.Infrastructure;
using Wego.Application.IRepo;
using Wego.Application.Models.Common;
using Wego.Domain.Common;

namespace Wego.Persistence.Repositories.Common
{
    public class LocationRepository : ILocationRepository
    {
        private readonly DapperContext _context;
        private readonly ICacheManager _cacheManager;
        public LocationRepository(DapperContext context, ICacheManager cacheManager)
        {
            _context = context;
            _cacheManager = cacheManager;
        }

        public async Task<IEnumerable<LocationModel>> GetByCodesAsync(string codes, CancellationToken cancellationToken = default)
        {
            var sql = "SELECT * FROM dbo.LocationsSearch WHERE code in (@codes)";
            var parameters = new DynamicParameters();
            parameters.Add("codes", codes?.Replace('|', ','), DbType.String);
            using (var connection = _context.CreateConnection())
            {
                return await connection.QueryAsync<LocationModel>(new CommandDefinition(sql, parameters, cancellationToken: cancellationToken));
            }
        }

        public async Task<IEnumerable<LocationModel>> GetByQueryAsync(string query, CancellationToken cancellationToken = default)
        {
            var parameters = new DynamicParameters();
            parameters.Add("query", query, DbType.String);
            using (var connection = _context.CreateConnection())
            {
                return await connection.QueryAsync<LocationModel>(new CommandDefinition("LocationSearchEngine", parameters,
                    commandType: CommandType.StoredProcedure, cancellationToken: cancellationToken));
            }
        }

        public async Task<IEnumerable<RegionModel>> GetAllRegionsAsync(CancellationToken cancellationToken = default)
        {
            return await _cacheManager.GetAsync(nameof(RegionModel), async () =>
            {
                var sql = "SELECT * FROM Config.Regions";
                using (var connection = _context.CreateConnection())
                {
                    return await connection.QueryAsync<RegionModel>(new CommandDefinition(sql, cancellationToken: cancellationToken));
                }
            }, CacheDuration.OneDay, cancellationToken);
        }

        public async Task<IEnumerable<CountryModel>> GetAllCountriesAsync(CancellationToken cancellationToken = default)
        {
            return await _cacheManager.GetAsync(nameof(CountryModel), async () =>
            {
                var sql = "SELECT * FROM Config.Countries";
                using (var connection = _context.CreateConnection())
                {
                    return await connection.QueryAsync<CountryModel>(new CommandDefinition(sql, cancellationToken: cancellationToken));
                }
            }, CacheDuration.OneDay, cancellationToken);
        }
    }
}
