using Data_FishingBee.Models;
using Data_FishingBee.Repositories;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace FishingBee_WebStore.Controllers
{
    public class CartsController : Controller
    {
        private readonly ICartRepository _cartRepository;
        private readonly IAllRepositories<ProductDetail> _repoPD;
        private readonly IAllRepositories<Cart_PD> _repoCart_PD;


        public CartsController(ICartRepository cartRepository, IAllRepositories<ProductDetail> repoPD, IAllRepositories<Cart_PD> repoCart_PD)
        {
            _cartRepository = cartRepository;
            _repoPD = repoPD;
            _repoCart_PD = repoCart_PD;
        }

        public async Task<IActionResult> Index()
        {
            
            // Giả định rằng đã có CustomerId (có thể lấy từ User.Identity hoặc session)
            var customerIdJson = HttpContext.Session.GetString("CustomerId");
            if (customerIdJson == null)
            {
                return NotFound();
            }
            var customerId = Guid.Parse(customerIdJson);
            var cart = await _cartRepository.GetCartByCustomerIdAsync(customerId);
            return View(cart);
        }


		[HttpPost]
		public async Task<IActionResult> AddToCart(Guid productDetailId, int quantity)
		{
			if (quantity <= 0)
			{
				TempData["ErrorMessage"] = "Số lượng phải lớn hơn 0!";
				return RedirectToAction("Index", "Home");
			}

			var customerIdJson = HttpContext.Session.GetString("CustomerId");
			if (string.IsNullOrEmpty(customerIdJson))
			{
				TempData["ErrorMessage"] = "Vui lòng đăng nhập để thêm sản phẩm vào giỏ hàng.";
				return RedirectToAction("Login", "Account");
			}

			try
			{
				var customerId = Guid.Parse(customerIdJson);
				await _cartRepository.AddToCartAsync(customerId, productDetailId, quantity);
				TempData["SuccessMessage"] = "Sản phẩm đã được thêm vào giỏ hàng!";
			}
			catch (Exception ex)
			{
				TempData["ErrorMessage"] = "Lỗi khi thêm sản phẩm vào giỏ hàng. " + ex.Message;
			}

			return RedirectToAction("Index","Home");
		}


	}

}
