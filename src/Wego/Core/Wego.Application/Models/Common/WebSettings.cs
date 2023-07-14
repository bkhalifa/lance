namespace Wego.Application.Models.Common
{
    public class WebSettings: IWebSettings
    {
        public string Url { get; set; }
    }
    public interface IWebSettings
    {
        public string Url { get; set; }
    }

}
