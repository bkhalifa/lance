using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

using Wego.Application.Contracts.Identity;
using Wego.Application.Models.Authentification;

namespace Wego.Api.Controllers.Identity;


[Route("api/id")]
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

    [HttpPost("login")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status500InternalServerError)]
    [ProducesResponseType(StatusCodes.Status401Unauthorized)]
    public async Task<ActionResult<AuthenticationResponse>> Login([FromBody] AuthenticationRequest request)
     => Ok(await _authenticationService.LoginAsync(request));


    [HttpPost("register")]
    public async Task<ActionResult<RegistrationResponse>> Register([FromBody] RegistrationRequest request)
    => Ok(await _authenticationService.RegisterAsync(request));

    [HttpPost(nameof(RegisterConfirm))]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status500InternalServerError)]
    public async Task<ActionResult<TokenModel>> RegisterConfirm([FromBody] ConfirmRegisterModel request)
    => Ok(await _authenticationService.ConfirmRegistration(request));


    [HttpPost(nameof(Reset))]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status500InternalServerError)]
    public async Task<ActionResult<TokenModel>> Reset([FromBody] ResetPasswordModel request)
    => Ok(await _authenticationService.ResetRegistration(request));


    [HttpPost(nameof(Logout))]
    [Authorize]
    public async Task<ActionResult<AuthenticationResponse>> Logout([FromBody] LogoutModel logoutModel)
    {
        await _authenticationService.LogoutAsync(logoutModel);
        return Ok();
    }

    [HttpPost(nameof(Refresh))]
    public async Task<ActionResult<TokenModel>> Refresh([FromBody] TokenModel tokenModel)
     => Ok(await _authenticationService.RefreshAsync(tokenModel));


    [HttpPost(nameof(Forgot))]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status500InternalServerError)]
    public async Task<ActionResult<bool>> Forgot([FromBody] ForgotPasswordModel request)
       => Ok(await _authenticationService.ForgotPassword(request));



}
