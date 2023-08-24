namespace Wego.Application.Response;

public class GoogleCapthaConfig: IGoogleCapthaConfig
{
    public string SiteSecret { get; set; }
    public string SecretKey { get; set; }
}
