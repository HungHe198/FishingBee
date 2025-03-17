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

namespace FishingBee_WebStore.Controllers.ProductManager
{
    public class ProductDetailsController : Controller
    {
        private readonly IAllRepositories<ProductDetail> _productDetailRepo;
        private readonly IAllRepositories<Product> _productRepo;
        private readonly IAllRepositories<Category> _categoryRepo;
        private readonly IAllRepositories<Manufacturer> _manuRepo;

        public ProductDetailsController(IAllRepositories<ProductDetail> productDetailRepo, IAllRepositories<Product> productRepo, IAllRepositories<Category> categoryRepo, IAllRepositories<Manufacturer> manuRepo)
        {
            _productDetailRepo = productDetailRepo;
            _productRepo = productRepo;
            _categoryRepo = categoryRepo;
            _manuRepo = manuRepo;
        }



        // GET: ProductDetails
        public async Task<IActionResult> Index()
        {
            var lstProductDetails = await _productDetailRepo.GetAll();

            // Kiểm tra dữ liệu
            Console.WriteLine($"Số lượng sản phẩm: {lstProductDetails?.Count()}");

            if (lstProductDetails == null || !lstProductDetails.Any())
            {
                TempData["ErrorMessage"] = "Không có sản phẩm nào!";
                return View(new List<ProductDetail>());
            }

            return View(lstProductDetails);
        }

        // GET: ProductDetails/Details/5
        public async Task<IActionResult> Details(Guid? id)
        {
            if (!id.HasValue)
            {
                return NotFound();
            }

            // Đợi dữ liệu từ GetAll() hoàn tất
            var productDetailsList = await _productDetailRepo.GetAll();

            // Lọc ra sản phẩm theo Id
            var productDetail = productDetailsList
                .FirstOrDefault(pd => pd.Id == id.Value);

            if (productDetail == null)
            {
                return NotFound();
            }

            // Load thủ công Category và Manufacturer nếu chưa được load
            if (productDetail.Product != null)
            {
                var categories = await _categoryRepo.GetAll(); // Lấy danh sách danh mục trước
                productDetail.Product.Category = categories.FirstOrDefault(e => e.Id == productDetail.Product.CategoryId);
                 var manufacturers = await _manuRepo.GetAll(); // Lấy danh sách danh mục trước
                productDetail.Product.Manufacturer = manufacturers.FirstOrDefault(e => e.Id == productDetail.Product.ManufacturerId);

                //productDetail.Product.Manufacturer = await _context.Manufacturers
                //    .FirstOrDefaultAsync(m => m.Id == productDetail.Product.ManufacturerId);
            }

            return View(productDetail);

        }

        // GET: ProductDetails/Create
        public async Task<IActionResult> Create()
        {
            ViewData["ProductId"] = new SelectList(await _productRepo.GetAll(), "Id", "Name");
            return View();
        }

        // POST: ProductDetails/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(ProductDetail productDetail)
        {
            if (ModelState.IsValid)
            {
                await _productDetailRepo.Create(productDetail);
                return RedirectToAction(nameof(Index));
            }

            ViewData["ProductId"] = new SelectList(await _productRepo.GetAll(), "Id", "Name", productDetail.ProductId);
            return View(productDetail);
        }

        // GET: ProductDetails/Edit/5
        public async Task<IActionResult> Edit(Guid? id)
        {
            if (!id.HasValue)
            {
                return NotFound();
            }

            var productDetail = await _productDetailRepo.GetById(id.Value);
            if (productDetail == null)
            {
                return NotFound();
            }

            ViewData["ProductId"] = new SelectList(await _productRepo.GetAll(), "Id", "Name", productDetail.ProductId);
            return View(productDetail);
        }

        // POST: ProductDetails/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Guid id, ProductDetail productDetail)
        {
            if (id != productDetail.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    await _productDetailRepo.Update(id, productDetail);
                }
                catch (DbUpdateConcurrencyException)
                {
                    bool exists = await _productDetailRepo.EntityExists(productDetail.Id);
                    if (!exists)
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }

            ViewData["ProductId"] = new SelectList(await _productRepo.GetAll(), "Id", "Name", productDetail.ProductId);
            return View(productDetail);
        }

        // GET: ProductDetails/Delete/5
        public async Task<IActionResult> Delete(Guid? id)
        {
            if (!id.HasValue)
            {
                return NotFound();
            }

            var productDetail = await _productDetailRepo.GetById(id.Value);
            if (productDetail == null)
            {
                return NotFound();
            }

            return View(productDetail);
        }

        // POST: ProductDetails/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(Guid id)
        {
            var productDetail = await _productDetailRepo.GetById(id);
            if (productDetail != null)
            {
                await _productDetailRepo.Delete(id);
            }

            return RedirectToAction(nameof(Index));
        }
    }

}
