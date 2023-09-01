using Microsoft.AspNetCore.Mvc;

namespace SecurityTests.Controllers
{
	public class FaultController : Controller
	{
		public IActionResult Index()
		{
			string s = null;
			s.ToUpper();

			return View();
		}
	}
}