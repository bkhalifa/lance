using Microsoft.Data.SqlClient;

using System.Drawing;

using Wego.Application.Contracts.Context;
using Wego.Application.Extensions;
using Wego.Application.IRepository;
using Wego.Application.IService.Feature.Profile;
using Wego.Application.Models.Common;
using Wego.Application.Models.Profile;
using Wego.Domain.Common;
using Wego.Domain.Profile;
using WegoPro.Domain.Profile;

namespace Wego.Infrastructure.Services.Feature.Profile;

public class ProfileService : IProfileService
{
    private readonly IProfileRepository _profileRepository;
    private readonly ICurrentContext _currentContext;
    public ProfileService(IProfileRepository profileRepository, ICurrentContext currentContext)
    {
        _profileRepository = profileRepository;
        _currentContext = currentContext;
    }
    public async Task<ImageProfileResponse> SaveImageAsync(ImageProfileModel model, CancellationToken cancellationtoken = default)
    {
        ArgumentNullException.ThrowIfNull(model);

        var image = await _profileRepository.GetImageByProfileIdAsync(model.ProfileId, cancellationtoken);
        model.Base64 = MakeThumbnail(model.Base64, 200, 200);

        if (image is null)
        {
            var id = await _profileRepository.CreateImageAsync(model, cancellationtoken).ConfigureAwait(false);
            return new ImageProfileResponse(id, model.ContentType, model.Base64);
        }

        await _profileRepository.UpdateImageAsync(model, cancellationtoken).ConfigureAwait(false);

        return new ImageProfileResponse(image.Id, model.ContentType, model.Base64);
    }
    public async Task<ImageProfileResponse> GetImageByIdAsync(long profileId, CancellationToken cancellationtoken = default)
    {
        var result = await _profileRepository.GetImageByIdAsync(profileId, cancellationtoken).ConfigureAwait(false);
        return result;
    }
    public async Task<ProfileInfoResponse> GetProfileInfo(string suID, CancellationToken cancellationtoken = default)
    {

        ArgumentNullException.ThrowIfNull(suID);

        var result = await _profileRepository.GetProfileAsync(suID.Trim(), cancellationtoken).ConfigureAwait(false);


        if (result is not null && result.Email == _currentContext.Identity.Email && _currentContext.Identity.UserId == result.UserId)
        {
            return result.MapTo<ProfileInfoResponse>();
        }

        return await Task.FromResult<ProfileInfoResponse>(default);

    }
    public async Task<ProfileModel> GetProfileByEmailAsync(string email, CancellationToken cancellationtoken = default)
    {
        ArgumentNullException.ThrowIfNull(email);
        return await _profileRepository.GetProfileByEmailAsync(email, cancellationtoken).ConfigureAwait(false);
    }
    public async Task<long> AddProfileInfoAsync(ProfileModel profile, CancellationToken cancellationtoken = default)
    {
        ArgumentNullException.ThrowIfNull(profile);

        var existUSId = await _profileRepository.CheckProfileIfExistByUsIdAsync(profile.UsId, cancellationtoken);
        if (string.IsNullOrEmpty(existUSId)) { return await _profileRepository.AddProfileInfoAsync(profile, cancellationtoken).ConfigureAwait(false); }
        profile.SetUsId();

        return await _profileRepository.AddProfileInfoAsync(profile, cancellationtoken).ConfigureAwait(false);
    }
    public async Task<ProfileModel> GetProfileByUserIdAsync(string userId, CancellationToken cancellationtoken = default)
    {
        ArgumentNullException.ThrowIfNull(userId);
        return await _profileRepository.GetProfileByUserIdAsync(userId, cancellationtoken);
    }
    public async Task<bool> DeleteImageByIdAsync(long fileId, CancellationToken cancellationtoken = default)
    {
        ArgumentNullException.ThrowIfNull(fileId);
        return await _profileRepository.DeleteImageByIdAsync(fileId, cancellationtoken).ConfigureAwait(false);
    }
    public async Task<long> SaveBackGroundProfileAsync(BackGroundModel model, CancellationToken cancellationtoken)
    {
        var file = model.MapTo<BackGroundFile>();
        file.BigData = ToArrayBase(model.FileBase64);
        file.LittleData = MakeThumbnail(file.BigData, 20, 20);
        return await _profileRepository.SaveBackGroundAsync(file, cancellationtoken).ConfigureAwait(false);
    }
    public async Task<BackGroundResponse> GetBackGroundByIdAsync(long fileId, CancellationToken cancellationtoken)
    {
        var result = await _profileRepository.GetBgImageByIdAsync(fileId, cancellationtoken).ConfigureAwait(false);
        return result;
    }
    public async Task<long> GetBackGroundByProfileIdAsync(long profileId, CancellationToken cancellationtoken = default)
    {
        var result = await _profileRepository.GetBgImageByProfileIdAsync(profileId, cancellationtoken).ConfigureAwait(false);
        return result;
    }
    public async Task<IEnumerable<AllBackGroundResponse>> GetAllBackGroundAsync(CancellationToken cancellationtoken)
    {
        var result = await _profileRepository.GetAllBackGroundAsync(cancellationtoken).ConfigureAwait(false);
        return result;
    }
    public async Task<long> SaveBackGroudProfile(BackGroundProfileModel model, CancellationToken cancellationtoken)
    {
        var backGround = await _profileRepository.GetBackGroundByProfileId(model.profileId, cancellationtoken);

        if (backGround is not null)
        {
            await _profileRepository.DeleteGroundProfile(backGround.Id, cancellationtoken);
        }

        var bgModel = await _profileRepository.GetBackGroundByFileId(model.fileId, cancellationtoken);
        bgModel.ProfileId = model.profileId;
        return await _profileRepository.AddBackGroundProfile(bgModel, cancellationtoken); ;
    }

    public async Task<FileResponse> GetFileByIdAsync(long fileId, CancellationToken cancellationtoken = default)
    {
        var result = await _profileRepository.GetFileByIdIdAsync(fileId, cancellationtoken).ConfigureAwait(false);
        return result;
    }

    private static byte[] ToArrayBase(string FileAsBase64)
    {
        return FileAsBase64.Contains(",") ?
                             Convert.FromBase64String(FileAsBase64.Substring(FileAsBase64.IndexOf(",") + 1)) :
                             Convert.FromBase64String(FileAsBase64);
    }
    private static byte[] MakeThumbnail(byte[] myImage, int thumbWidth, int thumbHeight)
    {
        using (MemoryStream ms = new MemoryStream())
        using (Image thumbnail = Image.FromStream(new MemoryStream(myImage)).GetThumbnailImage(thumbWidth, thumbHeight, null, new IntPtr()))
        {
            thumbnail.Save(ms, System.Drawing.Imaging.ImageFormat.Png);
            return ms.ToArray();
        }
    }


}
