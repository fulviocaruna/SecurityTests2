using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace SecurityTests.Pages.XSS
{
    public class CSPModel : PageModel
    {
        private String generateNonce()
        {
            var byteArray = new byte[32];
            using (var random = System.Security.Cryptography.RandomNumberGenerator.Create())
            {
                random.GetBytes(byteArray);
            }
            var token = Convert.ToBase64String(byteArray);

            return token;
        }

        public void OnGet()
        {
            // var cspHeader = "default-src 'self'";
            /*
            var cspHeader = "default-src 'self';" +
                            "img-src 'self' https://www.manning.com/assets/;";
            */

            /*
            var cspHeader = "default-src 'self';" +
                "img-src 'self' https://www.manning.com/assets/;" +
                "style-src 'self' https://cdn.jsdelivr.net; " +
                "script-src 'self' https://cdn.jsdelivr.net;";
            */

            /*
            var cspHeader = "default-src 'self';" +
    "img-src 'self' https://www.manning.com/assets/;" +
    "style-src 'self' https://cdn.jsdelivr.net 'nonce-19UoXyUC5RHumWo7PyZ/8o9WmaquPDfD49Xx+EEekDI=';" +
    "script-src 'self' https://cdn.jsdelivr.net 'nonce-19UoXyUC5RHumWo7PyZ/8o9WmaquPDfD49Xx+EEekDI=' 'unsafe-eval';";

            HttpContext.Response.Headers.Add(
                            "Content-Security-Policy",
                            cspHeader
                        );
            */

            var cspHeader = "default-src 'self';" +
   "img-src 'self' https://www.manning.com/assets/;" +
   "style-src 'self' https://cdn.jsdelivr.net 'nonce-19UoXyUC5RHumWo7PyZ/8o9WmaquPDfD49Xx+EEekDI=';" +
   "script-src 'self' https://cdn.jsdelivr.net 'nonce-19UoXyUC5RHumWo7PyZ/8o9WmaquPDfD49Xx+EEekDI=';" +
   "report-uri /api/cspcollectapi";

            HttpContext.Response.Headers.Add(
                            "Content-Security-Policy-Report-Only",
                            cspHeader
                        );
        }
    }
}
