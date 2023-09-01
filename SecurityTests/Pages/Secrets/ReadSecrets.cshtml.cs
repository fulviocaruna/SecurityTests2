using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace SecurityTests.Pages.Secrets
{
	public class ReadSecretsModel : PageModel
	{
		private readonly IConfiguration Configuration;

		public ReadSecretsModel(IConfiguration configuration)
		{
			Configuration = configuration;
		}

		public string ApiToken = string.Empty;
		public string Extra = string.Empty;

		public void OnGet()
		{
			ApiToken = Configuration["Shop:ApiToken"];
			Extra = Configuration["Logging:LogLevel:Default"];
		}
	}
}