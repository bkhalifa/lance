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

        if (image is null)
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

    public async Task<ProfileModel> GetProfileInfo(string suId, long pid)
    {
        ArgumentNullException.ThrowIfNull(pid);
        ArgumentNullException.ThrowIfNull(suId);
        return await _profileRepository.GetProfileAsync(pid, suId).ConfigureAwait(false);
    }

    public async Task<ProfileModel> GetProfileByEmailAsync(string email)
    {
        ArgumentNullException.ThrowIfNull(email);
        return await _profileRepository.GetProfileByEmailAsync(email).ConfigureAwait(false);
    }

    public async Task<long> AddProfileInfoAsync(ProfileModel profile)
    {
        ArgumentNullException.ThrowIfNull(profile);

        var existUSId = await _profileRepository.CheckProfileIfExistByUsIdAsync(profile.UsId);
        if (string.IsNullOrEmpty(existUSId)) { return await _profileRepository.AddProfileInfoAsync(profile).ConfigureAwait(false); }
        profile.SetUsId();

        return await _profileRepository.AddProfileInfoAsync(profile).ConfigureAwait(false);
    }

    public async Task<ProfileModel> GetProfileByUserIdAsync(string userId)
    {
        ArgumentNullException.ThrowIfNull(userId);
        return await _profileRepository.GetProfileByUserIdAsync(userId);
    }
}
