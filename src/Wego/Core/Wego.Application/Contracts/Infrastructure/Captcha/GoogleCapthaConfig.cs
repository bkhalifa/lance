namespace Wego.Application.Contracts.Infrastructure.Captcha;


public interface GoogleCapthaConfig : IGoogleCapthaConfig
{
    public string SiteSecret { get; set; }
    public string SecretKey { get; set; }
}
