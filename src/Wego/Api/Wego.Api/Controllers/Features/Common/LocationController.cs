using MediatR;
using Microsoft.AspNetCore.Mvc;
using Wego.Application.Features.Locations.Queries;
using Wego.Domain.Common;

namespace Wego.Api.Controllers.Features.Common;

[Route("api/location")]
[ApiController]
public class LocationController : ControllerBase
{
    private readonly IMediator _mediator;

    public LocationController(IMediator mediator)
    {
        _mediator = mediator;
    }


    [HttpGet("get-query")]
    public async Task<ActionResult<LocationModel>> GetLocationsByQuery(string query)
        => Ok(await _mediator.Send(new GetLocationsByQueryListQuery(query)));

    [HttpGet("get-code")]
    public async Task<ActionResult<GetLocationsByCodeModel>> GetLocationsByCode(string codes)
        => Ok(await _mediator.Send(new GetLocationsByCodeListQuery(codes)));

}
