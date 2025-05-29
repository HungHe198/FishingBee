using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Data_FishingBee.Models;
using Data_FishingBee.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.CodeAnalysis;

namespace FishingBee_WebStore.Controllers
{
    public class Cart_PDController : Controller
    {
        private readonly IAllRepositories<Cart_PD> _repoCartPD;
        private readonly IAllRepositories<Cart> _repoCart;
        private readonly IAllRepositories<ProductDetail> _repoPD;
        private readonly IAllRepositories<Bill> _repoBill;
        private readonly IAllRepositories<BillDetail> _repoBillDetail;

        public Cart_PDController(IAllRepositories<Cart_PD> repoCartPD, IAllRepositories<Cart> repoCart, IAllRepositories<ProductDetail> repoPD, IAllRepositories<Bill> repoBill, IAllRepositories<BillDetail> repoBillDetail)
        {
            _repoCartPD = repoCartPD;
            _repoCart = repoCart;
            _repoPD = repoPD;
            _repoBill = repoBill;
            _repoBillDetail = repoBillDetail;
        }
        // GET: Cart_PD
        public async Task<IActionResult> Index()
        {
            // Lấy CustomerId từ Session
            var customerIdJson = HttpContext.Session.GetString("CustomerId");
            if (string.IsNullOrEmpty(customerIdJson))
            {
                return RedirectToAction("Login", "Account"); // Điều hướng nếu chưa đăng nhập
            }

            var customerId = Guid.Parse(customerIdJson);

            // Lọc giỏ hàng theo CustomerId
            var fishingBeeDbContext = _repoCartPD
                .GetAllQueryable()
                .Include(c => c.Cart)
                .Include(c => c.ProductDetail)
                .Include(c => c.ProductDetail)
                    .ThenInclude(pd => pd.Product)
                .Include(c => c.ProductDetail)
                    .ThenInclude(pd => pd.Product)
                    .ThenInclude(p => p.ProductImages)
                .Where(c => c.Cart.CustomerId == customerId); //  Chỉ lấy dữ liệu của khách hàng này

            return View(await fishingBeeDbContext.ToListAsync());
        }

        // GET: Cart_PD/Details/5
        public async Task<IActionResult> Details(Guid? id)
        {
            if (id == null || _repoCartPD.GetAllQueryable() == null)
            {
                return NotFound();
            }

            var cart_PD = await _repoCartPD.GetAllQueryable()
                .Include(c => c.Cart)
                .Include(c => c.ProductDetail)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (cart_PD == null)
            {
                return NotFound();
            }

            return View(cart_PD);
        }

        // GET: Cart_PD/Create
        public IActionResult Create()
        {
            ViewData["CartId"] = new SelectList(_repoCart.GetAllQueryable(), "Id", "Status");
            ViewData["ProductDetailId"] = new SelectList(_repoPD.GetAllQueryable(), "Id", "Id");
            return View();
        }

        // POST: Cart_PD/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,ProductDetailId,CartId,Quantity")] Cart_PD cart_PD)
        {
            if (ModelState.IsValid)
            {
                cart_PD.Id = Guid.NewGuid();
                await _repoCartPD.Create(cart_PD);
                return RedirectToAction(nameof(Index));
            }
            ViewData["CartId"] = new SelectList(_repoCart.GetAllQueryable(), "Id", "Status", cart_PD.CartId);
            ViewData["ProductDetailId"] = new SelectList(_repoPD.GetAllQueryable(), "Id", "Id", cart_PD.ProductDetailId);
            return View(cart_PD);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Guid id, Cart_PD cart_PD, int quantity)
        {
            if (id != cart_PD.Id) return NotFound();

            if (!ModelState.IsValid)
            {
                try
                {
                    cart_PD.Quantity = quantity;

                    if (cart_PD.Quantity <= 0)
					{
						// Nếu số lượng <= 0, xóa sản phẩm khỏi giỏ hàng
						await _repoCartPD.Delete(id);
						return RedirectToAction(nameof(Index));
					}
					var productDetail = _repoPD.GetById(cart_PD.ProductDetailId).Result;

					if (cart_PD.Quantity > productDetail.Stock)
					{
						TempData["ErrorMessage"] = $"Số lượng vượt quá tồn kho. Tồn kho hiện tại: {productDetail.Stock}";
						return RedirectToAction("Index", "Cart_PD");
					}
					await _repoCartPD.Update(id, cart_PD);
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!(await _repoCartPD.EntityExists(cart_PD.Id))) return NotFound();
                    else throw;
                }
                return RedirectToAction(nameof(Index));
            }

            return RedirectToAction(nameof(Index)); // Không trả về View Edit nữa
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Remove(Guid id)
        {
            var cartItem = await _repoCartPD.GetById(id);
            if (cartItem != null)
            {
                await _repoCartPD.Delete(id);
            }
            return RedirectToAction(nameof(Index));
        }

        // GET: Cart_PD/Delete/5
        public async Task<IActionResult> Delete(Guid? id)
        {
            if (id == null || _repoPD.GetAllQueryable() == null)
            {
                return NotFound();
            }

            var cart_PD = await _repoCartPD.GetAllQueryable()
                .Include(c => c.Cart)
                .Include(c => c.ProductDetail)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (cart_PD == null)
            {
                return NotFound();
            }

            return View(cart_PD);
        }

        // POST: Cart_PD/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(Guid id)
        {
            if (_repoCartPD.GetAllQueryable() == null)
            {
                return Problem("Entity set 'FishingBeeDbContext.Cart_PDs'  is null.");
            }
            var cart_PD = await _repoCartPD.GetById(id);
            if (cart_PD != null)
            {
              await  _repoCartPD.Delete(id);
            }   


            return RedirectToAction(nameof(Index));
        }

        [HttpGet]
        public IActionResult Checkout()
        {
            // Kiểm tra đã đăng nhập chưa
            var customerIdJson = HttpContext.Session.GetString("CustomerId");
            if (string.IsNullOrEmpty(customerIdJson))
            {
                return RedirectToAction("Login", "Account");
            }

            return View(); // Trả về view cho người dùng nhập thông tin
        }

        [HttpPost]
        public async Task<IActionResult> Checkout(string customerName, string customerPhone, string customerAddress, string paymentMethod)
        {
            // Lấy CustomerId từ session
            var customerIdJson = HttpContext.Session.GetString("CustomerId");
            if (string.IsNullOrEmpty(customerIdJson))
            {
                return RedirectToAction("Login", "Account");
            }

            var customerId = Guid.Parse(customerIdJson);

            // Lấy Cart của Customer
            var cart = _repoCart.GetAllQueryable().FirstOrDefault(c => c.CustomerId == customerId);
            if (cart == null)
            {
                return BadRequest("Giỏ hàng không tồn tại.");
            }

            var cartItems = _repoCartPD.GetAllQueryable()
                .Where(x => x.CartId == cart.Id && x.Status == 0) // status 1: đang trong giỏ
                .ToList();

            if (!cartItems.Any())
            {
                return BadRequest("Không có sản phẩm trong giỏ.");
            }

            // Tính tổng giá
            decimal totalPrice = 0;
            foreach (var item in cartItems)
            {
                var product = _repoPD.GetAllQueryable().FirstOrDefault(p => p.Id == item.ProductDetailId);
                if (product != null)
                {
                    totalPrice += product.Price * item.Quantity;
                }
            }

            // Gán Id cho Bill
            var newBill = new Bill
            {
                Id = Guid.NewGuid(),
                CustomerId = customerId,
                CreatedTime = DateTime.Now,
                Status = "1",
                InvoiceCode = "HD" + DateTime.Now.Ticks,
                TotalPrice = totalPrice,
                CustomerName = customerName,
                CustomerPhone = customerPhone,
                CustomerAddress = customerAddress,
                PaymentMethod = paymentMethod
            };

            // Tạo danh sách BillDetails
            var billDetails = cartItems.Select(item => new BillDetail
            {
                Id = Guid.NewGuid(), // nếu dùng khóa đơn
                BillId = newBill.Id,
                ProductDetailId = item.ProductDetailId,
                UnitPrice = _repoPD.GetAllQueryable().First(p => p.Id == item.ProductDetailId).Price,
                Amount = item.Quantity,
                CreatedTime = DateTime.Now
            }).ToList();

            newBill.BillDetails = billDetails;

            // Thêm và lưu
            try
            {
                await _repoBill.Create(newBill); // Repo phải gọi SaveChanges()
            }
            catch (DbUpdateException ex)
            {
                return Content("Lỗi khi lưu: " + ex.InnerException?.Message);
            }

            try
            {
                foreach (var item in cartItems.ToList()) // Create a copy to avoid modification issues
                {
                    await _repoCartPD.Delete(item.Id);
                }
            }
            catch (Exception ex)
            {
                return BadRequest($"Error deleting cart items: {ex.Message}");
            }
            TempData["SuccessMessage"] = "Đặt hàng thành công!";
            return RedirectToAction("Index", "Home");
        }

    }
}