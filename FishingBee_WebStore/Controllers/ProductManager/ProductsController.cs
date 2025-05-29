using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Data_FishingBee.ContextFile;
using Data_FishingBee.Models;
using Microsoft.CodeAnalysis.Diagnostics;
using Data_FishingBee.Repositories;

namespace FishingBee_WebStore.Controllers.ProductManager
{
    public class ProductsController : Controller
    {
        private readonly IAllRepositories<Product> _productRepo;
        private readonly IAllRepositories<ProductDetail> _productDetailRepo;
        private readonly IAllRepositories<ProductImage> _productImageRepo;
        private readonly IProductImageRepository _pDImageRepo;
        private readonly IAllRepositories<Category> _categoryRepo;
        private readonly IAllRepositories<Manufacturer> _manufacturerRepo;
        private readonly IWebHostEnvironment _env;
        private readonly IProductsRepositories _productCRepo;
        public ProductsController(
            IAllRepositories<Product> productRepo,
            IAllRepositories<Category> categoryRepo,
            IAllRepositories<Manufacturer> manufacturerRepo,
            IWebHostEnvironment env,
            IAllRepositories<ProductDetail> productDetailRepo,
            IAllRepositories<ProductImage> productImageRepo,
            IProductsRepositories productCRepo)
        {
            _productRepo = productRepo;
            _categoryRepo = categoryRepo;
            _manufacturerRepo = manufacturerRepo;
            _env = env;
            _productDetailRepo = productDetailRepo;
            _productImageRepo = productImageRepo;
            _productCRepo = productCRepo;
        }

        // GET: Products
        public async Task<IActionResult> Index(string status)
        {
            var query = _productRepo.GetAllQueryable()
                        .Include(p => p.Manufacturer)
                        .Include(p => p.Category);

            if (!string.IsNullOrEmpty(status))
            {
                var products = query.Where(x => x.Status == status).ToList();
                return View(products);
            }
            else
            {
                var result = await query.ToListAsync();
                ViewBag.CurrentStatus = status;
                return View(result);
            }


        }
        public async Task<IActionResult> InactiveProducts()
        {
            // các sản phẩm đã ngừng bán hàng
            //0 : ngừng đã xóa
            //1: đang bán
            //2 hoặc bất cứ trạng thái bất thường nào kh: ngừng bán
            var products = _productRepo.GetAllQueryable()
                .Include(p => p.Manufacturer)
                .Include(p => p.Category)
                .ToList()
                .Where(x => x.Status != "1");
            return View(products);
        }

        // GET: Products/Details/5
        public async Task<IActionResult> Details(Guid? id)
        {
            if (!id.HasValue)
            {
                return NotFound();
            }

            var product = await _productRepo.GetById(id.Value);
            if (product == null)
            {
                return NotFound();
            }

            return View(product);
        }

        // GET: Products/Create
        public async Task<IActionResult> Create()
        {
            ViewData["CategoryId"] = new SelectList(await _categoryRepo.GetAll(), "Id", "Name");
            ViewData["ManufacturerId"] = new SelectList(await _manufacturerRepo.GetAll(), "Id", "Name");
            return View();
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Product product, List<IFormFile> Images, string attributeValues)
        {
            if (!ModelState.IsValid)
            {

                product.CreatedTime = DateTime.Now;
                var saveProduct = await _productRepo.Create(product);

                // Lưu ảnh vào thư mục riêng theo ProductId
                string productFolder = Path.Combine(_env.WebRootPath, "images", product.Id.ToString());
                if (!Directory.Exists(productFolder))
                {
                    Directory.CreateDirectory(productFolder);
                }

                int imageIndex = 1;
                foreach (var image in Images)
                {
                    if (image != null && image.Length > 0)
                    {
                        string fileName = $"{imageIndex}.jpg"; // Đặt tên ảnh 1, 2, 3...
                        string filePath = Path.Combine(productFolder, fileName);

                        using (var stream = new FileStream(filePath, FileMode.Create))
                        {
                            await image.CopyToAsync(stream);
                        }

                        await _productImageRepo.Create(new ProductImage
                        {
                            Id = Guid.NewGuid(),
                            ProductId = product.Id,
                            ImageUrl = $"/images/{product.Id}/{fileName}"
                        });

                        imageIndex++;
                    }
                }



                return RedirectToAction(nameof(Index));
            }

            ViewData["CategoryId"] = new SelectList(await _categoryRepo.GetAll(), "Id", "Name", product.CategoryId);
            ViewData["ManufacturerId"] = new SelectList(await _manufacturerRepo.GetAll(), "Id", "Name", product.ManufacturerId);
            return View(product);
        }


        // GET: Products/Edit/5
        public async Task<IActionResult> Edit(Guid? id)
        {
            if (!id.HasValue)
            {
                return NotFound();
            }

            var product = await _productRepo.GetById(id.Value);
            if (product == null)
            {
                return NotFound();
            }

            try
            {
                ViewData["CategoryId"] = new SelectList(await _categoryRepo.GetAll(), "Id", "Name", product.CategoryId);
                ViewData["ManufacturerId"] = new SelectList(await _manufacturerRepo.GetAll(), "Id", "Name", product.ManufacturerId);

                try
                {
                    // CHỈ gọi khi đã chắc chắn product không null
                    var images = await _pDImageRepo.GetByProductId(product.Id);
                    ViewBag.ExistingImages = images;
                }
                catch
                {
                    ViewBag.ExistingImages = null; // fallback nếu lỗi khi lấy ảnh
                }
            }
            catch (Exception ex)
            {
                // Nếu lỗi trong quá trình load dropdown
                Console.WriteLine("Lỗi khi load dữ liệu: " + ex.Message);

                ViewData["CategoryId"] = new SelectList(Enumerable.Empty<object>(), "Id", "Name");
                ViewData["ManufacturerId"] = new SelectList(Enumerable.Empty<object>(), "Id", "Name");
                ViewBag.ExistingImages = null;
            }

            return View(product);
        }



        // POST: Products/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Guid id, Product product, List<IFormFile> Images)
        {
            if (id != product.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    await _productRepo.Update(id, product);

                    // Xử lý lưu ảnh mới (nếu có)
                    if (Images != null && Images.Count > 0)
                    {
                        string productFolder = Path.Combine(_env.WebRootPath, "images", product.Id.ToString());
                        if (!Directory.Exists(productFolder))
                        {
                            Directory.CreateDirectory(productFolder);
                        }

                        // Tìm số thứ tự ảnh lớn nhất hiện tại
                        var existingImages = await _pDImageRepo.GetByProductId(product.Id);
                        int maxIndex = 0;
                        if (existingImages != null && existingImages.Any())
                        {
                            var indexes = existingImages.Select(img =>
                            {
                                var fileName = Path.GetFileNameWithoutExtension(img.ImageUrl);
                                return int.TryParse(fileName, out int n) ? n : 0;
                            });
                            maxIndex = indexes.Max();
                        }

                        int imageIndex = maxIndex + 1;

                        foreach (var image in Images)
                        {
                            if (image != null && image.Length > 0)
                            {
                                string fileName = $"{imageIndex}.jpg";
                                string filePath = Path.Combine(productFolder, fileName);

                                using (var stream = new FileStream(filePath, FileMode.Create))
                                {
                                    await image.CopyToAsync(stream);
                                }

                                await _productImageRepo.Create(new ProductImage
                                {
                                    Id = Guid.NewGuid(),
                                    ProductId = product.Id,
                                    ImageUrl = $"/images/{product.Id}/{fileName}"
                                });

                                imageIndex++;
                            }
                        }
                    }
                }
                catch (DbUpdateConcurrencyException)
                {
                    bool exists = await _productRepo.EntityExists(product.Id);
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

            ViewData["CategoryId"] = new SelectList(await _categoryRepo.GetAll(), "Id", "Name", product.CategoryId);
            ViewData["ManufacturerId"] = new SelectList(await _manufacturerRepo.GetAll(), "Id", "Name", product.ManufacturerId);
            return View(product);
        }


        // GET: Products/Delete/5
        //public async Task<IActionResult> Delete(Guid? id)
        //{
        //    if (!id.HasValue)
        //    {
        //        return NotFound();
        //    }

        //    var product = await _productRepo.GetById(id.Value);
        //    if (product == null)
        //    {
        //        return NotFound();
        //    }

        //    return View(product);
        //}

        // POST: Products/Delete/5
        [HttpPost("/Products/DeleteConfirmed/{id}")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(Guid id)
        {
            var product = await _productRepo.GetById(id);
            if (product != null)
            {
                await _productRepo.Delete(id);
                return Ok(); // Trả về 200 nếu xóa thành công
            }

            return NotFound();
        }
        public ActionResult GetFirstProductImage(Guid manuID, Guid productid)
        {
            var product = _productRepo.GetAllQueryable()
                            .Where(p => p.ManufacturerId == manuID)
                            .OrderBy(p => p.Id)
                            .Select(p => p.ProductImages.FirstOrDefault(x => x.ProductId == productid))
                            .FirstOrDefault();

            if (product != null)
            {
                return Content(product.ImageUrl); // Trả về URL ảnh
            }
            return NotFound("Không tìm thấy sản phẩm.");
        }
        public async Task<IActionResult> ListOfCategory(Guid categoryId)
        {
            var products = await _productCRepo.GetAllByCategoryIdAsync(categoryId);
            return View(products); // truyền danh sách sản phẩm sang View
        }
    }

}
