using MediatR;

using Wego.Application.IService.Feature.Profile;


namespace Wego.Application.Features.BackGround.Queries;

public record GetBackGroundImageByProfileIdQuery(long pid, CancellationToken cancellationtoken = default) : IRequest<long>;
public class GetBackGroundImageByProfileIdHandler : IRequestHandler<GetBackGroundImageByProfileIdQuery, long>
{
    private readonly IProfileService _profileService;
    public GetBackGroundImageByProfileIdHandler(IProfileService profileService)
    {
        _profileService = profileService;
    }
    public async Task<long> Handle(GetBackGroundImageByProfileIdQuery request, CancellationToken cancellationToken)
     => await _profileService.GetBackGroundByProfileIdAsync(request.pid, cancellationToken);

}
