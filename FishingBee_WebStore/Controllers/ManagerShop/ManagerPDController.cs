using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Data_FishingBee.ContextFile;
using Data_FishingBee.Models;

namespace FishingBee_WebStore.Controllers.ManagerShop
{
    public class ManagerPDController : Controller
    {
        private readonly FishingBeeDbContext _context;

        public ManagerPDController(FishingBeeDbContext context)
        {
            _context = context;
        }

        // GET: ManagerPD
        // Index sẽ hiển thị ra các biến thể của Id xác định truyền vào từ id của Product.
        // và quản lí cũng dựa trên id của Product
        // link sẽ kiểu là /ManagerPD/index/ProductId/..ProductDetailId..

        public async Task<IActionResult> Index()
        {
            var fishingBeeDbContext = _context.ProductDetails.Include(p => p.Product);
            return View(await fishingBeeDbContext.ToListAsync());
        }

        // GET: ManagerPD/Details/5
        public async Task<IActionResult> Details(Guid? id)
        {
            if (id == null || _context.ProductDetails == null)
            {
                return NotFound();
            }

            var productDetail = await _context.ProductDetails
                .Include(p => p.Product)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (productDetail == null)
            {
                return NotFound();
            }

            return View(productDetail);
        }

        // GET: ManagerPD/Create
        public IActionResult Create()
        {
            ViewData["ProductId"] = new SelectList(_context.Products, "Id", "Id");
            return View();
        }

        // POST: ManagerPD/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,ProductId,CreatedBy,CreatedTime,ModifiedBy,ModifiedTime,Status,Description,AttributeName,AttributeValue,AttributeUnit,Price,Stock")] ProductDetail productDetail)
        {
            if (ModelState.IsValid)
            {
                productDetail.Id = Guid.NewGuid();
                _context.Add(productDetail);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["ProductId"] = new SelectList(_context.Products, "Id", "Id", productDetail.ProductId);
            return View(productDetail);
        }

        // GET: ManagerPD/Edit/5
        public async Task<IActionResult> Edit(Guid? id)
        {
            if (id == null || _context.ProductDetails == null)
            {
                return NotFound();
            }

            var productDetail = await _context.ProductDetails.FindAsync(id);
            if (productDetail == null)
            {
                return NotFound();
            }
            ViewData["ProductId"] = new SelectList(_context.Products, "Id", "Id", productDetail.ProductId);
            return View(productDetail);
        }

        // POST: ManagerPD/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Guid id, [Bind("Id,ProductId,CreatedBy,CreatedTime,ModifiedBy,ModifiedTime,Status,Description,AttributeName,AttributeValue,AttributeUnit,Price,Stock")] ProductDetail productDetail)
        {
            if (id != productDetail.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(productDetail);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ProductDetailExists(productDetail.Id))
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
            ViewData["ProductId"] = new SelectList(_context.Products, "Id", "Id", productDetail.ProductId);
            return View(productDetail);
        }

        // GET: ManagerPD/Delete/5
        public async Task<IActionResult> Delete(Guid? id)
        {
            if (id == null || _context.ProductDetails == null)
            {
                return NotFound();
            }

            var productDetail = await _context.ProductDetails
                .Include(p => p.Product)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (productDetail == null)
            {
                return NotFound();
            }

            return View(productDetail);
        }

        // POST: ManagerPD/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(Guid id)
        {
            if (_context.ProductDetails == null)
            {
                return Problem("Entity set 'FishingBeeDbContext.ProductDetails'  is null.");
            }
            var productDetail = await _context.ProductDetails.FindAsync(id);
            if (productDetail != null)
            {
                _context.ProductDetails.Remove(productDetail);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ProductDetailExists(Guid id)
        {
          return (_context.ProductDetails?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
