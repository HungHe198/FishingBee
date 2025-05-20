using Data_FishingBee.ContextFile;
using Data_FishingBee.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;


namespace Data_FishingBee.Repositories
{
    public class ProductsRepositories : IProductsRepositories
    {
        private readonly FishingBeeDbContext _context;
        public ProductsRepositories(FishingBeeDbContext context)
        {
            _context = context;
        }
        public async Task<List<Product>> GetAllByCategoryIdAsync(Guid categoryId)
        {
             return await _context.Products
                                .Where(p => p.CategoryId == categoryId)
                                .Include(p => p.Category)
                                .Include(p => p.Manufacturer)
                                .ToListAsync();
        }
    }
   
}
