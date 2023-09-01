using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Net.Http.Headers;

namespace SecurityTests.Pages.SessionHijacking
{
    public class SessionWriteModel : PageModel
    {
        public string UserAgent { get; set; } = string.Empty;
        public void OnGet()
        {
            this.UserAgent = HttpContext.Request.Headers[HeaderNames.UserAgent];
            HttpContext.Session.SetString(
                "browser",
                this.UserAgent
            );
        }
    }
}