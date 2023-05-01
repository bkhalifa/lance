using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

using Wego.Application.Features.Categories.Queries.GetCategoriesList;

namespace Wego.Api.Controllers.Configuration
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoryController : ControllerBase
    {
        private readonly IMediator _mediator;

        public CategoryController(IMediator mediator)
        {
            _mediator = mediator;
        }

        //[Authorize]
        [HttpGet("all", Name = "GetAllCategories")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<ActionResult<List<CategoryListModel>>> GetAllCategories()
        {
            var dtos = await _mediator.Send(new GetCategoriesListQuery());
            return Ok(dtos);
        }

    }
}
