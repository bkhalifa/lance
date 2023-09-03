using Dapper;

using System.Data;

using Wego.Application.Features.Profile.Commands;
using Wego.Application.IRepository;
using Wego.Domain.Profile;

namespace Wego.Persistence.Repositories.Profile;

public class ProfileRepository : IProfileRepository
{
    private readonly DapperContext _context;
    public ProfileRepository(DapperContext context)
    {
        _context = context;
    }
    public async Task<long> CreateImageAsync(ImageProfileModelCommand model)
    {

        var sql = "INSERT INTO [profile].[ImageProfile]  VALUES (@ImageData, @Width, @Height, @ContentType, @CreationDate, @UpdateDate,  @ProfileId)";
        var parameters = new DynamicParameters();
        parameters.Add("ImageData", model.Base64, DbType.Binary);
        parameters.Add("Width", model.Width, DbType.Byte);
        parameters.Add("Height", model.Height, DbType.Byte);
        parameters.Add("ContentType", model.ContentType, DbType.String);
        parameters.Add("CreationDate", DateTime.Now, DbType.DateTime);
        parameters.Add("UpdateDate", null, DbType.DateTime);
        parameters.Add("ProfileId", model.ProfileId, DbType.Int32);
        using (var connection = _context.CreateConnection())
        {
            try
            {
                var result = await connection.ExecuteAsync(sql, parameters);
                return result;
            }
            catch (Exception e)
            {

                throw;
            }

        }
    }

    public async Task<ImageProfileResponse> GetImageByIdAsync(long profileId)
    {
        var query = "SELECT ImageData, ContentType FROM [profile].[ImageProfile] WHERE ProfileId = @profileId ORDER BY CreationDate DESC";

        using (var connection = _context.CreateConnection())
        {
            var result = await connection.QueryFirstOrDefaultAsync<ImageProfileResponse>(query, new { profileId }); // SHOULD BE SINGLE OR DEFAULT
            return result;
        }
    }

}
