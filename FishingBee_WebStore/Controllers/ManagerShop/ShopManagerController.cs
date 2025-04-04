using Microsoft.AspNetCore.Mvc;

namespace FishingBee_WebStore.Controllers.ManagerShop
{
    public class ShopManagerController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
