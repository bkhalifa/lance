using MediatR;
using System.ComponentModel.DataAnnotations;
using Wego.Application.Contracts.Context;
using Wego.Application.IRepo;

namespace Wego.Application.Features.OfferProfile.Commands
{
    public record AddOfferFavoriteCommand([Required] long OfferId) : IRequest<Unit>;

    public class AddOfferFavoriteCommandHandler : IRequestHandler<AddOfferFavoriteCommand, Unit>
    {
        private readonly IOfferProfileRepository _favoriteRepository;
        private readonly ICurrentContext _currentContext;
        public AddOfferFavoriteCommandHandler(IOfferProfileRepository favoriteRepository, ICurrentContext currentContext)
        {
            _favoriteRepository = favoriteRepository;
            _currentContext = currentContext;
        }

        public async Task<Unit> Handle(AddOfferFavoriteCommand command, CancellationToken cancellationToken)
        {
            var favorite = await _favoriteRepository.GetOfferFavoriteAsync(command.OfferId, _currentContext.Identity.ProfileId);

            if (favorite == null)
                await _favoriteRepository.AddOfferFavoriteAsync(command.OfferId, _currentContext.Identity.ProfileId);
            return Unit.Value;
        }
    }

}
