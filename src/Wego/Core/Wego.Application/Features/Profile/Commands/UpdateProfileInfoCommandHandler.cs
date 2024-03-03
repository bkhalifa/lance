using MediatR;


using Wego.Application.IService.Feature.Profile;
using Wego.Application.Models.Profile.request;
using Wego.Domain.Profile;

namespace Wego.Application.Features.Profile.Commands;

public record UpdateProfileInfoModelCommand(long profileId, ProfileInfoRequest profileInfoRequest, CancellationToken cancellationToken = default)  : IRequest<ProfileModel>;
public class UpdateProfileInfoCommandHandler : IRequestHandler<UpdateProfileInfoModelCommand, ProfileModel>
{
    private readonly IProfileService _profileService;
    public UpdateProfileInfoCommandHandler(IProfileService profileService)
    {
        _profileService = profileService;
    }

    public async Task<ProfileModel> Handle(UpdateProfileInfoModelCommand request, CancellationToken cancellationToken)
     => await _profileService.UpdateProfileInfoAsync(request.profileId, request.profileInfoRequest, cancellationToken).ConfigureAwait(false);

}
