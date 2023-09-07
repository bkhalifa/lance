using System.Drawing;

using Wego.Application.Features.Profile.Commands;
using Wego.Application.IRepository;
using Wego.Application.IService;
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
        if(model is not null)
        {
            var dataImage = ToThumbnail(model.Base64, 160, 160);

        }
        return await _profileRepository.CreateImageAsync(model).ConfigureAwait(false);
    }

    public async Task<ImageProfileResponse> GetImageByIdAsync(long profileId)
    {
        return await _profileRepository.GetImageByIdAsync(profileId);
    }

    private static byte[] ToThumbnail(byte[] myImage, int thumbWidth, int thumbHeight)
    {
        using (MemoryStream ms = new MemoryStream())
        using (Image thumbnail = Image.FromStream(new MemoryStream(myImage)).GetThumbnailImage(thumbWidth, thumbHeight, null, new IntPtr()))
        {
            thumbnail.Save(ms, System.Drawing.Imaging.ImageFormat.Png);
            return ms.ToArray();
        }
    }
}
