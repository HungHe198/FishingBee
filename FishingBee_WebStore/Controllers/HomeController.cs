using Data_FishingBee.ContextFile;
using Data_FishingBee.Models;
using Data_FishingBee.Repositories;
using FishingBee_WebStore.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics;

namespace FishingBee_WebStore.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly FishingBeeDbContext _context;
        private readonly IAllRepositories<Product> _repoP;
        private readonly IAllRepositories<ProductDetail> _repoPD;
        public HomeController(ILogger<HomeController> logger, IAllRepositories<Product> repoP, IAllRepositories<ProductDetail> repoPD, FishingBeeDbContext context)
        {
            _logger = logger;
            _repoP = repoP;
            _repoPD = repoPD;
            _context = context;
        }

        public async Task<IActionResult> Index()
        {
            var products = await _context.Products
        .Select(p => new
        {
            Product = p,
            MinPrice = p.ProductDetails.Any() ? p.ProductDetails.Min(pd => pd.Price) : 0
        })
        .ToListAsync();

            // Chuyển dữ liệu thành ViewModel hoặc Dictionary để dùng trong View
            var productList = products.Select(p => new ProductViewModel
            {
                Id = p.Product.Id,
                Name = p.Product.Name ?? "Vô danh",
                ImageUrl = "https://my-test-11.slatic.net/p/338434611ea393cd207546c55b0b996f.jpg", // Cập nhật ảnh nếu có
                MinPrice = p.MinPrice
            }).ToList();

            return View(productList);

        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

        public async Task<IActionResult> Search(string searchTerm)
        {
            if (string.IsNullOrWhiteSpace(searchTerm))
            {
                TempData["ErrorMessage"] = "Vui lòng nhập từ khóa tìm kiếm!";
                return View("Index", new List<ProductDetail>());
            }

            var results = await _repoPD.GetAll();

            //var filteredResults = results
            //    .Where(p => p.Name.Contains(searchTerm, StringComparison.OrdinalIgnoreCase))
            //    .ToList();

            //if (!filteredResults.Any())
            //{
            //    TempData["ErrorMessage"] = "Không tìm thấy sản phẩm nào!";
            //}

            return View("Search", "HomeController");
        }
        public async Task<IActionResult> Detail(Guid id)
        {
            // xem chi tiết bản ghi của bảng product sau đó khi chuyển vào trang chính
            // sẽ hiển thị thông tin chi tiết của sản phẩm đó qua các bản ghi của ProductDetail
            var product = await _repoPD.GetById(id);
            return View(product);
        }
    }
}
