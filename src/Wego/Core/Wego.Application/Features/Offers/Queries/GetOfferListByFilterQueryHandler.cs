
using MediatR;
using Wego.Application.Extensions;
using Wego.Application.IRepo;
using Wego.Domain.Offers;

namespace Wego.Application.Features.Jobs.Queries
{
    public record GetOfferListByFilterQuery(string? Query, string Locations, string Skills, string Seniorities, string ContractTypes, string WorkTypes, OrderByType? OrderBy,
    decimal? SalaryMin, decimal? DailyRateMin, int PageIndex = 1, int PageSize = 10) : IRequest<List<OfferSearchModel>>;

    public class GetOfferListByFilterQueryHandler : IRequestHandler<GetOfferListByFilterQuery, List<OfferSearchModel>>
    {
        private readonly IOfferRepository _offerRepository;

        public GetOfferListByFilterQueryHandler(IOfferRepository offerRepository)
        {
            _offerRepository = offerRepository;
        }

        public async Task<List<OfferSearchModel>> Handle(GetOfferListByFilterQuery request, CancellationToken cancellationToken)
        {
            var param = request.MapTo<OfferFilterParam>();
            var result = await _offerRepository.GetOffersByFilterAsync(param, cancellationToken);

            return result.ToList();

        }

    }

}
