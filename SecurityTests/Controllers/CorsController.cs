using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;

namespace SecurityTests.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	//[EnableCors("CORS API Endpoint")]
	public class CorsController : ControllerBase
	{
		// GET: api/Cors
		[HttpGet]
		public int Get()
		{
			Console.WriteLine("...");
			return new Random().Next(10, 100);
		}

		// POST api/Cors
		[HttpPost]
		public void Post([FromBody] int value)
		{
		}
	}
}