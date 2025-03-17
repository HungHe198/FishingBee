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
    public class ManufacturersController : Controller
    {
        private readonly IAllRepositories<Manufacturer> _manufacturerRepo;

        public ManufacturersController(IAllRepositories<Manufacturer> manufacturerRepo)
        {
            _manufacturerRepo = manufacturerRepo;
        }

        // GET: Manufacturers
        public async Task<IActionResult> Index()
        {
            var manufacturers = await _manufacturerRepo.GetAll();
            return View(manufacturers);
        }

        // GET: Manufacturers/Details/5
        public async Task<IActionResult> Details(Guid? id)
        {
            if (!id.HasValue)
            {
                return NotFound();
            }

            var manufacturer = await _manufacturerRepo.GetById(id.Value);
            if (manufacturer == null)
            {
                return NotFound();
            }

            return View(manufacturer);
        }

        // GET: Manufacturers/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Manufacturers/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Manufacturer manufacturer)
        {
            if (ModelState.IsValid)
            {
                manufacturer.Id = Guid.NewGuid();
                await _manufacturerRepo.Create(manufacturer);
                return RedirectToAction(nameof(Index));
            }
            return View(manufacturer);
        }

        // GET: Manufacturers/Edit/5
        public async Task<IActionResult> Edit(Guid? id)
        {
            if (!id.HasValue)
            {
                return NotFound();
            }

            var manufacturer = await _manufacturerRepo.GetById(id.Value);
            if (manufacturer == null)
            {
                return NotFound();
            }

            return View(manufacturer);
        }

        // POST: Manufacturers/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Guid id, Manufacturer manufacturer)
        {
            if (id != manufacturer.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    await _manufacturerRepo.Update(id, manufacturer);
                }
                catch (DbUpdateConcurrencyException)
                {
                    bool exists = await _manufacturerRepo.EntityExists(manufacturer.Id);
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
            return View(manufacturer);
        }

        // GET: Manufacturers/Delete/5
        public async Task<IActionResult> Delete(Guid? id)
        {
            if (!id.HasValue)
            {
                return NotFound();
            }

            var manufacturer = await _manufacturerRepo.GetById(id.Value);
            if (manufacturer == null)
            {
                return NotFound();
            }

            return View(manufacturer);
        }

        // POST: Manufacturers/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(Guid id)
        {
            var manufacturer = await _manufacturerRepo.GetById(id);
            if (manufacturer != null)
            {
                await _manufacturerRepo.Delete(id);
            }

            return RedirectToAction(nameof(Index));
        }
    }

}
