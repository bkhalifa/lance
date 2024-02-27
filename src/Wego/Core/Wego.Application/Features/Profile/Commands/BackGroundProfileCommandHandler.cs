using MediatR;

using Wego.Application.IService.Feature.Profile;
using Wego.Application.Models.Profile;

namespace Wego.Application.Features.Profile.Commands;

public record BackGroundProfileCommand(long profileId, BackGroundProfileModel backGroundProfileModel, CancellationToken cancellationToken = default) : IRequest<long>;
public class BackGroundProfileCommandHandler : IRequestHandler<BackGroundProfileCommand, long>
{
    private readonly IProfileService _profileService;
    public BackGroundProfileCommandHandler(IProfileService profileService)
    {
        _profileService = profileService;       
    }
    public async Task<long> Handle(BackGroundProfileCommand request, CancellationToken cancellationToken)
    {
        return await _profileService.SaveBackGroudProfile(request.profileId, request.backGroundProfileModel, cancellationToken);
    }
}
