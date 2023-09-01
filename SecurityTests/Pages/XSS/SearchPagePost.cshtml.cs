using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace SecurityTests.Pages.XSS
{
    [IgnoreAntiforgeryToken]
    public class SearchPagePostModel : PageModel
    {
        public string Result { get; set; } = string.Empty;
        public void OnPost()
        {
            string searchTerm = Request.Form["searchTerm"];
            this.Result = string.IsNullOrEmpty(searchTerm) ?
            "" : $"Your search for <i>{searchTerm}</i> did not yield any results.";
        }

    }
}