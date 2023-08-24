using Newtonsoft.Json;

using Wego.Application.Contracts.Captcha;
using Wego.Application.Response;

namespace Wego.Infrastructure.Captcha;

public class GoogleCapthaService : IGoogleCapthaService
{
    private readonly IGoogleCapthaConfig _config;

    public GoogleCapthaService(IGoogleCapthaConfig config)
    {
        _config = config;
    }
    public async Task<bool> VerifiyToken(string token)
    {
        try
        {
            var url = $"https://www.google.com/recaptcha/api/siteverify?secret={_config.SecretKey}&response={token}";
            using (var client = new HttpClient())
            {
                var httpResult = await client.GetAsync(url);

                if (httpResult.StatusCode != System.Net.HttpStatusCode.OK)
                    return false;

                var responseString = await httpResult.Content.ReadAsStringAsync();

                var googleResult = JsonConvert.DeserializeObject<GoogleCaptchaResponse>(responseString);

                return googleResult.success && googleResult.score >= 0.5;
            }
        }
        catch (Exception)
        {
            return false;
        }
    }
}
