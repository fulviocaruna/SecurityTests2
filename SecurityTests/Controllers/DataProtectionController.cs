using Microsoft.AspNetCore.DataProtection;
using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;

namespace SecurityTests.Controllers
{
	public class DataProtectionController : Controller
	{

		private readonly IDataProtector _protector;

		public DataProtectionController(IDataProtectionProvider provider)
		{
			_protector = provider.CreateProtector("DataProtectionController");
		}

		public IActionResult Index()
		{
			return View();
		}

		[HttpPost]
		public IActionResult Index(DataProtectionModel model)
		{
			var encryptedData = _protector.Protect(model.Data);
			return RedirectToAction("Decrypt", new { id = encryptedData });
		}

		public IActionResult Decrypt(string id)
		{
			var decryptedData = _protector.Unprotect(id);
			var model = new DataProtectionModel() { Data = decryptedData };
			return View(model);
		}
	}

	public class DataProtectionModel
	{
		[Required]
		public string Data { get; set; }
	}
}