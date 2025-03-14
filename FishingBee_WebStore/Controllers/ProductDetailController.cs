using Microsoft.AspNetCore.Mvc;

namespace FishingBee_WebStore.Controllers
{
	public class ProductDetailController : Controller
	{
		public IActionResult Index()
		{
			return View();
		}
	}
}
