using Microsoft.AspNetCore.Mvc;

namespace SecurityTests.Controllers
{
    public class XSSController : Controller
    {
        public IActionResult Search()
        {
            return View();
        }

        public ContentResult SearchAPI(string searchTerm)
        {
            var results = new List<string>() {
             searchTerm + " 1",
             searchTerm + " 2",
             searchTerm + " 3"
            };

            return new ContentResult
            {
                // ContentType = "text/html",
                Content = $"[\"{string.Join("\", \"", results)}\"]"
            };
        }
    }
}