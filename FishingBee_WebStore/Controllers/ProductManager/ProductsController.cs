﻿using System;
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
        private readonly IAllRepositories<Category> _categoryRepo;
        private readonly IAllRepositories<Manufacturer> _manufacturerRepo;
        private readonly IWebHostEnvironment _env;
        public ProductsController(
            IAllRepositories<Product> productRepo,
            IAllRepositories<Category> categoryRepo,
            IAllRepositories<Manufacturer> manufacturerRepo,
            IWebHostEnvironment env,
            IAllRepositories<ProductDetail> productDetailRepo,
            IAllRepositories<ProductImage> productImageRepo)
        {
            _productRepo = productRepo;
            _categoryRepo = categoryRepo;
            _manufacturerRepo = manufacturerRepo;
            _env = env;
            _productDetailRepo = productDetailRepo;
            _productImageRepo = productImageRepo;
        }

        // GET: Products
        public async Task<IActionResult> Index()
        {
            var products = _productRepo.GetAllQueryable()
                .Include(p => p.Manufacturer)
                .Include(p => p.Category)
                .ToList();
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

            ViewData["CategoryId"] = new SelectList(await _categoryRepo.GetAll(), "Id", "Name", product.CategoryId);
            ViewData["ManufacturerId"] = new SelectList(await _manufacturerRepo.GetAll(), "Id", "Name", product.ManufacturerId);
            return View(product);
        }

        // POST: Products/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Guid id, Product product)
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
        public async Task<IActionResult> Delete(Guid? id)
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

        // POST: Products/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(Guid id)
        {
            var product = await _productRepo.GetById(id);
            if (product != null)
            {
                await _productRepo.Delete(id);
            }

            return RedirectToAction(nameof(Index));
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
    }

}
