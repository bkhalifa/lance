using Microsoft.AspNetCore.Mvc;

using Wego.Application.Contracts.Identity;
using Wego.Application.Models.Authentification;

namespace Wego.Api.Controllers.Identity;


[Route("api/id")]
[ApiController]
public class IdController : ControllerBase
{
    private readonly IAuthenticationService _authenticationService;
    public IdController(IAuthenticationService authenticationService)
    {
        _authenticationService = authenticationService;
    }

    [HttpPost("login")]
    public async Task<ActionResult<AuthenticationResponse>> AuthenticateAsync(AuthenticationRequest request)
    {
        return Ok(await _authenticationService.AuthenticateAsync(request));
    }

    [HttpPost("register")]
    public async Task<ActionResult<RegistrationResponse>> RegisterAsync(RegistrationRequest request)
    {
        return Ok(await _authenticationService.RegisterAsync(request));
    }
}
