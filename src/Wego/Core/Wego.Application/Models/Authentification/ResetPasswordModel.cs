﻿namespace Wego.Application.Models.Authentification
{
    public class ResetPasswordModel
    {
        public string Email { get; set; }
        public string  Password { get; set; }
        public string Token { get; set; }
        public string TokenCaptcha { get; set; }
    }
}
