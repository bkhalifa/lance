using Wego.Application.Features.Profile.Commands;

using Wego.Domain.Profile;

namespace Wego.Application.IRepository;

public interface IProfileRepository
{
    Task<long> CreateImageAsync(ImageProfileModelCommand model);
    Task<ImageProfileResponse> GetImageByIdAsync(long profileId);

}
