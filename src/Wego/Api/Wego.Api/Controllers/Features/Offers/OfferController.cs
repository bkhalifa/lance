using MediatR;

using Microsoft.AspNetCore.Mvc;

using Wego.Application.Features.Jobs.Queries;
using Wego.Application.Features.Offers.Queries;
using Wego.Domain.Offers;

namespace Wego.Api.Controllers.Features.offers
{
    [Route("api/offer")]
    [ApiController]
    public class OfferController : ControllerBase
    {
        private readonly IMediator _mediator;

        public OfferController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost("search-offers")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<ActionResult<List<OfferSearchModel>>> GetOfferListByFilter([FromBody] GetOfferListByFilterQuery request)
        {
            var dtos = await _mediator.Send(request);
            return Ok(dtos);
        }

        [HttpGet("get-offer")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<ActionResult<OfferModel>> GetOfferById([FromQuery] GetOfferByIdQuery request)
        {
            var dtos = await _mediator.Send(request);
            return Ok(dtos);
        }

    }
}
