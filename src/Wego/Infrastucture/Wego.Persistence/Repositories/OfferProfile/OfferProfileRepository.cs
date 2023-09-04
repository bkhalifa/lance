using AutoMapper;
using Dapper;
using Wego.Application.Contracts.Context;
using Wego.Application.IRepo;
using Wego.Domain.OfferProfile;

namespace Wego.Persistence.Repositories.OfferProfile
{
    public class OfferProfileRepository : IOfferProfileRepository
    {
        private readonly DapperContext _context;
        public OfferProfileRepository(DapperContext context)
        {
            _context = context;
        }
        public async Task<IEnumerable<OfferFavoriteModel>> GetAllAsync(long profileId)
        {
            var sql = "SELECT * FROM dbo.OfferProfileFavorite WHERE profileId = @profileId";
            var parameters = new DynamicParameters();
            parameters.Add("profileId", profileId);
            using (var connection = _context.CreateConnection())
            {
                var result = await connection.QueryAsync<OfferFavoriteModel>(sql);
                return result;
            }
        }

        public async Task<int> AddOfferFavoriteAsync(long offerId, long profileId)
        {
            var sql = "INSERT INTO [dbo].[OfferProfileFavorite]  VALUES (@profileId, @offerId, GETUTCDATE())";
            var parameters = new DynamicParameters();
            parameters.Add("profileId", profileId);
            parameters.Add("offerId", offerId);
            using (var connection = _context.CreateConnection())
            {
                return await connection.ExecuteAsync(sql, parameters);
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
                return await connection.ExecuteAsync(sql, parameters);
            }
        }

        public async Task<OfferFavoriteModel> GetOfferFavoriteAsync(long offerId, long profileId)
        {
            var sql = "SELECT * FROM dbo.OfferProfileFavorite WHERE profileId = @profileId AND offerId = @OfferId";
            var parameters = new DynamicParameters();
            parameters.Add("profileId", profileId);
            parameters.Add("offerId", offerId);
            using (var connection = _context.CreateConnection())
            {
                return await connection.QueryFirstOrDefaultAsync<OfferFavoriteModel>(sql, parameters);
            }
        }

    }
}
