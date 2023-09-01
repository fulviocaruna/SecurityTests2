using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Diagnostics;

namespace SecurityTests.Pages.Logging
{
	public class LoggingModel : PageModel
	{
		private readonly ILogger<LoggingModel> _logger;
		public LoggingModel(ILogger<LoggingModel> logger)
		{
			_logger = logger;
		}
		public void OnGet()
		{
			/*
            _logger.Log(
            logLevel: LogLevel.Information,
            message: "Calling OnGet method in {0}",
            args: new string[] { HttpContext.Request.Path });
            */

			var requestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier;

			using (_logger.BeginScope("Request {0}", new string[] { requestId }))
			{
				_logger.Log(
				logLevel: LogLevel.Information,
				message: "Calling OnGet method in {0}",
				args: new string[] { HttpContext.Request.Path });

				// ...

				_logger.Log(
				logLevel: LogLevel.Information,
				message: "Reaching the end of OnGet method in {0}",
				args: new string[] { HttpContext.Request.Path });
			}
		}
	}
}