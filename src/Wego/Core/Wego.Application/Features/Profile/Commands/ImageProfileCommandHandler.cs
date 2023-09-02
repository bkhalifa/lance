using MediatR;

using Wego.Application.IRepository;

namespace Wego.Application.Features.Profile.Commands;

public record ImageProfileModelCommand(long ProfileId, byte[] Base64, int Width, int Height) : IRequest<long>;

public class ImageProfileCommandHandler : IRequestHandler<ImageProfileModelCommand, long>
{
    private readonly IProfileRepository _profileRepository;
    public ImageProfileCommandHandler(IProfileRepository profileRepository)
    {
        _profileRepository = profileRepository;
    }

    public async Task<long> Handle(ImageProfileModelCommand request, CancellationToken cancellationToken)
    {
        return await _profileRepository.CreateImageAsync(request);
    }
}
