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
    public class ImportHistoriesController : Controller
    {


        private readonly IAllRepositories<ImportHistory> _importHistoryRepo;
        private readonly IAllRepositories<Inventory> _inventoryRepo;
        private readonly IAllRepositories<Supplier> _supplierRepo;

        public ImportHistoriesController(
            IAllRepositories<ImportHistory> importHistoryRepo,
            IAllRepositories<Inventory> inventoryRepo,
            IAllRepositories<Supplier> supplierRepo)
        {
            _importHistoryRepo = importHistoryRepo;
            _inventoryRepo = inventoryRepo;
            _supplierRepo = supplierRepo;
        }

        // GET: ImportHistories
        public async Task<IActionResult> Index()
        {
            var importHistories = await _importHistoryRepo.GetAll();
            return View(importHistories);
        }

        // GET: ImportHistories/Details/5
        public async Task<IActionResult> Details(Guid? id)
        {
            if (!id.HasValue)
            {
                return NotFound();
            }

            var importHistory = await _importHistoryRepo.GetById(id.Value);
            if (importHistory == null)
            {
                return NotFound();
            }

            return View(importHistory);
        }

        // GET: ImportHistories/Create
        public async Task<IActionResult> Create()
        {
            ViewData["InventoryId"] = new SelectList(await _inventoryRepo.GetAll(), "Id", "Name");
            ViewData["SupplierId"] = new SelectList(await _supplierRepo.GetAll(), "Id", "SupplierName");
            return View();
        }

        // POST: ImportHistories/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(ImportHistory importHistory)
        {
            if (ModelState.IsValid)
            {
                await _importHistoryRepo.Create(importHistory);
                return RedirectToAction(nameof(Index));
            }

            ViewData["InventoryId"] = new SelectList(await _inventoryRepo.GetAll(), "Id", "Name", importHistory.InventoryId);
            ViewData["SupplierId"] = new SelectList(await _supplierRepo.GetAll(), "Id", "SupplierName", importHistory.SupplierId);
            return View(importHistory);
        }

        // GET: ImportHistories/Edit/5
        public async Task<IActionResult> Edit(Guid? id)
        {
            if (!id.HasValue)
            {
                return NotFound();
            }

            var importHistory = await _importHistoryRepo.GetById(id.Value);
            if (importHistory == null)
            {
                return NotFound();
            }

            ViewData["InventoryId"] = new SelectList(await _inventoryRepo.GetAll(), "Id", "Name", importHistory.InventoryId);
            ViewData["SupplierId"] = new SelectList(await _supplierRepo.GetAll(), "Id", "SupplierName", importHistory.SupplierId);
            return View(importHistory);
        }

        // POST: ImportHistories/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Guid id, ImportHistory importHistory)
        {
            if (id != importHistory.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    await _importHistoryRepo.Update(id, importHistory);
                }
                catch (DbUpdateConcurrencyException)
                {
                    bool exists = await _importHistoryRepo.EntityExists(importHistory.Id);
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

            ViewData["InventoryId"] = new SelectList(await _inventoryRepo.GetAll(), "Id", "Name", importHistory.InventoryId);
            ViewData["SupplierId"] = new SelectList(await _supplierRepo.GetAll(), "Id", "SupplierName", importHistory.SupplierId);
            return View(importHistory);
        }

        // GET: ImportHistories/Delete/5
        public async Task<IActionResult> Delete(Guid? id)
        {
            if (!id.HasValue)
            {
                return NotFound();
            }

            var importHistory = await _importHistoryRepo.GetById(id.Value);
            if (importHistory == null)
            {
                return NotFound();
            }

            return View(importHistory);
        }

        // POST: ImportHistories/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(Guid id)
        {
            var importHistory = await _importHistoryRepo.GetById(id);
            if (importHistory != null)
            {
                await _importHistoryRepo.Delete(id);
            }

            return RedirectToAction(nameof(Index));
        }
    }
}
