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
        private readonly IAllRepositories<Cart> _repoCart;


        public CartsController(ICartRepository cartRepository, IAllRepositories<ProductDetail> repoPD, IAllRepositories<Cart_PD> repoCart_PD, IAllRepositories<Cart> repoCart)
        {
            _cartRepository = cartRepository;
            _repoPD = repoPD;
            _repoCart_PD = repoCart_PD;
            _repoCart = repoCart;
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
            var customerIdJson = HttpContext.Session.GetString("CustomerId");
            if (string.IsNullOrEmpty(customerIdJson) || !Guid.TryParse(customerIdJson, out Guid customerId))
            {
                return RedirectToAction("Login", "Account");
            }


            var cart = await _cartRepository.GetCartByCustomerIdAsync(customerId);

            if (cart == null)
            {
                cart = new Cart
                {
                    Id = Guid.NewGuid(),
                    CustomerId = customerId,
                    CreatedTime = DateTime.Now,
                    LastUpdateTime = DateTime.Now,
                    Status = "Active",
                    Cart_PDs = new List<Cart_PD>()
                };
                await _repoCart.Create(cart);
            }

            var currentDetail = await _repoPD.GetAllQueryable()
                .Include(pd => pd.Product)
                .FirstOrDefaultAsync(pd => pd.Id == productDetailId);

            if (currentDetail == null)
            {
                // trả lỗi nếu không tìm thấy sản phẩm
                return NotFound("Sản phẩm không tồn tại.");
            }

            var productId = currentDetail.ProductId;

            if (currentDetail.Stock <= 0)
            {
                return BadRequest("Sản phẩm đã hết hàng.");
            }
            var existingCartItem = _repoCart_PD.GetAllQueryable().FirstOrDefault(cp => cp.ProductDetailId == productDetailId);

            if (existingCartItem != null)
            {
                if (existingCartItem.Quantity + quantity > currentDetail.Stock)
                {
                    TempData["ErrorMessage"] = "Số lượng vượt quá tồn kho.";
                    return RedirectToAction("Details", "ProductDetails", new { id = productId });
                }

                var cartItem = cart.Cart_PDs.FirstOrDefault(cp => cp.ProductDetailId == productDetailId);

                if (cartItem == null)
                {
                    cartItem = new Cart_PD
                    {
                        Id = Guid.NewGuid(),
                        CartId = cart.Id,
                        ProductDetailId = productDetailId,
                        Quantity = quantity
                    };
                    await _repoCart_PD.Create(cartItem);
                }
                else
                {
                    cartItem.Quantity += quantity;
                    await _repoCart_PD.Update(cartItem.Id, cartItem);
                }

                cart.LastUpdateTime = DateTime.Now;
            }
            else
            {
                // Trường hợp chưa có sản phẩm này trong giỏ => thêm mới nếu tồn kho đủ
                if (quantity > currentDetail.Stock)
                {
                    TempData["ErrorMessage"] = "Số lượng vượt quá tồn kho.";
                    return RedirectToAction("Details", "ProductDetails", new { id = productId });
                }

                var newCartItem = new Cart_PD
                {
                    Id = Guid.NewGuid(),
                    CartId = cart.Id,
                    ProductDetailId = productDetailId,
                    Quantity = quantity
                };
                await _repoCart_PD.Create(newCartItem);

                cart.LastUpdateTime = DateTime.Now;
            }

            return RedirectToAction("Index", "Cart_PD");



        }

    }

}
