using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

using System.Security.Claims;

using Wego.Application.Contracts.Context;
using Wego.Application.Contracts.Identity;
using Wego.Application.Models.Authentification;

namespace Wego.Api.Controllers.Identity;


[Route("api/[controller]")]
[ApiController]
public class IdController : ControllerBase
{
    private readonly IAuthenticationService _authenticationService;
    private readonly ICurrentContext _currentContext;
    public IdController(IAuthenticationService authenticationService, ICurrentContext currentContext)
    {
        _authenticationService = authenticationService;
        _currentContext = currentContext;
    }

    [HttpPost(nameof(Login))]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status500InternalServerError)]
    [ProducesResponseType(StatusCodes.Status401Unauthorized)]
    public async Task<ActionResult<AuthenticationResponse>> Login([FromBody] AuthenticationRequest request)
    {
        return Ok(await _authenticationService.LoginAsync(request));
    }

    [HttpPost(nameof(Register))]
    public async Task<ActionResult<RegistrationResponse>> Register([FromBody] RegistrationRequest request)
    {
        return Ok(await _authenticationService.RegisterAsync(request));
    }

    [HttpPost(nameof(ChangePassword))]
    [Authorize]
    public async Task<ActionResult<AuthenticationResponse>> ChangePassword([FromBody] ResetPasswordRequest request)
    {
        await _authenticationService.ChangePasswordAsync(request.OldPassword, request.NewPassword);
        return Ok();
    }


    [HttpDelete(nameof(Logout))]
    [Authorize]
    public async Task<ActionResult<AuthenticationResponse>> Logout()
    {
        string rawUserId = HttpContext.User.FindFirstValue("id")!;
       if(!Guid.TryParse(rawUserId, out Guid id))
        {
            return Unauthorized();
        }

        await _authenticationService.LogoutAsync();
        return NoContent();
    }


    [HttpPost(nameof(Refresh))]
    public async Task<ActionResult<TokenModel>> Refresh([FromBody] string refreshToken)
    {
        var result = await _authenticationService.RefreshAsync(refreshToken);
        return Ok(result);
    }

}
