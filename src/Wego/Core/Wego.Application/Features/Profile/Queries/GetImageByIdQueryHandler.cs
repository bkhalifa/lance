using MediatR;

using Wego.Application.IRepository;
using Wego.Domain.Profile;

namespace Wego.Application.Features.Profile.Queries;

public record GetImageByIdQuery(long fid) : IRequest<ImageProfileResponse>;
public class GetImageByIdQueryHandler : IRequestHandler<GetImageByIdQuery, ImageProfileResponse>
{
    private readonly IProfileRepository _profileRepository;
    public GetImageByIdQueryHandler(IProfileRepository profileRepository)
    {
        _profileRepository = profileRepository;
    }
    public Task<ImageProfileResponse> Handle(GetImageByIdQuery request, CancellationToken cancellationToken)
    {
        return _profileRepository.GetImageByIdAsync(request.fid);
    }
}
