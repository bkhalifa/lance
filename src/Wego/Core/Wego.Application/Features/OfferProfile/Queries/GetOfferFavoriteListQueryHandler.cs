using MediatR;
using Wego.Application.Contracts.Context;
using Wego.Application.IRepo;
using Wego.Domain.OfferProfile;

namespace Wego.Application.Features.OfferProfile.Queries
{
    public record GetOfferFavoriteListQuery() : IRequest<List<OfferFavoriteModel>>;

    public class GetOfferFavoriteListQueryHandler : IRequestHandler<GetOfferFavoriteListQuery, List<OfferFavoriteModel>>
    {
        private readonly IOfferProfileRepository _favoriteRepository;
        private readonly ICurrentContext _currentContext;
        public GetOfferFavoriteListQueryHandler(IOfferProfileRepository favoriteRepository, ICurrentContext currentContext)
        {
            _favoriteRepository = favoriteRepository;
            _currentContext = currentContext;
        }

        public async Task<List<OfferFavoriteModel>> Handle(GetOfferFavoriteListQuery request, CancellationToken cancellationToken)
        {
            var result = await _favoriteRepository.GetAllAsync(_currentContext.Identity.ProfileId, cancellationToken);
            return result.ToList();
        }
    }
}
