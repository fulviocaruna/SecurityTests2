using Microsoft.AspNetCore.Mvc;
using SecurityTests.Models;
using SecurityTests.Models.CSRF;

namespace SecurityTests.Controllers
{
	public class CSRFController : Controller
	{
		public IActionResult AddToCart()
		{
			return View();
		}

		[HttpPost]
		// [ValidateAntiForgeryToken]
		public IActionResult AddToCart(ShoppingCartItem item)
		{
			ShoppingCartHelper.addToCart(HttpContext, item);
			return RedirectToAction("ShowCart");
		}

		public IActionResult ShowCart()
		{
			var cart = ShoppingCartHelper.getCart(HttpContext);
			return View(cart);
		}

		[HttpPost]
		public IActionResult ClearCart()
		{
			ShoppingCartHelper.clearCart(HttpContext);
			return RedirectToAction("ShowCart");
		}

	}

}