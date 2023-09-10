using System.Drawing;

using Wego.Application.Features.Profile.Commands;
using Wego.Application.IRepository;
using Wego.Application.IService.Feature.Profile;
using Wego.Domain.Profile;

namespace Wego.Infrastructure.Services.Feature.Profile;

public class ProfileService : IProfileService
{
    private readonly IProfileRepository _profileRepository;
    public ProfileService(IProfileRepository profileRepository)
    {
        _profileRepository = profileRepository;
    }
    public async Task<long> SaveImageAsync(ImageProfileModelCommand model)
    {
        var image = await _profileRepository.GetImageByIdAsync(model.ProfileId);

        if(image is null)
        {
            return await _profileRepository.CreateImageAsync(model).ConfigureAwait(false);
        }

        return await _profileRepository.UpdateImageAsync(model).ConfigureAwait(false);
    }

    public async Task<ImageProfileResponse> GetImageByIdAsync(long fileId)
    {
        var result = await _profileRepository.GetImageByIdAsync(fileId);

       return result;
    }

}
