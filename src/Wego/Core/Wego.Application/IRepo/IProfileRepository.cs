using Wego.Application.Features.Profile.Commands;
using Wego.Domain.Profile;

namespace Wego.Application.IRepository;

public interface IProfileRepository
{
    Task<long> CreateImageAsync(ImageProfileModelCommand model);
    Task<long> UpdateImageAsync(ImageProfileModelCommand model);
    Task<ImageProfileResponse> GetImageByIdAsync(long FileId);
    Task<ProfileModel> GetProfileAsync(string suId);
    Task<long> AddProfileInfoAsync(ProfileModel profile);
    Task<ProfileModel> GetProfileByEmailAsync(string email);
    Task<ProfileModel> GetProfileByUserIdAsync(string userId);
    Task<string> CheckProfileIfExistByUsIdAsync(string usId);
}
