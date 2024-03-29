﻿using MediatR;

using Microsoft.AspNetCore.Mvc;

using Wego.Application.Features.Categories.Queries;
using Wego.Application.Features.Jobs.Queries;
using Wego.Application.Features.Skills.Queries;
using Wego.Domain.Common;

namespace Wego.Api.Controllers.Features.Common
{
    [Route("api/referential")]
    [ApiController]
    public class ReferentialController : ControllerBase
    {
        private readonly IMediator _mediator;

        public ReferentialController(IMediator mediator)
        {
            _mediator = mediator;
        }


        [HttpGet("categories")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<ActionResult<List<CategoryModel>>> GetAllCategories()
        {
            var dtos = await _mediator.Send(new GetCategoriesListQuery());
            return Ok(dtos);
        }

        [HttpGet("skills")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<ActionResult<List<SkillModel>>> GetAllSkills()
        {
            var dtos = await _mediator.Send(new GetSkillListQuery());
            return Ok(dtos);
        }

        [HttpGet("contracttypes")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<ActionResult<List<ContractTypeModel>>> GetAllContractTypes()
        {
            var dtos = await _mediator.Send(new GetContractTypeListQuery());
            return Ok(dtos);
        }

        [HttpGet("worktypes")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<ActionResult<List<WorkTypeModel>>> GetAllWorkTypes()
        {
            var dtos = await _mediator.Send(new GetWorkTypeListQuery());
            return Ok(dtos);
        }

        [HttpGet("joblevels")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<ActionResult<List<JobLevelModel>>> GetAllJobLevels()
        {
            var dtos = await _mediator.Send(new GetJobLevelListQuery());
            return Ok(dtos);
        }


    }
}
