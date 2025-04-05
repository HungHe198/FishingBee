using Microsoft.AspNetCore.Mvc;

namespace FishingBee_WebStore.Controllers.Sales
{
    public class CheckoutController : Controller
    {
        public IActionResult Index()// tạo hóa đơn chờ. bắt đầu thêm sản phẩm vào hóa đơn chờ. cùng với đó là 
        {
            return View();
        }
    }
}
