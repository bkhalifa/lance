using Dapper;

using Newtonsoft.Json;

using System.Data;

using Wego.Application.IRepository;
using Wego.Application.Models.Profile;
using Wego.Application.Models.Profile.request;
using Wego.Domain.Common;
using Wego.Domain.Profile;

using WegoPro.Domain.Profile;

namespace Wego.Persistence.Repositories.Profile;

public class ProfileRepository : IProfileRepository
{
    private readonly DapperContext _context;
    public ProfileRepository(DapperContext context)
    {
        _context = context;
    }
    public async Task<long> CreateImageAsync(ImageProfileModel model, CancellationToken cancellationtoken = default)
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
    public async Task UpdateImageAsync(ImageProfileModel model, CancellationToken cancellationtoken = default)
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
            await connection.ExecuteAsync(sql, parameters);
        }

    }
    public async Task<ImageProfileResponse> GetImageByIdAsync(long pid, CancellationToken cancellationtoken = default)
    {
        var query = "SELECT Id,  ContentType, ImageData FROM [profile].[ImageProfile] WHERE ProfileId = @pid";
        var parameters = new DynamicParameters();
        parameters.Add("pid", pid);

        using (var connection = _context.CreateConnection())
        {
            var result = await connection.QueryFirstOrDefaultAsync<ImageProfileResponse>(new CommandDefinition(query, parameters, cancellationToken: cancellationtoken));
            return result;
        }
    }
    public async Task<long> GetBgImageByProfileIdAsync(long pid, CancellationToken cancellationtoken = default)
    {
        var query = "SELECT Id FROM profile.BackGroundImage WHERE ProfileId = @pid";
        var parameters = new DynamicParameters();
        parameters.Add("pid", pid);

        using (var connection = _context.CreateConnection())
        {
            var result = await connection.QueryFirstOrDefaultAsync<long>(new CommandDefinition(query, parameters, cancellationToken: cancellationtoken));
            return result;
        }
    }
    public async Task<BackGroundResponse> GetBgImageByIdAsync(long fid, CancellationToken cancellationtoken = default)
    {
        var query = "SELECT Id, ContentType, Extension, BigData, LittleData FROM profile.BackGroundImage WHERE Id = @fid";
        var parameters = new DynamicParameters();
        parameters.Add("fid", fid);

        using (var connection = _context.CreateConnection())
        {
            var result = await connection.QueryFirstOrDefaultAsync<BackGroundResponse>(new CommandDefinition(query, parameters, cancellationToken: cancellationtoken));
            return result;
        }
    }
    public async Task<ImageProfileResponse> GetImageByProfileIdAsync(long pid, CancellationToken cancellationtoken = default)
    {
        var query = "SELECT Id, ContentType,  ImageData FROM [profile].[ImageProfile] WHERE ProfileId = @pid";
        var parameters = new DynamicParameters();
        parameters.Add("pid", pid);

        using (var connection = _context.CreateConnection())
        {
            var result = await connection.QueryFirstOrDefaultAsync<ImageProfileResponse>(new CommandDefinition(query, parameters, cancellationToken: cancellationtoken));
            return result;
        }
    }
    public async Task<ProfileModel> GetProfileAsync(string suId, CancellationToken cancellationtoken = default)
    {
        var query = "SELECT pfl.Id, pfl.UserId, pfl.FirstName, pfl.LastName, pfl.InitialUserName, pfl.Email, pfl.PhoneNumber, pfl.CreationDate, pfl.UpdateDate, pfl.UsId, pfl.Position " +
            "FROM [profile].[Profiles] pfl " +
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
    public async Task<bool> DeleteImageByIdAsync(long id, CancellationToken cancellationtoken = default)
    {
        var query = "DELETE FROM profile.ImageProfile WHERE Id = @Id";

        using (var connection = _context.CreateConnection())
        {
            var effectedRow = await connection.ExecuteAsync(new CommandDefinition(query, new { id }, cancellationToken: cancellationtoken));
            return effectedRow > 0;
        }
    }
    public async Task<long> SaveBackGroundAsync(BackGroundFile file, CancellationToken cancellationtoken)
    {
        var sql = "INSERT INTO [profile].[BackGroundImage] VALUES " +
              "(@ParentId, @FileName, @Extension, @ContentType, @LittleData, @BigData, @Size ,@Width, @Height, @CreationDate, @UpDateDate, @FileType, @ProfileId) " +
              "SELECT CAST(SCOPE_IDENTITY() AS INT)";
        var parameters = new DynamicParameters();
        try
        {
            parameters.Add("ParentId", file.ParentId);
            parameters.Add("FileName", file.FileName);

            parameters.Add("Extension", file.Extension);
            parameters.Add("ContentType", file.ContentType);

            parameters.Add("LittleData", file.LittleData);
            parameters.Add("BigData", file.BigData);

            parameters.Add("Size", file.Size);
            parameters.Add("Width", file.Width);
            parameters.Add("Height", file.Height);

            parameters.Add("CreationDate", DateTime.Now);
            parameters.Add("UpDateDate", DateTime.Now);

            parameters.Add("FileType", file.FileType);
            parameters.Add("ProfileId", null!);

            using (var connection = _context.CreateConnection())
            {
                return await connection.QuerySingleOrDefaultAsync<long>(new CommandDefinition(sql, parameters, cancellationToken: cancellationtoken));
            }
        }
        catch (Exception)
        {

            throw;
        }

    }
    public async Task<IEnumerable<AllBackGroundResponse>> GetAllBackGroundAsync(CancellationToken cancellationtoken = default)
    {
        var query = "SELECT Id, ParentId, FileName , Extension, ProfileId FROM [profile].[BackGroundImage] WHERE ProfileId IS NULL";

        using (var connection = _context.CreateConnection())
        {
            return await connection.QueryAsync<AllBackGroundResponse>(new CommandDefinition(query, cancellationToken: cancellationtoken));
        }
    }
    public async Task<FileResponse> GetFileByIdIdAsync(long fileId, CancellationToken cancellationtoken = default)
    {
        var query = "SELECT Id, ContentType,  FileData, FileName FROM [chat].[MessageFiles] WHERE id = @fileId";
        var parameters = new DynamicParameters();
        parameters.Add("fileId", fileId);

        using (var connection = _context.CreateConnection())
        {
            var result = await connection.QueryFirstOrDefaultAsync<FileResponse>(new CommandDefinition(query, parameters, cancellationToken: cancellationtoken));
            return result;
        }
    }
    public async Task<BackGroundFile> GetBackGroundByProfileId(long profileId, CancellationToken cancellationtoken)
    {
        var query = "SELECT [Id] ,[ParentId] , [FileName], [Extension], [ContentType], [LittleData], [BigData], [Size], [Width], [Height], [FileType] ,[ProfileId] FROM [profile].[BackGroundImage] where ProfileId =@profileId";
        var parameters = new DynamicParameters();
        parameters.Add("profileId", profileId);
        using (var connection = _context.CreateConnection())
        {
            return await connection.QueryFirstOrDefaultAsync<BackGroundFile>(new CommandDefinition(query, parameters, cancellationToken: cancellationtoken));
        }
    }
    public async Task<BackGroundFile> GetBackGroundByFileId(long fileId, CancellationToken cancellationtoken)
    {
        var query = "SELECT [Id] ,[ParentId] , [FileName], [Extension], [ContentType], [LittleData], [BigData], [Size], [Width], [Height], [FileType] ,[ProfileId] FROM [profile].[BackGroundImage] where Id =@fileId";
        var parameters = new DynamicParameters();
        parameters.Add("fileId", fileId);
        using (var connection = _context.CreateConnection())
        {
            return await connection.QueryFirstOrDefaultAsync<BackGroundFile>(new CommandDefinition(query, parameters, cancellationToken: cancellationtoken));
        }
    }
    public async Task<long> AddBackGroundProfile(BackGroundFile model, CancellationToken cancellationtoken)
    {
        var sql = "INSERT INTO [profile].[BackGroundImage] VALUES " +
            " (@ParentId, @FileName, @Extension, @ContentType, @LittleData, @BigData, @Size, @Width, @Height, @CreationDate, @UpDateDate, @FileType, @ProfileId) " +
            "SELECT CAST(SCOPE_IDENTITY() AS BIGINT) ";

        var parameters = new DynamicParameters();
        parameters.Add("ParentId", model.ParentId);
        parameters.Add("FileName", model.FileName);
        parameters.Add("Extension", model.Extension);
        parameters.Add("ContentType", model.ContentType);
        parameters.Add("LittleData", model.LittleData);
        parameters.Add("BigData", model.BigData);
        parameters.Add("Size", model.Size);
        parameters.Add("Width", model.Width);
        parameters.Add("Height", model.Height);
        parameters.Add("CreationDate", DateTime.UtcNow);
        parameters.Add("UpDateDate", DateTime.UtcNow);
        parameters.Add("FileType", model.FileType);
        parameters.Add("ProfileId", model.ProfileId);

        using (var connection = _context.CreateConnection())
        {
            return await connection.QuerySingleOrDefaultAsync<long>(new CommandDefinition(sql, parameters, cancellationToken: cancellationtoken));
        }
    }
    public async Task<long> UpdateBackGroundProfile(BackGroundFile model, CancellationToken cancellationtoken)
    {
        var query = "UPDATE [profile].[BackGroundImage] SET ParentId =@ParentId , FileName=@FileName, Extension=@Extension, ContentType=@ContentType ,LittleData=@LittleData, BigData=@BigData , Size=@Size,  UpDateDate=@UpDateDate, FileType=@FileType, ProfileId=@ProfileId Where id=@fileId";
        try
        {
            var parameters = new DynamicParameters();
            parameters.Add("ParentId", model.ParentId);
            parameters.Add("FileName", model.FileName);
            parameters.Add("Extension", model.Extension);
            parameters.Add("ContentType", model.ContentType);
            parameters.Add("LittleData", model.LittleData);
            parameters.Add("BigData", model.BigData);
            parameters.Add("Size", model.Size);
            parameters.Add("UpDateDate", DateTime.Now);
            parameters.Add("FileType", false);
            parameters.Add("ProfileId", model.ProfileId);
            parameters.Add("fileId", model.Id);

            using (var connection = _context.CreateConnection())
            {
                return await connection.QuerySingleOrDefaultAsync<long>(new CommandDefinition(query, parameters, cancellationToken: cancellationtoken));
            }
        }
        catch (Exception)
        {

            throw;
        }
    }
    public async Task DeleteGroundProfile(long fileId, CancellationToken cancellationtoken)
    {
        var query = "DELETE FROM [profile].[BackGroundImage] WHERE Id = @fileId";
        var parameters = new DynamicParameters();
        parameters.Add("fileId", fileId);
        using (var connection = _context.CreateConnection())
        {
            await connection.ExecuteAsync(new CommandDefinition(query, parameters, cancellationToken: cancellationtoken));
        }

    }

    public async Task<long> UpdateProfileInfoAsync(ProfileInfoRequest profileRequest, CancellationToken cancellationToken)
    {
        var parameters = new DynamicParameters();

        parameters.Add("ProfileId", profileRequest.Id);
        parameters.Add("FirstName", profileRequest.FirstName);
        parameters.Add("LastName", profileRequest.LastName);
        parameters.Add("PhoneNumber", profileRequest.PhoneNumber);
        parameters.Add("Position", profileRequest.Position);
        parameters.Add("CountryId", profileRequest.CountryId);
        parameters.Add("linkLinkedIn", profileRequest.LinkedInLink);
        parameters.Add("RegionCode", profileRequest.RegionCode); 


        using (var connection = _context.CreateConnection())
        {
            return await connection.ExecuteAsync(new CommandDefinition("[profile].[UpdateProfileInfo]", parameters, cancellationToken: cancellationToken, commandType: CommandType.StoredProcedure));
        }

    }
}