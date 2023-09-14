using Wego.Application.Features.Profile.Commands;
using Wego.Domain.Profile;

namespace Wego.Application.IService.Feature.Profile;

public interface IProfileService
{
    Task<long> SaveImageAsync(ImageProfileModelCommand model);
    Task<ImageProfileResponse> GetImageByIdAsync(long profileId);
    Task<ProfileModel> GetProfileInfo(string suID);
    Task<ProfileModel> GetProfileByEmailAsync(string email);
    Task<long> AddProfileInfoAsync(ProfileModel profile);
    Task<ProfileModel> GetProfileByUserIdAsync(string userId);
}
