using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Wego.Application.Features.Categories.Queries;

namespace Wego.Api.Controllers.Features
{
    [Route("api/[controller]")]
    [ApiController]
    public class ReferentialController : ControllerBase
    {
        private readonly IMediator _mediator;

        public ReferentialController(IMediator mediator)
        {
            _mediator = mediator;
        }

        //[Authorize]
        [HttpGet("all", Name = "GetAllCategories")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<ActionResult<List<GetCategoriesModel>>> GetAllCategories()
        {
            var dtos = await _mediator.Send(new GetCategoriesListQuery());
            return Ok(dtos);
        }

    }
}
