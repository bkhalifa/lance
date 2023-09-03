using Dapper;

using System.Data;

using Wego.Application.Features.Profile.Commands;
using Wego.Application.IRepository;

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

        var sql = "INSERT INTO [profile].[ImageProfile]  VALUES (@ImageData, @Width, @Height, @ProfileId)";
        var parameters = new DynamicParameters();
        parameters.Add("ImageData", model.Base64, DbType.Binary);
        parameters.Add("Width", model.Width, DbType.Byte);
        parameters.Add("Height", model.Height, DbType.Byte);
        parameters.Add("ProfileId", model.ProfileId, DbType.Int32);
        using (var connection = _context.CreateConnection())
        {
            var result = await connection.ExecuteAsync(sql, parameters);
            return result;
        }
    }

    public async Task<byte[]> GetImageByIdAsync(long fileId)
    {
        var query = "SELECT * FROM [profile].[ImageProfile] WHERE Id = @fileId";

        using (var connection = _context.CreateConnection())
        {
            var result = await connection.QuerySingleOrDefaultAsync<byte[]>(query, new { fileId });
            return result;
        }
    }

}
