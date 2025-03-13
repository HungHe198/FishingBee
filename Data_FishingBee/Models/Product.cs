using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data_FishingBee.Models
{
    public class Product
    {
        public Guid Id { get; set; }
        public Guid CategoryId { get; set; }
        public Guid ManufacturerId { get; set; }

        public Guid? CreatedBy { get; set; }
        public DateTime? CreatedTime { get; set; }
        public Guid? ModifiedBy { get; set; }
        public DateTime? ModifiedTime { get; set; }
        public string? Status { get; set; }
        public ICollection<ProductDetail>? ProductDetails { get; set; } = new List<ProductDetail>();
        public Category? Category { get; set; }
        public Manufacturer? Manufacturer { get; set; }
    }
}
