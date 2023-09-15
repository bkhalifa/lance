using MediatR;

using Wego.Application.IService.Feature.Profile;
using Wego.Application.Models.Profile;

namespace Wego.Application.Features.Profile.Queries;


public record GetProfileInfoQuery(string usId, CancellationToken ct = default) : IRequest<ProfileInfoResponse>;

public class GetProfileInfoQueryHandler : IRequestHandler<GetProfileInfoQuery, ProfileInfoResponse>
{
    private readonly IProfileService _profileService;
    public GetProfileInfoQueryHandler(IProfileService profileService)
    {
        _profileService = profileService;
    }

    public async Task<ProfileInfoResponse> Handle(GetProfileInfoQuery request, CancellationToken cancellationToken)
    {
        return await _profileService.GetProfileInfo(request.usId, cancellationToken).ConfigureAwait(false);
    }
}

