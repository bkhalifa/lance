namespace Wego.Application.Contracts.Infrastructure.Captcha;

public interface IGoogleCapthaService
{
    Task<bool> VerifiyToken(string token);
}
