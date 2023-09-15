using Wego.Application.Features.Profile.Commands;
using Wego.Domain.Profile;

namespace Wego.Application.IRepository;

public interface IProfileRepository
{
    Task<long> CreateImageAsync(ImageProfileModelCommand model, CancellationToken cancellationtoken);
    Task<long> UpdateImageAsync(ImageProfileModelCommand model, CancellationToken cancellationtoken);
    Task<ImageProfileResponse> GetImageByIdAsync(long FileId, CancellationToken cancellationtoken);
    Task<ImageProfileResponse> GetImageByProfileIdAsync(long pid, CancellationToken cancellationtoken);
    Task<ProfileModel> GetProfileAsync(string suId, CancellationToken cancellationtoken);
    Task<long> AddProfileInfoAsync(ProfileModel profile, CancellationToken cancellationtoken);
    Task<ProfileModel> GetProfileByEmailAsync(string email, CancellationToken cancellationtoken);
    Task<ProfileModel> GetProfileByUserIdAsync(string userId, CancellationToken cancellationtoken);
    Task<string> CheckProfileIfExistByUsIdAsync(string usId, CancellationToken cancellationtoken);
}
