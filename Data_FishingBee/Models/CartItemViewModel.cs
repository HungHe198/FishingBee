using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data_FishingBee.Models
{
    public class CartItemViewModel
    {
        public Guid Id { get; set; }
        public string ProductName { get; set; }
        public string ProductDetail { get; set; }
        public string ImageUrl { get; set; }
        public decimal Price { get; set; }
        public int Quantity { get; set; }
    }

}
