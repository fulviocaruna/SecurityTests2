using Microsoft.AspNetCore.Mvc;

namespace SecurityTests.Controllers
{
	[Route("[controller]")]
	[ApiController]
	public class ApiErrorController : ControllerBase
	{
		public IActionResult Error() => Problem();
	}
}