using Wego.Application.Models.Profile;
using Wego.Domain.Common;
using Wego.Domain.Profile;

namespace Wego.Application.IRepository;

public interface IProfileRepository
{
    Task<long> CreateImageAsync(ImageProfileModel model, CancellationToken cancellationtoken);
    Task UpdateImageAsync(ImageProfileModel model, CancellationToken cancellationtoken);
    Task<ImageProfileResponse> GetImageByIdAsync(long FileId, CancellationToken cancellationtoken);
    Task<ImageProfileResponse> GetImageByProfileIdAsync(long pid, CancellationToken cancellationtoken);
    Task<ProfileModel> GetProfileAsync(string suId, CancellationToken cancellationtoken);
    Task<long> AddProfileInfoAsync(ProfileModel profile, CancellationToken cancellationtoken);
    Task<ProfileModel> GetProfileByEmailAsync(string email, CancellationToken cancellationtoken);
    Task<ProfileModel> GetProfileByUserIdAsync(string userId, CancellationToken cancellationtoken);
    Task<string> CheckProfileIfExistByUsIdAsync(string usId, CancellationToken cancellationtoken);
    Task<bool> DeleteImageByIdAsync(long fileId, CancellationToken cancellationtoken);
    Task<long> SaveBackGroundAsync(BackGroundFile file, CancellationToken cancellationtoken);
    Task<BackGroundResponse> GetBgImageByIdAsync(long fileId, CancellationToken cancellationtoken);
    Task<IEnumerable<AllBackGroundResponse>> GetAllBackGroundAsync(CancellationToken cancellationtoken);
}

