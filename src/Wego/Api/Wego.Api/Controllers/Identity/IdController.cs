using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

using Wego.Application.Contracts.Identity;
using Wego.Application.Models.Authentification;

namespace Wego.Api.Controllers.Identity;


[Route("api/[controller]")]
[ApiController]
public class IdController : ControllerBase
{
    private readonly IAuthenticationService _authenticationService;
    private readonly IHttpContextAccessor _currentContext;
    public IdController(IAuthenticationService authenticationService, IHttpContextAccessor currentContext)
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


    [HttpPost(nameof(Logout))]
    [Authorize]
    public async Task<ActionResult<AuthenticationResponse>> Logout([FromBody] LogoutModel logoutModel)
    {
        await _authenticationService.LogoutAsync(logoutModel);
        return Ok();
    }


    [HttpPost(nameof(Refresh))]
    public async Task<ActionResult<TokenModel>> Refresh([FromBody] TokenModel tokenModel)
    {
        var result = await _authenticationService.RefreshAsync(tokenModel);
        return Ok(result);
    }

}
