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
    public class InventoriesController : Controller
    {
        private readonly IAllRepositories<Inventory> _inventoryRepo;
        private readonly IAllRepositories<ProductDetail> _productDetailRepo;

        public InventoriesController(
            IAllRepositories<Inventory> inventoryRepo,
            IAllRepositories<ProductDetail> productDetailRepo)
        {
            _inventoryRepo = inventoryRepo;
            _productDetailRepo = productDetailRepo;
        }

        // GET: Inventories
        public async Task<IActionResult> Index()
        {
            var inventories = await _inventoryRepo.GetAll();
            return View(inventories);
        }

        // GET: Inventories/Details/5
        public async Task<IActionResult> Details(Guid? id)
        {
            if (!id.HasValue)
            {
                return NotFound();
            }

            var inventory = await _inventoryRepo.GetById(id.Value);
            if (inventory == null)
            {
                return NotFound();
            }

            return View(inventory);
        }

        // GET: Inventories/Create
        public async Task<IActionResult> Create()
        {
            ViewData["ProductDetailId"] = new SelectList(await _productDetailRepo.GetAll(), "Id", "Name");
            return View();
        }

        // POST: Inventories/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Inventory inventory)
        {
            if (ModelState.IsValid)
            {
                inventory.Id = Guid.NewGuid();
                await _inventoryRepo.Create(inventory);
                return RedirectToAction(nameof(Index));
            }

            ViewData["ProductDetailId"] = new SelectList(await _productDetailRepo.GetAll(), "Id", "Name", inventory.ProductDetailId);
            return View(inventory);
        }

        // GET: Inventories/Edit/5
        public async Task<IActionResult> Edit(Guid? id)
        {
            if (!id.HasValue)
            {
                return NotFound();
            }

            var inventory = await _inventoryRepo.GetById(id.Value);
            if (inventory == null)
            {
                return NotFound();
            }

            ViewData["ProductDetailId"] = new SelectList(await _productDetailRepo.GetAll(), "Id", "Name", inventory.ProductDetailId);
            return View(inventory);
        }

        // POST: Inventories/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Guid id, Inventory inventory)
        {
            if (id != inventory.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    await _inventoryRepo.Update(id, inventory);
                }
                catch (DbUpdateConcurrencyException)
                {
                    bool exists = await _inventoryRepo.EntityExists(inventory.Id);
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

            ViewData["ProductDetailId"] = new SelectList(await _productDetailRepo.GetAll(), "Id", "Name", inventory.ProductDetailId);
            return View(inventory);
        }

        // GET: Inventories/Delete/5
        public async Task<IActionResult> Delete(Guid? id)
        {
            if (!id.HasValue)
            {
                return NotFound();
            }

            var inventory = await _inventoryRepo.GetById(id.Value);
            if (inventory == null)
            {
                return NotFound();
            }

            return View(inventory);
        }

        // POST: Inventories/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(Guid id)
        {
            var inventory = await _inventoryRepo.GetById(id);
            if (inventory != null)
            {
                await _inventoryRepo.Delete(id);
            }

            return RedirectToAction(nameof(Index));
        }
    }

}
