﻿using MediatR;
using Wego.Application.IRepo;
using Wego.Domain.Offers;

namespace Wego.Application.Features.Offers.Queries;

public record GetOfferByIdQuery(int Id) : IRequest<OfferModel>;

public class GetOfferByIdQueryHandler : IRequestHandler<GetOfferByIdQuery, OfferModel>
{
    private readonly IOfferRepository _offerRepository;

    public GetOfferByIdQueryHandler(IOfferRepository offerRepository)
    {
        _offerRepository = offerRepository;
    }

    public async Task<OfferModel> Handle(GetOfferByIdQuery request, CancellationToken cancellationToken)
    {
        return await _offerRepository.GetOffersByIdAsync(request.Id);
    }
}
