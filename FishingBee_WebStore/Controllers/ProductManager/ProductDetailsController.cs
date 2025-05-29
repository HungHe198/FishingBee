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
                                              .Include(pd => pd.Product)
                                                    .ThenInclude(p => p.Manufacturer)
                                              .Include(pd => pd.Product)
                                                    .ThenInclude(p => p.ProductImages)
                                              .Include(pd => pd.Product)
                                              .Where(pd => pd.ProductId == id) // Lọc theo ProductId
                                              .Where (pd => pd.Status == "1" && pd.Stock >0 && pd.Price >= 1000)
                                              .ToListAsync();

            if (!productDetails.Any())
            {
                return NotFound();
            }
            return View(productDetails);
        }
      

    }
}
