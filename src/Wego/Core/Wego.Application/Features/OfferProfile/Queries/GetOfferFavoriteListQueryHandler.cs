using MediatR;
using Wego.Application.Contracts.Context;
using Wego.Application.Contracts.Persistence;
using Wego.Application.Exceptions;
using Wego.Application.Extensions;
using Wego.Application.Models.Common;
using Wego.Domain.Entities;

namespace Wego.Application.Features.OfferProfile.Queries
{
    public record GetOfferFavoriteListQuery() : IRequest<List<GetOfferFavoriteModel>>;

    public class GetOfferFavoriteListQueryHandler : IRequestHandler<GetOfferFavoriteListQuery, List<GetOfferFavoriteModel>>
    {
        private readonly IBaseRepository<OfferProfileFavorite> _favoriteRepository;
        private readonly IBaseRepository<UserProfile> _userProfile;
        private readonly ICurrentContext _currentContext;

        public GetOfferFavoriteListQueryHandler(IBaseRepository<OfferProfileFavorite> favoriteRepository, IBaseRepository<UserProfile> userProfile, ICurrentContext currentContext)
        {
            _favoriteRepository = favoriteRepository;
            _userProfile = userProfile;
            _currentContext = currentContext;
        }

        public async Task<List<GetOfferFavoriteModel>> Handle(GetOfferFavoriteListQuery request, CancellationToken cancellationToken)
        {
            var profile = await _userProfile.SingleOrDefaultAsync(x => x.Email == _currentContext.Identity.Email);
            if (profile == null) throw new UserNotFoundException($"Email '{_currentContext.Identity.Email}' not found");
         
            var result = await _favoriteRepository.FindAsync(x=> x.ProfileId == profile.Id,"Offerfavorite"+ profile.Id, CacheDuration.OneDay, cancellationToken);
            return result.MapTo<List<GetOfferFavoriteModel>>();
        }
    }

}
