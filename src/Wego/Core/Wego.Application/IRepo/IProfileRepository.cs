using Wego.Application.Features.Profile.Commands;

namespace Wego.Application.IRepository;

public interface IProfileRepository
{
    Task<long> CreateImageAsync(ImageProfileModelCommand model);
    Task<byte[]> GetImageByIdAsync(long fileId);

}
