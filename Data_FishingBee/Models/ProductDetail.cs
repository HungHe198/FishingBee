using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data_FishingBee.Models
{
    public class ProductDetail
    {
        public int Id { get; set; }  // Khóa chính

        public int ProductId { get; set; } // FK đến Product

        public string? CreatedBy { get; set; }
        public DateTime? CreatedTime { get; set; }
        public string? ModifiedBy { get; set; }
        public DateTime? ModifiedTime { get; set; }
        public string? Status { get; set; }

        public string Name { get; set; } = string.Empty;
        public string? Description { get; set; }

        public string? AttributeName { get; set; }
        public string? AttributeValue { get; set; }
        public string? AttributeUnit { get; set; }

        public decimal Price { get; set; }

        // Navigation Property
        public Product Product { get; set; } = null!;
        public Cart_PD Cart_PD { get; set; } = null!;
        public BillDetail BillDetail { get; set; } = null!;
        public Inventory Inventory { get; set; } = null!;
    }
}
