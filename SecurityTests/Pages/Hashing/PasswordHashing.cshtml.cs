using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Security.Cryptography;

namespace SecurityTests.Pages.Hashing
{
	public class PasswordHashingModel : PageModel
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
			var rfc2898 = new Rfc2898DeriveBytes(
 this.Password,
 32,
 310000);
			var hash = Convert.ToBase64String(rfc2898.GetBytes(20));
			var salt = Convert.ToBase64String(rfc2898.Salt);
			this.HashToVerify = hash;
			this.SaltToVerify = salt;
			this.Message = "Hash created";
		}

		public void OnPostLogin()
		{
			var salt = Convert.FromBase64String(this.SaltToVerify);
			var rfc2898 = new Rfc2898DeriveBytes(
			this.Password,
			salt,
			310000);
			var hash = Convert.ToBase64String(rfc2898.GetBytes(20));
			var isValid = hash == this.HashToVerify;
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