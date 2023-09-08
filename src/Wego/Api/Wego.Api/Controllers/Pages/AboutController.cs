using MediatR;

using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

using Wego.Application.Features.Categories.Queries;

namespace Wego.Api.Controllers.Pages
{
    [Route("api/[controller]")]
    [ApiController]

    public class AboutController : ControllerBase
    {
        public readonly IMediator _mediator;
        public AboutController(IMediator mediator)   
        {
            _mediator = mediator;
        }
    }
}
