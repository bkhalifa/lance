using MediatR;

using Wego.Application.IService.Feature.Profile;
using Wego.Domain.Profile;

namespace Wego.Application.Features.Profile.Queries;


public record GetProfileInfoQuery(string usId) : IRequest<ProfileModel>;

public class GetProfileInfoQueryHandler : IRequestHandler<GetProfileInfoQuery, ProfileModel>
{
    private readonly IProfileService _profileService;
    public GetProfileInfoQueryHandler(IProfileService profileService)
    {
        _profileService = profileService;
    }

    public async Task<ProfileModel> Handle(GetProfileInfoQuery request, CancellationToken cancellationToken)
    {
        return await _profileService.GetProfileInfo(request.usId).ConfigureAwait(false);
    }
}

