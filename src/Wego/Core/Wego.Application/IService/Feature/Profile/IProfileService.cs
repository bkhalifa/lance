using Wego.Application.Models.Common;
using Wego.Application.Models.Profile;
using Wego.Domain.Common;
using Wego.Domain.Profile;
using WegoPro.Domain.Profile;

namespace Wego.Application.IService.Feature.Profile;

public interface IProfileService
{
    Task<ImageProfileResponse> SaveImageAsync(ImageProfileModel model, CancellationToken cancellationtoken);
    Task<ImageProfileResponse> GetImageByIdAsync(long profileId, CancellationToken ct);
    Task<bool> DeleteImageByIdAsync(long fileId, CancellationToken ct);
    Task<ProfileInfoResponse> GetProfileInfo(string suID, CancellationToken cancellationtoken);
    Task<ProfileModel> GetProfileByEmailAsync(string email, CancellationToken cancellationtoken);
    Task<long> AddProfileInfoAsync(ProfileModel profile, CancellationToken cancellationtoken);
    Task<ProfileModel> GetProfileByUserIdAsync(string userId, CancellationToken cancellationtoken);
    Task<BackGroundResponse> GetBackGroundByIdAsync(long fid, CancellationToken cancellationtoken);
    Task<long> GetBackGroundByProfileIdAsync(long pid, CancellationToken cancellationtoken);
    Task<long> SaveBackGroundProfileAsync(BackGroundModel file, CancellationToken cancellationtoken);
    Task<FileResponse> GetFileByIdAsync(long fileId, CancellationToken cancellationtoken);
    Task<IEnumerable<AllBackGroundResponse>> GetAllBackGroundAsync(CancellationToken cancellationtoken);
    Task<long>SaveBackGroudProfile(BackGroundProfileModel model,  CancellationToken cancellationtoken);
}
