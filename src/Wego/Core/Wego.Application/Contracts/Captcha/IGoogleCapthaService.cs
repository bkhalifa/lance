namespace Wego.Application.Contracts.Captcha;

public interface IGoogleCapthaService
{
    Task<bool> VerifiyToken(string token);
}
