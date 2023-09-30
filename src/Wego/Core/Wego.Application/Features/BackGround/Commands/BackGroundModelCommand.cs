using MediatR;

using Wego.Application.IService.Feature.Profile;
using Wego.Application.Models.Common;
using Wego.Domain.Common;

namespace Wego.Application.Features.BackGround.Commands
{
    public record BackGroundModelCommand(BackGroundModel model, CancellationToken cancellationToken = default) : IRequest<long>;

    public class BackGroundModelCommandHandler : IRequestHandler<BackGroundModelCommand, long>
    {
        private readonly IProfileService _profileService;
        public BackGroundModelCommandHandler(IProfileService profileService)
        {
            _profileService = profileService;
        }
        public async Task<long> Handle(BackGroundModelCommand request, CancellationToken cancellationToken)
        {
            var result = await _profileService.SaveBackGroundProfileAsync(request.model, cancellationToken).ConfigureAwait(false);
            return result;
        }
    }

}
