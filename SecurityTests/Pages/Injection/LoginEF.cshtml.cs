using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using SecurityTests.Data;

namespace SecurityTests.Pages.Injection
{
	public class LoginEFModel : PageModel
	{
		public void OnPost(string email, string password)
		{
			UserContext db = new UserContext();
			var r = db.Users.Where(user => user.email == email && user.password == password);
			r.FirstOrDefault();

		}
		public string SqlQuery { get; set; }
	}
}