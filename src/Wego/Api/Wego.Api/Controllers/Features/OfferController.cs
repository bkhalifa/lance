using MediatR;

using Microsoft.AspNetCore.Mvc;

using Wego.Application.Features.Jobs.Queries;
using Wego.Application.Features.Offers.Queries;

namespace Wego.Api.Controllers.Features
{
    [Route("api/[controller]")]
    [ApiController]
    public class OfferController : ControllerBase
    {
        private readonly IMediator _mediator;

        public OfferController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost(nameof(GetOfferListByFilter))]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<ActionResult<List<GetOfferListByFilterModel>>> GetOfferListByFilter([FromBody] GetOfferListByFilterQuery request)
        {
            var dtos = await _mediator.Send(request);
            return Ok(dtos);
        }

        [HttpGet(nameof(GetOfferById))]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<ActionResult<GetOfferByIdModel?>> GetOfferById([FromQuery] GetOfferByIdQuery request)
        {
            var dtos = await _mediator.Send(request);
            return Ok(dtos);
        }

    }
}
