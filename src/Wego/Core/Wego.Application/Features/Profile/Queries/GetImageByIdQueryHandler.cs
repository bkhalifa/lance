using MediatR;

using Wego.Application.IRepository;

namespace Wego.Application.Features.Profile.Queries;

public record GetImageByIdQuery(long fileId) : IRequest<byte[]>;
public class GetImageByIdQueryHandler : IRequestHandler<GetImageByIdQuery, byte[]>
{
    private readonly IProfileRepository _profileRepository;
    public GetImageByIdQueryHandler(IProfileRepository profileRepository)
    {
        _profileRepository = profileRepository;
    }
    public Task<byte[]> Handle(GetImageByIdQuery request, CancellationToken cancellationToken)
    {
        return _profileRepository.GetImageByIdAsync(request.fileId);
    }
}
