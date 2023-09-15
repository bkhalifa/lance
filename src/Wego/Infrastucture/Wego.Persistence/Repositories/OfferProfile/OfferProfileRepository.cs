using Dapper;
using Wego.Application.Contracts.Infrastructure;
using Wego.Application.IRepo;
using Wego.Application.Models.Common;
using Wego.Domain.OfferProfile;

namespace Wego.Persistence.Repositories.OfferProfile
{
    public class OfferProfileRepository : IOfferProfileRepository
    {
        private readonly DapperContext _context;
        private readonly ICacheManager _cacheManager;
        public OfferProfileRepository(DapperContext context, ICacheManager cacheManager)
        {
            _context = context;
            _cacheManager = cacheManager;
        }
        public async Task<IEnumerable<OfferFavoriteModel>> GetAllAsync(long profileId, CancellationToken cancellationToken = default)
        {
            return await _cacheManager.GetAsync($"OfferFavorites{profileId}", async () =>
            {
                var sql = "SELECT * FROM dbo.OfferProfileFavorite WHERE profileId = @profileId";
                var parameters = new DynamicParameters();
                parameters.Add("profileId", profileId);
                using (var connection = _context.CreateConnection())
                {
                    return await connection.QueryAsync<OfferFavoriteModel>(new CommandDefinition(sql, parameters, cancellationToken: cancellationToken));

                }
            }, CacheDuration.OneHour, cancellationToken);
        }

        public async Task<int> AddOfferFavoriteAsync(long offerId, long profileId)
        {
            var sql = "INSERT INTO [dbo].[OfferProfileFavorite]  VALUES (@profileId, @offerId, GETUTCDATE())";
            var parameters = new DynamicParameters();
            parameters.Add("profileId", profileId);
            parameters.Add("offerId", offerId);
            using (var connection = _context.CreateConnection())
            {
                var result = await connection.ExecuteAsync(sql, parameters);
                await _cacheManager.RemoveAsync($"OfferFavorites{profileId}");
                return result;
            }

        }

        public async Task<int> DeleteOfferFavoriteAsync(long offerId, long profileId)
        {
            var sql = "DELETE FROM [dbo].[OfferProfileFavorite]  WHERE profileId = @profileId AND offerId = @OfferId";
            var parameters = new DynamicParameters();
            parameters.Add("profileId", profileId);
            parameters.Add("offerId", offerId);
            using (var connection = _context.CreateConnection())
            {
                var result = await connection.ExecuteAsync(sql, parameters);
                await _cacheManager.RemoveAsync($"OfferFavorites{profileId}");
                return result;
            }
        }

        public async Task<OfferFavoriteModel> GetOfferFavoriteAsync(long offerId, long profileId, CancellationToken cancellationToken = default)
        {
            var sql = "SELECT * FROM dbo.OfferProfileFavorite WHERE profileId = @profileId AND offerId = @OfferId";
            var parameters = new DynamicParameters();
            parameters.Add("profileId", profileId);
            parameters.Add("offerId", offerId);
            using (var connection = _context.CreateConnection())
            {
                return await connection.QueryFirstOrDefaultAsync<OfferFavoriteModel>(new CommandDefinition(sql, parameters, cancellationToken: cancellationToken));
            }
        }

    }
}
