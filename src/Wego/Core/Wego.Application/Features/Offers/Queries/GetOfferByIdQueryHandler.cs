using MediatR;
using Wego.Application.Contracts.Persistence;
using Wego.Application.Extensions;
using Wego.Application.Features.Offers.Queries;
using Wego.Domain.Entities;

namespace Wego.Application.Features.Offers.Queries
{
    public record GetOfferByIdQuery(int Id) : IRequest<GetOfferByIdModel>;

    public class GetOfferByIdQueryHandler : IRequestHandler<GetOfferByIdQuery, GetOfferByIdModel?>
    {
        private readonly IBaseRepository<OffersSearch> _repository;

        public GetOfferByIdQueryHandler(IBaseRepository<OffersSearch> repository)
        {
            _repository = repository;
        }

        public async Task<GetOfferByIdModel?> Handle(GetOfferByIdQuery request, CancellationToken cancellationToken)
        {
            var result = await _repository.SingleOrDefaultAsync((x) => x.Id == request.Id, cancellationToken: cancellationToken);
            return result?.MapTo<GetOfferByIdModel>();
        }
    }

}
