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
    public class SuppliersController : Controller
    {
        private readonly IAllRepositories<Supplier> _supplierRepo;

        public SuppliersController(IAllRepositories<Supplier> supplierRepo)
        {
            _supplierRepo = supplierRepo;
        }

        // GET: Suppliers
        public async Task<IActionResult> Index()
        {
            var suppliers = await _supplierRepo.GetAll();
            return View(suppliers);
        }

        // GET: Suppliers/Details/5
        public async Task<IActionResult> Details(Guid? id)
        {
            if (!id.HasValue)
            {
                return NotFound();
            }

            var supplier = await _supplierRepo.GetById(id.Value);
            if (supplier == null)
            {
                return NotFound();
            }

            return View(supplier);
        }

        // GET: Suppliers/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Suppliers/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Supplier supplier)
        {
            if (ModelState.IsValid)
            {
                supplier.Id = Guid.NewGuid();
                await _supplierRepo.Create(supplier);
                return RedirectToAction(nameof(Index));
            }
            return View(supplier);
        }

        // GET: Suppliers/Edit/5
        public async Task<IActionResult> Edit(Guid? id)
        {
            if (!id.HasValue)
            {
                return NotFound();
            }

            var supplier = await _supplierRepo.GetById(id.Value);
            if (supplier == null)
            {
                return NotFound();
            }

            return View(supplier);
        }

        // POST: Suppliers/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Guid id, Supplier supplier)
        {
            if (id != supplier.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    await _supplierRepo.Update(id, supplier);
                }
                catch (DbUpdateConcurrencyException)
                {
                    bool exists = await _supplierRepo.EntityExists(supplier.Id);
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

            return View(supplier);
        }

        // GET: Suppliers/Delete/5
        public async Task<IActionResult> Delete(Guid? id)
        {
            if (!id.HasValue)
            {
                return NotFound();
            }

            var supplier = await _supplierRepo.GetById(id.Value);
            if (supplier == null)
            {
                return NotFound();
            }

            return View(supplier);
        }

        // POST: Suppliers/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(Guid id)
        {
            var supplier = await _supplierRepo.GetById(id);
            if (supplier != null)
            {
                await _supplierRepo.Delete(id);
            }

            return RedirectToAction(nameof(Index));
        }
    }

}
