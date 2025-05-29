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
    public class CartRepository : ICartRepository
    {
        private readonly FishingBeeDbContext _context;

        public CartRepository(FishingBeeDbContext context)
        {
            _context = context;
        }

        // ✅ Lấy giỏ hàng của khách hàng
        public async Task<Cart> GetCartByCustomerIdAsync(Guid customerId)
        {
            //Tìm mã giỏ hàng của khách hàng
            var cart = await _context.Carts.FirstOrDefaultAsync(c => c.CustomerId == customerId);

            if (cart == null)
            {
                // Handle the case where the cart is not found
                // For example, you can throw an exception or return a default value
                throw new Exception("Cart not found for the given customer ID.");
            }

            return cart;
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
				await _context.SaveChangesAsync();  // Lưu giỏ hàng vào database trước
			}

			var cartItem = cart.Cart_PDs.FirstOrDefault(cp => cp.ProductDetailId == productDetailId);
			if (cartItem == null)
			{
				cartItem = new Cart_PD
				{
					Id = Guid.NewGuid(),
					CartId = cart.Id,
					ProductDetailId = productDetailId,
					Quantity = quantity
				};

				_context.Cart_PDs.Add(cartItem);  // 🔴 Thêm cartItem mới vào database
			}
			else
			{
				cartItem.Quantity += quantity;
				_context.Cart_PDs.Update(cartItem); // 🔴 Đánh dấu cartItem đã thay đổi
			}

			cart.LastUpdateTime = DateTime.Now;
			try
			{
				await _context.SaveChangesAsync();
			}
			catch (DbUpdateConcurrencyException ex)
			{
				// Log lỗi ra console hoặc file log để debug
				Console.WriteLine($"Concurrency Error: {ex.Message}");

				// Gửi thông báo lỗi
				throw new Exception("Có lỗi xảy ra khi cập nhật giỏ hàng. Vui lòng thử lại!");
			}
		}

        // ✅ Xóa sản phẩm khỏi giỏ hàng theo CustomerId và ProductDetailId
        public async Task RemoveFromCartAsync(Guid customerId, Guid productDetailId)
        {
            var cart = await GetCartByCustomerIdAsync(customerId);

            if (cart != null)
            {
                var cartItem = cart.Cart_PDs.FirstOrDefault(cp => cp.ProductDetailId == productDetailId);
                if (cartItem != null)
                {
                    _context.Cart_PDs.Remove(cartItem);
                    await _context.SaveChangesAsync();
                }
            }
        }

        // ✅ Xóa sản phẩm khỏi giỏ hàng theo Cart_PD Id
        public async Task RemoveFromCartAsync(Guid cartPdId)
        {
            var cartItem = await _context.Cart_PDs.FindAsync(cartPdId);
            if (cartItem != null)
            {
                _context.Cart_PDs.Remove(cartItem);
                await _context.SaveChangesAsync();
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
