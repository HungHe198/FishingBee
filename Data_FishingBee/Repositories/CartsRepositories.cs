using Data_FishingBee.ContextFile;
using Data_FishingBee.Models;
using System;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data_FishingBee.Repositories
{
    public class CartRepository
    {
        private readonly FishingBeeDbContext _context;

        public CartRepository(FishingBeeDbContext context)
        {
            _context = context;
        }

        // ✅ Lấy giỏ hàng của khách hàng
        public async Task<Cart> GetCartByCustomerIdAsync(Guid customerId)
        {
            return await _context.Carts
                .Include(c => c.Cart_PDs)
                .ThenInclude(cp => cp.ProductDetail)
                .FirstOrDefaultAsync(c => c.CustomerId == customerId && c.Status == "Active");
        }

        // ✅ Thêm sản phẩm vào giỏ hàng
        public async Task AddToCartAsync(Guid customerId, Guid productDetailId, int quantity)
        {
            var cart = await GetCartByCustomerIdAsync(customerId);

            if (cart == null)
            {
                cart = new Cart
                {
                    Id = Guid.NewGuid(),
                    CustomerId = customerId,
                    CreatedTime = DateTime.Now,
                    LastUpdateTime = DateTime.Now,
                    Status = "Active",
                    Cart_PDs = new List<Cart_PD>()
                };

                _context.Carts.Add(cart);
            }

            var cartItem = cart.Cart_PDs.FirstOrDefault(cp => cp.ProductDetailId == productDetailId);

            if (cartItem == null)
            {
                cart.Cart_PDs.Add(new Cart_PD
                {
                    Id = Guid.NewGuid(),
                    CartId = cart.Id,
                    ProductDetailId = productDetailId
                });
            }

            cart.LastUpdateTime = DateTime.Now;
            await _context.SaveChangesAsync();
        }

        // ✅ Xóa sản phẩm khỏi giỏ hàng
        public async Task RemoveFromCartAsync(Guid customerId, Guid productDetailId)
        {
            var cart = await GetCartByCustomerIdAsync(customerId);

            if (cart != null)
            {
                var cartItem = cart.Cart_PDs.FirstOrDefault(cp => cp.ProductDetailId == productDetailId);
                if (cartItem != null)
                {
                    cart.Cart_PDs.Remove(cartItem);
                    await _context.SaveChangesAsync();
                }
            }
        }

        // ✅ Xóa toàn bộ giỏ hàng
        public async Task ClearCartAsync(Guid customerId)
        {
            var cart = await GetCartByCustomerIdAsync(customerId);

            if (cart != null)
            {
                _context.Cart_PDs.RemoveRange(cart.Cart_PDs);
                await _context.SaveChangesAsync();
            }
        }
    }

}
