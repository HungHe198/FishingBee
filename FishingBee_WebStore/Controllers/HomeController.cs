using Data_FishingBee.ContextFile;
using FishingBee_WebStore.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace FishingBee_WebStore.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly FishingBeeDbContext _dbContext;
        public HomeController(ILogger<HomeController> logger, FishingBeeDbContext context)
        {
            _dbContext = context;
            _logger = logger;
        }

        public IActionResult Index()
        {
            var Productdetail = _dbContext.Products.ToList();
            return View();
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
    }
}
