using Data_FishingBee.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data_FishingBee.Repositories
{
    public interface ICartRepository
    {
        Task<Cart> GetCartByCustomerIdAsync(Guid customerId);
        Task AddToCartAsync(Guid customerId, Guid productDetailId, int quantity);
        Task RemoveFromCartAsync(Guid cartPdId);
    }
}
