using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Wego.Application.Features.Categories.Queries;
using Wego.Application.Features.Locations.Queries;

namespace Wego.Api.Controllers.Features
{
    [Route("api/[controller]")]
    [ApiController]
    public class LocationController : ControllerBase
    {
        private readonly IMediator _mediator;

        public LocationController(IMediator mediator)
        {
            _mediator = mediator;
        }

        //[Authorize]
        [HttpGet(nameof(GetLocationsByCode))]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<ActionResult<List<GetLocationsByCodeModel>>> GetLocationsByCode(string code)
        {
            var dtos = await _mediator.Send(new GetLocationsByCodeListQuery(code));
            return Ok(dtos);
        }

        //[Authorize]
        [HttpGet(nameof(GetLocationsByQuery))]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<ActionResult<List<GetLocationsByQueryModel>>> GetLocationsByQuery(string query)
        {
            var dtos = await _mediator.Send(new GetLocationsByQueryListQuery(query));
            return Ok(dtos);
        }

    }
}
