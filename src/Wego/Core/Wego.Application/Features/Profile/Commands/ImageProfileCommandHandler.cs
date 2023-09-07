using MediatR;

using Wego.Application.IService;

namespace Wego.Application.Features.Profile.Commands;

public record ImageProfileModelCommand(long ProfileId, byte[] Base64, int Width, int Height, string ContentType) : IRequest<long>;

public class ImageProfileCommandHandler : IRequestHandler<ImageProfileModelCommand, long>
{
    private readonly IProfileService _profileService;
    public ImageProfileCommandHandler(IProfileService profileService)
    {
        _profileService = profileService;
    }

    public async Task<long> Handle(ImageProfileModelCommand request, CancellationToken cancellationToken)
    {
        return await _profileService.SaveImageAsync(request).ConfigureAwait(false);
    }
}
