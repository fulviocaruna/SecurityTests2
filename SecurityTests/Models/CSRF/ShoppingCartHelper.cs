using System.Text.Json;

namespace SecurityTests.Models.CSRF
{
	public static class ShoppingCartHelper
	{
		public static List<ShoppingCartItem> getCart(HttpContext httpContext)
		{
			var cartAsJson = httpContext.Session.GetString("ShoppingCart");

			if (cartAsJson == null)
				return new List<ShoppingCartItem>();
			else
				return JsonSerializer.Deserialize<List<ShoppingCartItem>>(cartAsJson) ?? new List<ShoppingCartItem>();
		}

		public static void addToCart(HttpContext httpContext, ShoppingCartItem item)
		{
			var cart = getCart(httpContext);
			cart.Add(item);
			httpContext.Session.SetString("ShoppingCart", JsonSerializer.Serialize<List<ShoppingCartItem>>(cart));
		}

		public static void clearCart(HttpContext httpContext)
		{
			httpContext.Session.SetString("ShoppingCart", "[]");
		}
	}
}