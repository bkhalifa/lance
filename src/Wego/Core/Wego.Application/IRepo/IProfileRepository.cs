using Wego.Application.Features.Profile.Commands;
using Wego.Domain.OfferProfile;
using Wego.Domain.Profile;

namespace Wego.Application.IRepository;

public interface IProfileRepository
{
    Task<long> CreateImageAsync(ImageProfileModelCommand model);
    Task<ImageProfileResponse> GetImageByIdAsync(long profileId);
    Task<ProfileModel> GetProfileAsync(long profileId);
    Task<long> AddProfileAsync(ProfileModel profile);
    Task<ProfileModel> GetProfileByEmailAsync(string email);
    Task<ProfileModel> GetProfileByUserIdAsync(string userId);

}
