using MediatR;

using Wego.Application.IService.Feature.Profile;
using Wego.Application.Models.Profile;
using Wego.Domain.Profile;

namespace Wego.Application.Features.Profile.Commands;

public record ImageProfileModelCommand(ImageProfileModel model, CancellationToken cancellationToken = default) 
                                      : IRequest<ImageProfileResponse>;

public class ImageProfileCommandHandler : IRequestHandler<ImageProfileModelCommand, ImageProfileResponse>
{
    private readonly IProfileService _profileService;
    public ImageProfileCommandHandler(IProfileService profileService)
    {
        _profileService = profileService;
    }

    public async Task<ImageProfileResponse> Handle(ImageProfileModelCommand request, CancellationToken cancellationToken)
    => await _profileService.SaveImageAsync(request.model, cancellationToken).ConfigureAwait(false);

}
