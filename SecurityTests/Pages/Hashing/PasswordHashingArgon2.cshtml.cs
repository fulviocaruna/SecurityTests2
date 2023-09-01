using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Sodium;

namespace SecurityTests.Pages.Hashing
{
	public class PasswordHashingArgon2Model : PageModel
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
			var hash = PasswordHash.ArgonHashString(
			this.Password,
			PasswordHash.StrengthArgon.Interactive)
			.TrimEnd('\0');

			var salt = string.Empty;
			this.HashToVerify = hash;
			this.SaltToVerify = salt;
			this.Message = "Hash created";
		}

		public void OnPostLogin()
		{
			var isValid = PasswordHash.ArgonHashStringVerify(
 this.HashToVerify, this.Password);
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