using Wego.Application.Features.Profile.Commands;
using Wego.Domain.Profile;

namespace Wego.Application.IService.Feature.Profile;

public interface IProfileService
{
    Task<long> SaveImageAsync(ImageProfileModelCommand model);
    Task<ImageProfileResponse> GetImageByIdAsync(long profileId);
    Task<ProfileModel> GetProfileInfo(string suiD, long pid);
}
