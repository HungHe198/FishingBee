using Data_FishingBee.ContextFile;
using Data_FishingBee.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data_FishingBee.Repositories
{
    public class ProductImageRepository : IProductImageRepository
    {
        private readonly FishingBeeDbContext _context;

        public ProductImageRepository(FishingBeeDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<ProductImage>> GetByProductId(Guid productId)
        {
            return await _context.ProductImages
                .Where(pi => pi.ProductId == productId)
                .ToListAsync();
        }

        // Các hàm khác như Create(), Delete(), ...
    }
}
