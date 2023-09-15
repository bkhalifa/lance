﻿
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
    public async Task<long> CreateImageAsync(ImageProfileModelCommand model, CancellationToken cancellationtoken = default)
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
            var id = await connection.QuerySingleAsync<long>(new CommandDefinition(sql, parameters, cancellationToken: cancellationtoken));
            return id;
        }
    }
    public async Task<long> UpdateImageAsync(ImageProfileModelCommand model, CancellationToken cancellationtoken = default)
    {

        var sql = "UPDATE [profile].[ImageProfile] SET ImageData = @ImageData , Width = @Width, Height = @Height," +
                                                             "ContentType = @ContentType, UpateDate = @UpateDate  Where ProfileId = @pid ";
        var parameters = new DynamicParameters();
        parameters.Add("pid", model.ProfileId, DbType.Int64);
        parameters.Add("ImageData", model.Base64, DbType.Binary);
        parameters.Add("Width", model.Width, DbType.Byte);
        parameters.Add("Height", model.Height, DbType.Byte);
        parameters.Add("ContentType", model.ContentType, DbType.String);
        parameters.Add("UpateDate", DateTime.Now, DbType.DateTime);
     
        using (var connection = _context.CreateConnection())
        {
          var result = await connection.ExecuteAsync(sql, parameters);
           return result;
         }
       
    }
    public async Task<ImageProfileResponse> GetImageByIdAsync(long fid, CancellationToken cancellationtoken = default)
    {
        var query = "SELECT ImageData, ContentType FROM [profile].[ImageProfile] WHERE Id = @fid";
        var parameters = new DynamicParameters();
        parameters.Add("fid", fid);

        using (var connection = _context.CreateConnection())
         {
           var result = await connection.QueryFirstOrDefaultAsync<ImageProfileResponse>(new CommandDefinition(query, parameters, cancellationToken: cancellationtoken));
           return result ?? new ImageProfileResponse { ContentType = "image/png", ImageData = new byte[] { 0x20, 0x20, 0x20, 0x20, 0x20, 0x20, 0x20 } };
         }       
    }

    public async Task<ImageProfileResponse> GetImageByProfileIdAsync(long pid, CancellationToken cancellationtoken = default)
    {
        var query = "SELECT ImageData, ContentType FROM [profile].[ImageProfile] WHERE ProfileId = @pid";
        var parameters = new DynamicParameters();
        parameters.Add("pid", pid);

        using (var connection = _context.CreateConnection())
        {
           return await connection.QueryFirstOrDefaultAsync<ImageProfileResponse>(new CommandDefinition(query, parameters, cancellationToken: cancellationtoken));
        }
    }
    public async Task<ProfileModel> GetProfileAsync(string suId, CancellationToken cancellationtoken = default)
    {
        var query = "SELECT pfl.Id, pfl.UserId, pfl.FirstName, pfl.LastName, pfl.InitialUserName, pfl.Email, pfl.PhoneNumber, pfl.CreationDate, pfl.UpdateDate, pfl.UsId, pfl.Position, img.Id as fileId " +
            "FROM [profile].[Profiles] pfl " +
            "LEFT JOIN [profile].[ImageProfile] img " +
            "ON pfl.Id = img.ProfileId " +
            "WHERE pfl.UsId =@suId";

        var parameters = new DynamicParameters();
        parameters.Add("suId", suId);

        using (var connection = _context.CreateConnection())
        {
            return await connection.QueryFirstOrDefaultAsync<ProfileModel>(new CommandDefinition(query, parameters, cancellationToken: cancellationtoken));
        }
    }
    public async Task<ProfileModel> GetProfileByEmailAsync(string email, CancellationToken cancellationtoken = default)
    {
        var query = "SELECT pfl.Id, pfl.UserId, pfl.FirstName, pfl.LastName, pfl.InitialUserName, pfl.Email, pfl.PhoneNumber, pfl.CreationDate, pfl.UpdateDate, pfl.UsId, pfl.Position FROM [profile].[Profiles] pfl WHERE pfl.Email = @email ";
        var parameters = new DynamicParameters();
        parameters.Add("email", email);

        using (var connection = _context.CreateConnection())
        {
            return await connection.QueryFirstOrDefaultAsync<ProfileModel>(new CommandDefinition(query, parameters, cancellationToken: cancellationtoken));
        }

    }
    public async Task<ProfileModel> GetProfileByUserIdAsync(string userId, CancellationToken cancellationtoken = default)
    {
        var query = "SELECT * FROM [profile].[Profiles] WHERE UserId = @userId ";
        var parameters = new DynamicParameters();
        parameters.Add("userId", userId);

        using (var connection = _context.CreateConnection())
        {
            return await connection.QueryFirstOrDefaultAsync<ProfileModel>(new CommandDefinition(query, parameters, cancellationToken: cancellationtoken));
        }
    }
    public async Task<long> AddProfileInfoAsync(ProfileModel profile, CancellationToken cancellationtoken = default)
    {
        var sql = "INSERT INTO [profile].[Profiles] VALUES " +
            " (@userId, @FirstName, @LastName, @InitialUserName, @Email, @PhoneNumber, @CreationDate, @UpdateDate, @UsId, @Position, @Skills) " +
            "SELECT CAST(SCOPE_IDENTITY() AS INT) ";

        var parameters = new DynamicParameters();
        parameters.Add("userId", profile.UserId);
        parameters.Add("firstName", default);
        parameters.Add("lastName", default);
        parameters.Add("initialUserName", profile.InitialUserName);
        parameters.Add("email", profile.Email);
        parameters.Add("phoneNumber", default);
        parameters.Add("creationDate", DateTime.UtcNow);
        parameters.Add("updateDate", default(DateTime?));
        parameters.Add("usid", profile.UsId);
        parameters.Add("position", default(string));
        parameters.Add("skills", default(string));


        using (var connection = _context.CreateConnection())
        {
            return await connection.QuerySingleOrDefaultAsync<long>(new CommandDefinition(sql, parameters, cancellationToken: cancellationtoken));
        }
    }
    public async Task<string> CheckProfileIfExistByUsIdAsync(string usId, CancellationToken cancellationtoken = default)
    {
        var query = "SELECT UsId FROM [profile].[Profiles] WHERE [UsId]= @usId ";
        var parameters = new DynamicParameters();
        parameters.Add("usId", usId);

        using (var connection = _context.CreateConnection())
        {
            return await connection.QueryFirstOrDefaultAsync<string>(new CommandDefinition(query, parameters, cancellationToken: cancellationtoken));
        }
    }
}