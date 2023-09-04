using MediatR;
using Microsoft.AspNetCore.Mvc;
using Wego.Application.Features.OfferProfile.Commands;
using Wego.Application.Features.OfferProfile.Queries;


namespace Wego.Api.Controllers.Features.offers;


[Route("api/offer-profile")]
[ApiController]
public class OfferProfileController : ControllerBase
{
    private readonly IMediator _mediator;

    public OfferProfileController(IMediator mediator)
    {


        _mediator = mediator;
    }

    [HttpGet("get-favorite-offers")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    public async Task<ActionResult<List<GetOfferFavoriteListQuery>>> GetOfferFavoriteList()
    {
        var dtos = await _mediator.Send(new GetOfferFavoriteListQuery());
        return Ok(dtos);
    }

    [HttpPost("add-favorite-offer")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    public async Task<IActionResult> AddOfferFavorite([FromBody] long offerId)
    {
        var dtos = await _mediator.Send(new AddOfferFavoriteCommand(offerId));
        return Ok();
    }

    [HttpPost("delete-favorite-offer")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    public async Task<IActionResult> DeleteOfferFavorite([FromBody] long offerId)
    {
        var dtos = await _mediator.Send(new DeleteOfferFavoriteCommand(offerId));
        return Ok();
    }


}
