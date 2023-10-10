using MediatR;

using Wego.Application.IService.Feature.Profile;
using Wego.Domain.Common;

namespace Wego.Application.Features.Profile.Queries;

public record GetBgImageByIdQuery(long fid, CancellationToken cancellationtoken = default) : IRequest<BackGroundResponse>;
public class GetBgImageByIdQueryHandler : IRequestHandler<GetBgImageByIdQuery, BackGroundResponse>
{
    private readonly IProfileService _profileService;
    public GetBgImageByIdQueryHandler(IProfileService profileService)
    {
        _profileService = profileService;
    }
    public async Task<BackGroundResponse> Handle(GetBgImageByIdQuery request, CancellationToken cancellationtoken = default)
    => await _profileService.GetBackGroundByIdAsync(request.fid, cancellationtoken);

}
