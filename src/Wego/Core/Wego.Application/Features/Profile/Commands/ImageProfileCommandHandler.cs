using MediatR;

using Wego.Application.IService.Feature.Profile;
using Wego.Domain.Profile;

namespace Wego.Application.Features.Profile.Commands;

public record ImageProfileModelCommand(long ProfileId, byte[] Base64, int Width, int Height, string ContentType, CancellationToken cancellationToken = default) 
                                      : IRequest<ImageProfileResponse>;

public class ImageProfileCommandHandler : IRequestHandler<ImageProfileModelCommand, ImageProfileResponse>
{
    private readonly IProfileService _profileService;
    public ImageProfileCommandHandler(IProfileService profileService)
    {
        _profileService = profileService;
    }

    public async Task<ImageProfileResponse> Handle(ImageProfileModelCommand request, CancellationToken cancellationToken)
    => await _profileService.SaveImageAsync(request, cancellationToken).ConfigureAwait(false);

}
