using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Data_FishingBee.ContextFile;
using Data_FishingBee.Models;
using Data_FishingBee.Repositories;

namespace FishingBee_WebStore.Controllers.ManagerShop
{
    // quản lí biến thể của admin side
    public class ManagerPDController : Controller
    {
        private readonly IAllRepositories<Product> _productRepo;
        private readonly IAllRepositories<ProductDetail> _productDetailRepo;

        public ManagerPDController(IAllRepositories<Product> productRepo, IAllRepositories<ProductDetail> productDetailRepo)
        {
            _productRepo = productRepo;
            _productDetailRepo = productDetailRepo;
        }

        // GET: ManagerPD
        // Index sẽ hiển thị ra các biến thể của Id xác định truyền vào từ id của Product.
        // và quản lí cũng dựa trên id của Product
        // link sẽ kiểu là /ManagerPD/index/ProductId/..ProductDetailId..

        public async Task<IActionResult> Index(Guid productId)
        {
            var fishingBeeDbContext = _productDetailRepo.GetAllQueryable()
                .Include(p => p.Product)
                .Where(x=>x.ProductId == productId);
            var productDetails = await fishingBeeDbContext.OrderByDescending(x => x.CreatedTime).ToListAsync();
            return View(productDetails);
        }
        [HttpGet]
        public async Task<IActionResult> Create(Guid productId)
        {
            var model = new ProductDetail
            {
                ProductId = productId,
                Status = "1"
            };

            ViewData["ProductId"] = new SelectList(await _productRepo.GetAll(), "Id", "Name");
            return View(model);
        }
        [HttpPost]
        public async Task<IActionResult> Create(ProductDetail model)
        {
            //if (!ModelState.IsValid)
            //    return View(model);
            //if (model.Price <= 0)
            //{
            //    ModelState.AddModelError(nameof(model.Price), "Giá phải lớn hơn 0.");
            //}

            //if (model.Stock <= 0)
            //{
            //    ModelState.AddModelError(nameof(model.Stock), "Tồn kho phải lớn hơn 0.");
            //}

            //if (!ModelState.IsValid)
            //{
            //    // Nếu có lỗi thì hiển thị lại form với dữ liệu và thông báo lỗi
            //    ViewData["ProductId"] = new SelectList(await _productRepo.GetAll(), "Id", "Name", model.ProductId);
            //    return View(model);
            //}
            model.Id = Guid.NewGuid(); // Nếu không dùng auto-ID trong DB
            await _productDetailRepo.Create(model);
            ViewData["ProductId"] = new SelectList(await _productRepo.GetAll(), "Id", "Name", model.ProductId);
            return RedirectToAction("Index", "ManagerPD", new { productId = model.ProductId });
            // Kiểm tra thủ công nếu chưa dùng [Range] trong model
            //if (model.Price <= 0)
            //{
            //    ModelState.AddModelError(nameof(model.Price), "Giá phải lớn hơn 0.");
            //}

            //if (model.Stock <= 0)
            //{
            //    ModelState.AddModelError(nameof(model.Stock), "Tồn kho phải lớn hơn 0.");
            //}

            //if (!ModelState.IsValid)
            //{
            //    // Nếu có lỗi thì hiển thị lại form với dữ liệu và thông báo lỗi
            //    ViewData["ProductId"] = new SelectList(await _productRepo.GetAll(), "Id", "Name", model.ProductId);
            //    return View(model);
            //}

            //// Nếu hợp lệ, tiếp tục lưu
            //model.Id = Guid.NewGuid();
            //model.CreatedTime = DateTime.UtcNow;

            //await _productDetailRepo.Create(model);

            //return RedirectToAction("Index", "ManagerPD", new { productId = model.ProductId });

        }
        [HttpGet]
        public async Task<IActionResult> Details(Guid id)
        {
            var productDetail = await _productDetailRepo.GetAllQueryable()
                .Include(p => p.Product) // Đảm bảo Include
                .FirstOrDefaultAsync(p => p.Id == id);

            if (productDetail == null)
            {
                return NotFound();
            }

            return View(productDetail);
        }

        [HttpGet]
        public async Task<IActionResult> Edit(Guid id)
        {
            var model = await _productDetailRepo.GetById(id);
            if (model == null)
                return NotFound();

            ViewData["ProductId"] = new SelectList(await _productRepo.GetAll(), "Id", "Name", model.ProductId);
            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(ProductDetail model)
        {
            if (ModelState.IsValid)
            {
                ViewData["ProductId"] = new SelectList(await _productRepo.GetAll(), "Id", "Name", model.ProductId);
                return View(model);
            }

            await _productDetailRepo.Update(model.Id,model);
            return RedirectToAction("Index", new { productId = model.ProductId });
        }
        [HttpGet]
        public async Task<IActionResult> Delete(Guid id)
        {
            var productDetail = await _productDetailRepo.GetAllQueryable()
         .Include(p => p.Product) // 👈 Đảm bảo Include
         .FirstOrDefaultAsync(p => p.Id == id);

            if (productDetail == null)
            {
                return NotFound();
            }

            return View(productDetail);
        }
        [HttpPost, ActionName("DeleteConfirmed")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(Guid id)
        {
             var productDetail = await _productDetailRepo.GetAllQueryable()
         .Include(p => p.Product) // 👈 Đảm bảo Include
         .FirstOrDefaultAsync(p => p.Id == id);

            if (productDetail == null)
            {
                return NotFound();
            }

            await _productDetailRepo.Delete(id);
            return RedirectToAction("Index", new { productId = productDetail.ProductId });
        }



    }
}
