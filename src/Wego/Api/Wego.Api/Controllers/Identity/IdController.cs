using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
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
    public async Task<ActionResult<AuthenticationResponse>> Login([FromBody]AuthenticationRequest request)
    {
        return Ok(await _authenticationService.LoginAsync(request));
    }

    [HttpPost(nameof(Register))]
    public async Task<ActionResult<RegistrationResponse>> Register([FromBody] RegistrationRequest request)
    {
        return Ok(await _authenticationService.RegisterAsync(request));
    }

    [Authorize]
    [HttpPost(nameof(ChangePassword))]
    public async Task<ActionResult<AuthenticationResponse>> ChangePassword([FromBody] ResetPasswordRequest request)
    {
        await _authenticationService.ChangePasswordAsync(request.OldPassword, request.NewPassword);
        return Ok();
    }

    [Authorize]
    [HttpPost(nameof(Logout))]
    public async Task<ActionResult<AuthenticationResponse>> Logout()
    {
        await _authenticationService.LogoutAsync();
        return Ok();
    }

    [Authorize]
    [HttpPost(nameof(Refresh))]
    public async Task<ActionResult<TokenModel>> Refresh([FromBody] string refreshToken)
    {
        var result = await _authenticationService.RefreshAsync(refreshToken);
        return Ok(result);
    }

}
