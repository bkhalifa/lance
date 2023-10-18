using MediatR;
using Wego.Application.IService.Feature.Profile;
using WegoPro.Domain.Profile;

namespace Wego.Application.Features.Profile.Queries;

public record GetFileByIdQuery(long fileId, CancellationToken cancellationtoken = default) : IRequest<FileResponse>;
public class GetFileByIdQueryHandler : IRequestHandler<GetFileByIdQuery, FileResponse>
{
    private readonly IProfileService _profileService;
    public GetFileByIdQueryHandler(IProfileService profileService)
    {
        _profileService = profileService;
    }
    public async Task<FileResponse> Handle(GetFileByIdQuery request, CancellationToken cancellationtoken = default)
    => await _profileService.GetFileByIdAsync(request.fileId, cancellationtoken);

}
