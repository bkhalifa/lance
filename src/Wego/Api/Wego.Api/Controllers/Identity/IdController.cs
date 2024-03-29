﻿using Microsoft.AspNetCore.Authorization;
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
    public async Task<ActionResult<AuthenticationResponse>> Login([FromBody] AuthenticationRequest request, CancellationToken cancellationToken = default)
     => Ok(await _authenticationService.LoginAsync(request, cancellationToken));


    [HttpPost("register")]
    public async Task<ActionResult<RegistrationResponse>> Register([FromBody] RegistrationRequest request, CancellationToken cancellationToken = default)
    => Ok(await _authenticationService.RegisterAsync(request, cancellationToken));

    [HttpPost(nameof(RegisterConfirm))]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status500InternalServerError)]
    public async Task<ActionResult<TokenModel>> RegisterConfirm([FromBody] ConfirmRegisterModel request, CancellationToken cancellationToken = default)
    => Ok(await _authenticationService.ConfirmRegistration(request, cancellationToken));


    [HttpPost(nameof(Reset))]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status500InternalServerError)]
    public async Task<ActionResult<TokenModel>> Reset([FromBody] ResetPasswordModel request, CancellationToken cancellationToken = default)
    => Ok(await _authenticationService.ResetRegistration(request, cancellationToken));


    [HttpPost(nameof(Logout))]
    [Authorize]
    public async Task<ActionResult<AuthenticationResponse>> Logout([FromBody] LogoutModel logoutModel, CancellationToken cancellationToken = default)
    {
        await _authenticationService.LogoutAsync(logoutModel, cancellationToken);
        return Ok();
    }

    [HttpPost(nameof(Refresh))]
    public async Task<ActionResult<TokenModel>> Refresh([FromBody] TokenModel tokenModel, CancellationToken cancellationToken = default)
     => Ok(await _authenticationService.RefreshAsync(tokenModel, cancellationToken));


    [HttpPost(nameof(Forgot))]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status500InternalServerError)]
    public async Task<ActionResult<bool>> Forgot([FromBody] ForgotPasswordModel request)
       => Ok(await _authenticationService.ForgotPassword(request));



}
