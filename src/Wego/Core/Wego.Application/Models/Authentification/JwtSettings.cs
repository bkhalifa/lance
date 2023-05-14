namespace Wego.Application.Models.Authentification;

public class JwtSettings
{
    public string Name { get; set; }
    public string Key { get; set; }
    public string RefreshName { get; set; }
    public string RefreshKey { get; set; }
    public string Issuer { get; set; }
    public string Audience { get; set; }
    public double DurationInMinutes { get; set; }
}
