using MediatR;

using System.ComponentModel.DataAnnotations;

using Wego.Application.IService.Feature.Profile;

namespace Wego.Application.Features.Profile.Commands;

public record DeleteImageProfileModelCommand([Required] long fileId, CancellationToken cancellationToken = default) : IRequest<bool>;
public class DeleteImageProfileCommandHandler : IRequestHandler<DeleteImageProfileModelCommand, bool>
{
    private readonly IProfileService _profileService;
    public DeleteImageProfileCommandHandler(IProfileService profileService)
    {
        _profileService = profileService;
    }

    public async Task<bool> Handle(DeleteImageProfileModelCommand request, CancellationToken cancellationToken)
     => await _profileService.DeleteImageByIdAsync(request.fileId, cancellationToken).ConfigureAwait(false);
    
}
