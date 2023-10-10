using MediatR;

using Wego.Application.IService.Feature.Profile;
using Wego.Domain.Common;

namespace Wego.Application.Features.BackGround.Queries
{
    public record GetAllBackGroundQuery(CancellationToken cancellationtoken = default) : IRequest<IEnumerable<AllBackGroundResponse>>;
    public class GetAllBackGroundQueryHandler : IRequestHandler<GetAllBackGroundQuery, IEnumerable<AllBackGroundResponse>>
    {
        private readonly IProfileService _profileService;
        public GetAllBackGroundQueryHandler(IProfileService profileService)
        {
            _profileService = profileService;
        }
        public async Task<IEnumerable<AllBackGroundResponse>> Handle(GetAllBackGroundQuery request, CancellationToken cancellationToken)
         => await _profileService.GetAllBackGroundAsync(cancellationToken).ConfigureAwait(false);
    }
}
