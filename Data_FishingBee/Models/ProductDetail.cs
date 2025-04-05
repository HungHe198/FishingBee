using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data_FishingBee.Models
{
    public class ProductDetail
    {
        public Guid Id { get; set; }  // Khóa chính

        public Guid ProductId { get; set; } // FK đến Product

        public Guid? CreatedBy { get; set; }
        public DateTime? CreatedTime { get; set; }
        public Guid? ModifiedBy { get; set; }
        public DateTime? ModifiedTime { get; set; }
        public string? Status { get; set; }

        
        public string? Description { get; set; }

        
        public string? AttributeValue { get; set; }

        
        public decimal Price { get; set; }
        public decimal Stock { get; set; }

        // Navigation Property
        public ICollection<BillDetail>? BillDetails { get; set; } = new List<BillDetail>();
        public ICollection<Cart_PD>? Cart_PDs { get; set; } = new List<Cart_PD>();
        public Product Product { get; set; } = null!;
        public Inventory Inventory { get; set; } = null!;
    }
}
