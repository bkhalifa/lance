using Wego.Application.Features.Profile.Commands;
using Wego.Domain.Profile;

namespace Wego.Application.IService;

public interface IProfileService
{
    Task<long> SaveImageAsync(ImageProfileModelCommand model);
    Task<ImageProfileResponse> GetImageByIdAsync(long profileId);

}
