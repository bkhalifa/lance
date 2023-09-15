using MediatR;
using Wego.Application.IService.Feature.Profile;
using Wego.Domain.Profile;

namespace Wego.Application.Features.Profile.Queries;

public record GetImageByIdQuery(long fid, CancellationToken cancellationtoken = default) : IRequest<ImageProfileResponse>;
public class GetImageByIdQueryHandler : IRequestHandler<GetImageByIdQuery, ImageProfileResponse>
{
    private readonly IProfileService _profileService;
    public GetImageByIdQueryHandler(IProfileService profileService)
    {
        _profileService = profileService;
    }
    public Task<ImageProfileResponse> Handle(GetImageByIdQuery request, CancellationToken cancellationtoken = default)
    {
        return _profileService.GetImageByIdAsync(request.fid, cancellationtoken);
    }
}
