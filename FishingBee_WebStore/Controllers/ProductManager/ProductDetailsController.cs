using Data_FishingBee.Models;
using Data_FishingBee.Repositories;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace FishingBee_WebStore.Controllers.ProductManager
{
    public class ProductDetailsController : Controller
    {
        private readonly IAllRepositories<ProductDetail> _repoPD;

        public ProductDetailsController(IAllRepositories<ProductDetail> repoPD)
        {
            _repoPD = repoPD;
        }

        public IActionResult Index()
        {
            return View();
        }
        public async Task<IActionResult> Details(Guid id)
        {
            var productDetails = await _repoPD.GetAllQueryable()
                                              .Where(pd => pd.ProductId == id) // Lọc theo ProductId
                                              .ToListAsync();

            if (!productDetails.Any())
            {
                return NotFound();
            }
            return View(productDetails);
        }
    }
}
