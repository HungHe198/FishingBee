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

namespace FishingBee_WebStore.Controllers.Products
{
    public class ProductsController : Controller
    {
        private readonly IAllRepositories<Product> _repo;

		public ProductsController(IAllRepositories<Product> repo)
		{
			_repo = repo;
		}


		// GET: Products
		public async Task<IActionResult> Index()
        {
            var lstProducts = await _repo.GetAll();
            return View(lstProducts);
        }

        // GET: Products/Details/5
        //public async Task<IActionResult> Details(Guid? id)
        //{
        //}

        // GET: Products/Create
        public async Task<IActionResult> Create()
        {
            
            return View();
        }

        // POST: Products/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,CategoryId,ManufacturerId,CreatedBy,CreatedTime,ModifiedBy,ModifiedTime,Status")] Product product)
        {

            var Creat = await _repo.Create(product);

            return View(Creat);
        }

        // GET: Products/Edit/5
        //public async Task<IActionResult> Edit(Guid? id)
        //{
          
        //}

        //// POST: Products/Edit/5
        //// To protect from overposting attacks, enable the specific properties you want to bind to.
        //// For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public async Task<IActionResult> Edit(Guid id, [Bind("Id,CategoryId,ManufacturerId,CreatedBy,CreatedTime,ModifiedBy,ModifiedTime,Status")] Product product)
        //{
           
        //}

        //// GET: Products/Delete/5
        //public async Task<IActionResult> Delete(Guid? id)
        //{
           
        //}

        //// POST: Products/Delete/5
        //[HttpPost, ActionName("Delete")]
        //[ValidateAntiForgeryToken]
        //public async Task<IActionResult> DeleteConfirmed(Guid id)
        //{
           
        //}

        //private bool ProductExists(Guid id)
        //{
           
        //}
    }
}
