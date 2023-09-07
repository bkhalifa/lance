using MediatR;

using Wego.Application.IService;
using Wego.Domain.Profile;

namespace Wego.Application.Features.Profile.Queries;

public record GetImageByIdQuery(long pid) : IRequest<ImageProfileResponse>;
public class GetImageByIdQueryHandler : IRequestHandler<GetImageByIdQuery, ImageProfileResponse>
{
    private readonly IProfileService _profileService;
    public GetImageByIdQueryHandler(IProfileService profileService)
    {
        _profileService = profileService;
    }
    public Task<ImageProfileResponse> Handle(GetImageByIdQuery request, CancellationToken cancellationToken)
    {
        return _profileService.GetImageByIdAsync(request.pid);
    }
}
