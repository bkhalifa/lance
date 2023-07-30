using MediatR;
using System.ComponentModel.DataAnnotations;
using Wego.Application.Contracts.Context;
using Wego.Application.Contracts.Persistence;
using Wego.Application.Exceptions;
using Wego.Domain.Entities;

namespace Wego.Application.Features.OfferProfile.Commands
{
    public record RemoveOfferFavoriteCommand([Required] long OfferId) : IRequest<Unit>;

    public class RemoveOfferFavoriteCommandHandler : IRequestHandler<RemoveOfferFavoriteCommand, Unit>
    {
        private readonly IBaseRepository<OfferProfileFavorite> _favoriteRepository;
        private readonly IBaseRepository<UserProfile> _userProfile;
        private readonly ICurrentContext _currentContext;

        public RemoveOfferFavoriteCommandHandler(IBaseRepository<OfferProfileFavorite> favoriteRepository, IBaseRepository<UserProfile> userProfile, ICurrentContext currentContext)
        {
            _favoriteRepository = favoriteRepository;
            _userProfile = userProfile;
            _currentContext = currentContext;
        }

        public async Task<Unit> Handle(RemoveOfferFavoriteCommand command, CancellationToken cancellationToken)
        {
            var profile = await _userProfile.FirstOrDefaultAsync(x => x.Email == _currentContext.Identity.Email);
            if (profile == null) throw new UserNotFoundException($"Email '{_currentContext.Identity.Email}' not found");

            var favorite = await _favoriteRepository.FirstOrDefaultAsync(x => x.OfferId == command.OfferId && x.ProfileId == profile.Id);
            if (favorite != null)
                await _favoriteRepository.RemoveAsync(new OfferProfileFavorite
                {
                    ProfileId = profile.Id,
                    OfferId = command.OfferId,
                    CreatedDate = DateTime.UtcNow,
                });
            return Unit.Value;
        }
    }

}
