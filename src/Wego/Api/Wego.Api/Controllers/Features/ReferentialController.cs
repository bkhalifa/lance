using MediatR;

using Microsoft.AspNetCore.Mvc;

using Wego.Application.Features.Categories.Queries;
using Wego.Application.Features.Jobs.Queries;
using Wego.Application.Features.Skills.Queries;

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


        [HttpGet(nameof(GetAllCategories))]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<ActionResult<List<GetCategoriesModel>>> GetAllCategories()
        {
            var dtos = await _mediator.Send(new GetCategoriesListQuery());
            return Ok(dtos);
        }

        [HttpGet(nameof(GetAllSkills))]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<ActionResult<List<GetSkillModel>>> GetAllSkills()
        {
            var dtos = await _mediator.Send(new GetSkillListQuery());
            return Ok(dtos);
        }

        [HttpGet(nameof(GetAllBusinessSkills))]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<ActionResult<List<GetBusinessSkillModel>>> GetAllBusinessSkills()
        {
            var dtos = await _mediator.Send(new GetBusinessSkillListQuery());
            return Ok(dtos);
        }

        [HttpGet(nameof(GetAllContractTypes))]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<ActionResult<List<GetContractTypeModel>>> GetAllContractTypes()
        {
            var dtos = await _mediator.Send(new GetContractTypeListQuery());
            return Ok(dtos);
        }

        [HttpGet(nameof(GetAllWorkTypes))]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<ActionResult<List<GetWorkTypeModel>>> GetAllWorkTypes()
        {
            var dtos = await _mediator.Send(new GetWorkTypeListQuery());
            return Ok(dtos);
        }

        [HttpGet(nameof(GetAllJobLevels))]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<ActionResult<List<GetJobLevelModel>>> GetAllJobLevels()
        {
            var dtos = await _mediator.Send(new GetJobLevelListQuery());
            return Ok(dtos);
        }


    }
}
