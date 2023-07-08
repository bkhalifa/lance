using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

using System.Security.Claims;

using Wego.Application.Contracts.Context;
using Wego.Application.Contracts.Identity;
using Wego.Application.Features.Jobs.Queries;
using Wego.Application.Features.OfferProfile.Commands;
using Wego.Application.Features.OfferProfile.Queries;
using Wego.Application.Features.Offers.Queries;
using Wego.Application.Models.Authentification;
using Wego.Infrastructure.Context;

namespace Wego.Api.Controllers.Features;


[Route("api/[controller]")]
[ApiController]
public class OfferProfileController : ControllerBase
{
    private readonly IMediator _mediator;

    public OfferProfileController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpGet(nameof(GetOfferFavoriteList))]
    [ProducesResponseType(StatusCodes.Status200OK)]
    public async Task<ActionResult<List<GetOfferFavoriteListQuery>>> GetOfferFavoriteList()
    {
        var dtos = await _mediator.Send(new GetOfferFavoriteListQuery());
        return Ok(dtos);
    }

    [HttpPost(nameof(AddOfferFavorite))]
    [ProducesResponseType(StatusCodes.Status200OK)]
    public async Task<IActionResult> AddOfferFavorite([FromBody]long offerId)
    {
        var dtos = await _mediator.Send(new AddOfferFavoriteCommand(offerId));
        return Ok();
    }

    [HttpPost(nameof(RemoveOfferFavorite))]
    [ProducesResponseType(StatusCodes.Status200OK)]
    public async Task<IActionResult> RemoveOfferFavorite([FromBody] long offerId)
    {
        var dtos = await _mediator.Send(new RemoveOfferFavoriteCommand(offerId));
        return Ok();
    }


}
