using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace SecurityTests.Pages.Injection
{
    public class LoginModel : PageModel
    {
        public string SqlQuery { get; set; } = string.Empty;
        public void OnPost(string email, string password)
        {
            this.SqlQuery = String.Format(
            "SELECT * FROM users WHERE email='{0}' AND password='{1}'",
            email, password);
        }

    }
}