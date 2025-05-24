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
    public class CategoriesController : Controller
    {
        private readonly IAllRepositories<Category> _repo;

        public CategoriesController(IAllRepositories<Category> repo)
        {
            _repo = repo;
        }



        // GET: Categories
        public async Task<IActionResult> Index()
        {
            //return _context.Categories != null ? 
            //            View(await _context.Categories.ToListAsync()) :
            //            Problem("Entity set 'FishingBeeDbContext.Categories'  is null.");
            var categories = await _repo.GetAll();
            return View(categories);
        }

        // GET: Categories/Details/5
        public async Task<IActionResult> Details(Guid? id)
        {
            if (!id.HasValue || id == null || _repo.GetAll() == null)
            {
                return NotFound();
            }

            //var category = await _context.Categories
            //    .FirstOrDefaultAsync(m => m.Id == id);
            //if (category == null)
            //{
            //    return NotFound();
            //}

            //return View(category);
            else
            {
                var category = await _repo.GetById(id.Value);
                return View(category);
            }

        }

        // GET: Categories/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Categories/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Category category)
        {
            //if (ModelState.IsValid)
            //{
            //    category.Id = Guid.NewGuid();
            //    _context.Add(category);
            //    await _context.SaveChangesAsync();
            //    return RedirectToAction(nameof(Index));
            //}
            //return View(category);
            if (ModelState.IsValid)
            {
                await _repo.Create(category);
                
            }
            return RedirectToAction(nameof(Index));
        }

        // GET: Categories/Edit/5
        public async Task<IActionResult> Edit(Guid? id)
        {
            //if (id == null || _context.Categories == null)
            //{
            //    return NotFound();
            //}

            //var category = await _context.Categories.FindAsync(id);
            //if (category == null)
            //{
            //    return NotFound();
            //}
            //return View(category);
            if (!id.HasValue || id == null || _repo.GetAll() == null)
            {
                return NotFound();
            }

            //var category = await _context.Categories
            //    .FirstOrDefaultAsync(m => m.Id == id);
            //if (category == null)
            //{
            //    return NotFound();
            //}

            //return View(category);
            else
            {
                var category = await _repo.GetById(id.Value);
                return View(category);
            }


        }

        // POST: Categories/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Guid id, [Bind("Id,CreatedBy,CreatedTime,ModifiedBy,ModifiedTime,Status,Name,Description")] Category category)
        {
            //if (id != category.Id)
            //{
            //    return NotFound();
            //}

            //if (ModelState.IsValid)
            //{
            //    try
            //    {
            //        _context.Update(category);
            //        await _context.SaveChangesAsync();
            //    }
            //    catch (DbUpdateConcurrencyException)
            //    {
            //        if (!CategoryExists(category.Id))
            //        {
            //            return NotFound();
            //        }
            //        else
            //        {
            //            throw;
            //        }
            //    }
            //    return RedirectToAction(nameof(Index));
            //}
            //return View(category);
            if (id != category.Id)
            {
                return NotFound();
            }
            if (ModelState.IsValid)
            {
                try
                {
                    await _repo.Update(id, category);
                }
                catch (DbUpdateConcurrencyException)
                {
                    bool exists = await _repo.EntityExists(category.Id);

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
            return View(category);

        }

        // GET: Categories/Delete/5
        public async Task<IActionResult> Delete(Guid? id)
        {
            //if (id == null || _context.Categories == null)
            //{
            //    return NotFound();
            //}

            //var category = await _context.Categories
            //    .FirstOrDefaultAsync(m => m.Id == id);
            //if (category == null)
            //{
            //    return NotFound();
            //}

            //return View(category);
            if (id == null || _repo.GetAll() == null)
            {
                return NotFound();
            }

            var category = await _repo.GetById(id.Value);
            if (category == null)
            {
                return NotFound();
            }

            return View(category);
        }

        // POST: Categories/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(Guid id)
        {
            //if (_context.Categories == null)
            //{
            //    return Problem("Entity set 'FishingBeeDbContext.Categories'  is null.");
            //}
            //var category = await _context.Categories.FindAsync(id);
            //if (category != null)
            //{
            //    _context.Categories.Remove(category);
            //}

            //await _context.SaveChangesAsync();
            //return RedirectToAction(nameof(Index));

            if (_repo.GetAll() == null)
            {
                return Problem("Entity set 'FishingBeeDbContext.Categories'  is null.");
            }
            var category = await _repo.GetById(id);
            if (category != null)
            {
               await _repo.Delete(id);
            }

            
            return RedirectToAction(nameof(Index));
        }

        //private bool CategoryExists(Guid id)
        //{
        //  return (_context.Categories?.Any(e => e.Id == id)).GetValueOrDefault();
        //}
    }
}
