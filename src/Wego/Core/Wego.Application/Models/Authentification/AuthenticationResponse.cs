﻿namespace Wego.Application.Models.Authentification;

public class AuthenticationResponse
{
    public string Id { get; set; }
    public string UserName { get; set; }
    public string Email { get; set; }
    public string Token { get; set; }
    public string RefreshToken { get; set; }
}
