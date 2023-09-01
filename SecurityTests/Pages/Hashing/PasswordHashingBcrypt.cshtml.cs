using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace SecurityTests.Pages.Hashing
{
	public class PasswordHashingBcryptModel : PageModel
	{
		public string Message { get; set; } = string.Empty;

		[BindProperty]
		public string UserName { get; set; } = string.Empty;
		[BindProperty]
		public string Password { get; set; } = string.Empty;
		[BindProperty]
		public string HashToVerify { get; set; } = string.Empty;
		[BindProperty]
		public string SaltToVerify { get; set; } = string.Empty;

		public void OnPostRegister()
		{

			var hash = BCrypt.Net.BCrypt.HashPassword(this.Password);
			var salt = string.Empty;
			this.HashToVerify = hash;
			this.SaltToVerify = salt;
			this.Message = "Hash created";
		}

		public void OnPostLogin()
		{
			var isValid = BCrypt.Net.BCrypt.Verify(this.Password, this.HashToVerify);
			if (isValid)
			{
				Message = "Login successful";
			}
			else
			{
				Message = "Login failed";
			}
		}
	}
}