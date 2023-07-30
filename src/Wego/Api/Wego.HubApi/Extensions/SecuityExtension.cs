using Microsoft.AspNetCore.Antiforgery;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Primitives;

namespace Wego.HubApi.Extensions
{
    public static class SecuityExtension
    {
        public static IApplicationBuilder UseSecureHttpHeader(this IApplicationBuilder app)
       => app.Use((ctx, next) =>
       {
           // https://developer.mozilla.org/en-US/docs/Web/HTTP/Headers/X-XSS-Protection
           ctx.Response.Headers["x-xss-protection"] = new StringValues("1; mode=block");

           // https://developer.mozilla.org/en-US/docs/Web/HTTP/CSP
           // https://developer.mozilla.org/en-US/docs/Web/HTTP/Headers/Content-Security-Policy
           ctx.Response.Headers.Add("Content-Security-Policy", new StringValues(
               "base-uri 'none';" +
               "block-all-mixed-content;" +
               "child-src 'none';" +
               "connect-src 'none';" +
               "default-src 'none';" +
               "font-src 'none';" +
               "form-action 'none';" +
               "frame-ancestors 'none';" +
               "frame-src 'none';" +
               "img-src 'none';" +
               "manifest-src 'none';" +
               "media-src 'none';" +
               "object-src 'none';" +
               "sandbox;" +
               "script-src 'none';" +
               "script-src-attr 'none';" +
               "script-src-elem 'none';" +
               "style-src 'none';" +
               "style-src-attr 'none';" +
               "style-src-elem 'none';" +
               "upgrade-insecure-requests;" +
               "worker-src 'none';"
               ));

           return next();
       });    
    }
}
