using AutoMapper;
using Dapper;

using System.Data;
using Wego.Application.Features.Profile.Commands;
using Wego.Application.IRepository;
using Wego.Domain.OfferProfile;
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
        var sql = "INSERT INTO [profile].[ImageProfile]  VALUES (@ImageData, @Width, @Height, @ContentType, @CreationDate, @UpdateDate,  @ProfileId)"
            + "SELECT CAST(SCOPE_IDENTITY() as bigint)";
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
            var id = await connection.QuerySingleAsync<long>(sql, parameters);
            return id;
        }
    }
    public async Task<long> UpdateImageAsync(ImageProfileModelCommand model)
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
            var result = await connection.ExecuteAsync(sql, parameters);
            return result;
        }
    }

    public async Task<ImageProfileResponse> GetImageByIdAsync(long fid)
    {
        var query = "SELECT ImageData, ContentType FROM [profile].[ImageProfile] WHERE Id = @fid ORDER BY CreationDate DESC";

        using (var connection = _context.CreateConnection())
        {
            var result = await connection.QueryFirstOrDefaultAsync<ImageProfileResponse>(query, new { fid });

            return result ?? new ImageProfileResponse { ContentType = "image/png", ImageData = new byte[] { 0x20, 0x20, 0x20, 0x20, 0x20, 0x20, 0x20 } };
        }
    }

    public async Task<ProfileModel> GetProfileAsync(long profileId)
    {
        var query = "SELECT * FROM [profile].[UserProfiles] WHERE Id = @profileId ";
        var parameters = new DynamicParameters();
        parameters.Add("profileId", profileId);

        using (var connection = _context.CreateConnection())
        {
            return await connection.QueryFirstOrDefaultAsync<ProfileModel>(query, parameters);
        }
    }

    public async Task<ProfileModel> GetProfileByEmailAsync(string email)
    {
        var query = "SELECT * FROM [profile].[UserProfiles] WHERE email = @email ";
        var parameters = new DynamicParameters();
        parameters.Add("email", email);

        using (var connection = _context.CreateConnection())
        {
            return await connection.QueryFirstOrDefaultAsync<ProfileModel>(query, parameters);
        }
    }

    public async Task<ProfileModel> GetProfileByUserIdAsync(string userId)
    {
        var query = "SELECT * FROM [profile].[UserProfiles] WHERE userId = @userId ";
        var parameters = new DynamicParameters();
        parameters.Add("userId", userId);

        using (var connection = _context.CreateConnection())
        {
            return await connection.QueryFirstOrDefaultAsync<ProfileModel>(query, parameters);
        }
    }

    public async Task<long> AddProfileAsync(ProfileModel profile)
    {
        var sql = "INSERT INTO [profile].[UserProfiles] (UserId, Email, UsId, InitialUserName, CreationDate, UpdateDate)  VALUES " +
            "(@userId, @email, @usId, @initial, GETUTCDATE(), GETUTCDATE())" +
            "SELECT CAST(SCOPE_IDENTITY() AS INT) ";
        var parameters = new DynamicParameters();
        parameters.Add("userId", profile.UserId);
        parameters.Add("email", profile.Email);
        parameters.Add("usId", profile.UsId);
        parameters.Add("initial", profile.InitialUserName);


        using (var connection = _context.CreateConnection())
        {
            return await connection.QuerySingleOrDefaultAsync<long>(sql, parameters);
        }
    }
}
