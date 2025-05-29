using Data_FishingBee.ContextFile;
using Data_FishingBee.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
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

        public async Task<List<ProductImage>> GetByProductId(Guid productId)
        {
            try
            {
                var images = await _context.ProductImages
                    .Where(i => i.ProductId == productId)
                    .ToListAsync();
                return images; // ToListAsync() đã được await, trả về List<ProductImage> và được tự động bọc trong Task
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error fetching images for product {productId}: {ex.Message}");
                return await Task.FromResult(new List<ProductImage>()); // Bọc List<ProductImage> trong Task
            }
        }
    }
}