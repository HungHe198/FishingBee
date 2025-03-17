using Data_FishingBee.ContextFile;
using Data_FishingBee.Models;
using Data_FishingBee.Repositories;
using FishingBee_WebStore.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace FishingBee_WebStore.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IAllRepositories<ProductDetail> _repo;

        public HomeController(ILogger<HomeController> logger, IAllRepositories<ProductDetail> repo)
        {
            _logger = logger;
            _repo = repo;
        }

        public async Task<IActionResult> Index()
        {
            var Productdetail = await _repo.GetAll();
            return View(Productdetail);
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

            var results = await _repo.GetAll();

            var filteredResults = results
                .Where(p => p.Name.Contains(searchTerm, StringComparison.OrdinalIgnoreCase))
                .ToList();

            if (!filteredResults.Any())
            {
                TempData["ErrorMessage"] = "Không tìm thấy sản phẩm nào!";
            }

            return View("Search", "HomeController");
        }
    }
}
