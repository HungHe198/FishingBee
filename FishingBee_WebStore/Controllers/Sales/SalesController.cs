using Microsoft.AspNetCore.Mvc;

namespace FishingBee_WebStore.Controllers.Sales
{
    public class SalesController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
