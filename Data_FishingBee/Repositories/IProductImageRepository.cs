using Data_FishingBee.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data_FishingBee.Repositories
{
    public interface IProductImageRepository
    {
        Task<IEnumerable<ProductImage>> GetByProductId(Guid productId);

    }
}
