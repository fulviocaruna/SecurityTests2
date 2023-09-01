using Microsoft.AspNetCore.Mvc;

namespace SecurityTests.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class DayOfWeekController : ControllerBase
	{
		private string[] _daysOfWeek = new[] {
"Sunday",
"Monday",
"Tuesday",
"Wednesday",
"Thursday",
"Friday",
"Saturday"
};
		public bool GetIsDayOfWeek(string? name)
		{
			if (string.IsNullOrEmpty(name))
			{
				throw new ArgumentException("`name` cannot be empty");
			}
			return _daysOfWeek.Contains(name);
		}
	}
}