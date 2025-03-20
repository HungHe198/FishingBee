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
    public class Cart_PDController : Controller
    {
        private readonly IAllRepositories<Cart_PD> _repoCartPD;
        private readonly IAllRepositories<Cart> _repoCart;
        private readonly IAllRepositories<ProductDetail> _repoPD;

        public Cart_PDController(IAllRepositories<Cart_PD> repoCartPD, IAllRepositories<Cart> repoCart, IAllRepositories<ProductDetail> repoPD)
        {
            _repoCartPD = repoCartPD;
            _repoCart = repoCart;
            _repoPD = repoPD;
        }

        // GET: Cart_PD
        public async Task<IActionResult> Index()
        {
            // Lấy CustomerId từ Session
            var customerIdJson = HttpContext.Session.GetString("CustomerId");
            if (string.IsNullOrEmpty(customerIdJson))
            {
                return RedirectToAction("Login", "Account"); // Điều hướng nếu chưa đăng nhập
            }

            var customerId = Guid.Parse(customerIdJson);

            // Lọc giỏ hàng theo CustomerId
            var fishingBeeDbContext = _repoCartPD
                .GetAllQueryable()
                .Include(c => c.Cart)
                .Include(c => c.ProductDetail)
                .Where(c => c.Cart.CustomerId == customerId); // 🔥 Chỉ lấy dữ liệu của khách hàng này

            return View(await fishingBeeDbContext.ToListAsync());
        }

        // GET: Cart_PD/Details/5
        public async Task<IActionResult> Details(Guid? id)
        {
            if (id == null || _repoCartPD.GetAllQueryable() == null)
            {
                return NotFound();
            }

            var cart_PD = await _repoCartPD.GetAllQueryable()
                .Include(c => c.Cart)
                .Include(c => c.ProductDetail)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (cart_PD == null)
            {
                return NotFound();
            }

            return View(cart_PD);
        }

        // GET: Cart_PD/Create
        public IActionResult Create()
        {
            ViewData["CartId"] = new SelectList(_repoCart.GetAllQueryable(), "Id", "Status");
            ViewData["ProductDetailId"] = new SelectList(_repoPD.GetAllQueryable(), "Id", "Id");
            return View();
        }

        // POST: Cart_PD/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,ProductDetailId,CartId,Quantity")] Cart_PD cart_PD)
        {
            if (ModelState.IsValid)
            {
                cart_PD.Id = Guid.NewGuid();
                _repoCartPD.Create(cart_PD);
                return RedirectToAction(nameof(Index));
            }
            ViewData["CartId"] = new SelectList(_repoCart.GetAllQueryable(), "Id", "Status", cart_PD.CartId);
            ViewData["ProductDetailId"] = new SelectList(_repoPD.GetAllQueryable(), "Id", "Id", cart_PD.ProductDetailId);
            return View(cart_PD);
        }

        // GET: Cart_PD/Edit/5
        public async Task<IActionResult> Edit(Guid? id)
        {
            if (id == null || _repoCartPD.GetAllQueryable() == null)
            {
                return NotFound();
            }

            var cart_PD = await _repoCartPD.GetById(id.Value);
            if (cart_PD == null)
            {
                return NotFound();
            }
            ViewData["CartId"] = new SelectList(_repoCart.GetAllQueryable(), "Id", "Status", cart_PD.CartId);
            ViewData["ProductDetailId"] = new SelectList(_repoPD.GetAllQueryable(), "Id", "Id", cart_PD.ProductDetailId);
            return View(cart_PD);
        }

        // POST: Cart_PD/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Guid id, [Bind("Id,ProductDetailId,CartId,Quantity")] Cart_PD cart_PD)
        {
            if (id != cart_PD.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _repoCartPD.Update(id,cart_PD);
                   
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!(await _repoCartPD.EntityExists(cart_PD.Id)))
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
            ViewData["CartId"] = new SelectList(_repoCart.GetAllQueryable(), "Id", "Status", cart_PD.CartId);
            ViewData["ProductDetailId"] = new SelectList(_repoPD.GetAllQueryable(), "Id", "Id", cart_PD.ProductDetailId);
            return View(cart_PD);
        }

        // GET: Cart_PD/Delete/5
        public async Task<IActionResult> Delete(Guid? id)
        {
            if (id == null || _repoPD.GetAllQueryable() == null)
            {
                return NotFound();
            }

            var cart_PD = await _repoCartPD.GetAllQueryable()
                .Include(c => c.Cart)
                .Include(c => c.ProductDetail)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (cart_PD == null)
            {
                return NotFound();
            }

            return View(cart_PD);
        }

        // POST: Cart_PD/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(Guid id)
        {
            if (_repoCartPD.GetAllQueryable() == null)
            {
                return Problem("Entity set 'FishingBeeDbContext.Cart_PDs'  is null.");
            }
            var cart_PD = await _repoCartPD.GetById(id);
            if (cart_PD != null)
            {
                _repoCartPD.Delete(id);
            }
            
           
            return RedirectToAction(nameof(Index));
        }

      
    }
}
