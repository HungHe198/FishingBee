using Data_FishingBee.Models;
using Data_FishingBee.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace FishingBee_WebStore.Controllers
{
	public class ProductDetailController : Controller
	{
		private readonly IAllRepositories<ProductDetail> _repo;

		public ProductDetailController(IAllRepositories<ProductDetail> repo)
		{
			_repo = repo;
		}


		// GET: Products

		public async Task <IActionResult> Index()
		{
			
			var lstProductDetails = await _repo.GetAll();

			// Kiểm tra dữ liệu
			Console.WriteLine($"Số lượng sản phẩm: {lstProductDetails?.Count()}");

			if (lstProductDetails == null || !lstProductDetails.Any())
			{
				TempData["ErrorMessage"] = "Không có sản phẩm nào!";
				return View(new List<ProductDetail>());
			}

			return View(lstProductDetails);
		}
	}
}
