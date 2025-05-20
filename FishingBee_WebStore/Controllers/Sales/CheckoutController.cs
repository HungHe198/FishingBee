using Data_FishingBee.Models;
using Data_FishingBee.Repositories;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace FishingBee_WebStore.Controllers.Sales
{
    public class CheckoutController : Controller
    {
        private readonly IAllRepositories<Cart_PD> _repoCartPD;
        private readonly IAllRepositories<Cart> _repoCart;
        private readonly IAllRepositories<ProductDetail> _repoPD;
        private readonly IAllRepositories<Product> _repoProduct;
        private readonly IAllRepositories<ProductImage> _repoProductImage;
        private readonly IAllRepositories<Bill> _repoBill;
        private readonly IAllRepositories<BillDetail> _repoBillDetail;
        private readonly IAllRepositories<Customer> _repoCustomer;
        private readonly IAllRepositories<Notifications> _repoNotifications;
        private readonly IAllRepositories<Manufacturer> _repoManufacturer;
        private readonly IAllRepositories<Supplier> _repoSupplier;
        private readonly IAllRepositories<ImportHistory> _repoImportHistory;
        private readonly IAllRepositories<Inventory> _repoInventory;
        private readonly IAllRepositories<Coupon> _repoCoupon;
        private readonly IAllRepositories<Category> _repoCategory;

        public CheckoutController(IAllRepositories<Cart_PD> repoCartPD,
            IAllRepositories<Cart> repoCart,
            IAllRepositories<ProductDetail> repoPD,
            IAllRepositories<Product> repoProduct,
            IAllRepositories<ProductImage> repoProductImage,
            IAllRepositories<Bill> repoBill,
            IAllRepositories<BillDetail> repoBillDetail,
            IAllRepositories<Customer> repoCustomer,
            IAllRepositories<Notifications> repoNotifications,
            IAllRepositories<Manufacturer> repoManufacturer,
            IAllRepositories<Supplier> repoSupplier,
            IAllRepositories<ImportHistory> repoImportHistory,
            IAllRepositories<Inventory> repoInventory,
            IAllRepositories<Coupon> repoCoupon,
            IAllRepositories<Category> repoCategory)
        {
            _repoCartPD = repoCartPD;
            _repoCart = repoCart;
            _repoPD = repoPD;
            _repoProduct = repoProduct;
            _repoProductImage = repoProductImage;
            _repoBill = repoBill;
            _repoBillDetail = repoBillDetail;
            _repoCustomer = repoCustomer;
            _repoNotifications = repoNotifications;
            _repoManufacturer = repoManufacturer;
            _repoSupplier = repoSupplier;
            _repoImportHistory = repoImportHistory;
            _repoInventory = repoInventory;
            _repoCoupon = repoCoupon;
            _repoCategory = repoCategory;
        }

        public IActionResult Index()// tạo hóa đơn chờ. bắt đầu thêm sản phẩm vào hóa đơn chờ. cùng với đó là 
        {
            return View();
        }
        public IActionResult Checkout()
        {
            // Lấy CustomerId từ Session
            var customerIdJson = HttpContext.Session.GetString("CustomerId");
            if (string.IsNullOrEmpty(customerIdJson))
            {
                return RedirectToAction("Login", "Account"); // Điều hướng nếu chưa đăng nhập
            }

            var customerId = Guid.Parse(customerIdJson);

            //Lọc giỏ hàng theo CustomerId
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

            return View();
        }
    }
}
