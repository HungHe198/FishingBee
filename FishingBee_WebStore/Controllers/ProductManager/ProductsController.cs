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
        private readonly IAllRepositories<Category> _categoryRepo;
        private readonly IAllRepositories<Manufacturer> _manufacturerRepo;

        public ProductsController(
            IAllRepositories<Product> productRepo,
            IAllRepositories<Category> categoryRepo,
            IAllRepositories<Manufacturer> manufacturerRepo)
        {
            _productRepo = productRepo;
            _categoryRepo = categoryRepo;
            _manufacturerRepo = manufacturerRepo;
        }

        // GET: Products
        public async Task<IActionResult> Index()
        {
            var products = await _productRepo.GetAll();
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

        // POST: Products/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Product product)
        {
            if (ModelState.IsValid)
            {
                await _productRepo.Create(product);
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
    }

}
