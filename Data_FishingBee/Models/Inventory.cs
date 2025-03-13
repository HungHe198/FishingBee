using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data_FishingBee.Models
{
    public class Inventory
    {
        public Guid Id { get; set; }
        public Guid ProductDetailId { get; set; }

        public Guid? CreatedBy { get; set; }
        public DateTime? CreatedTime { get; set; }
        public Guid? ModifiedBy { get; set; }
        public DateTime? ModifiedTime { get; set; }
        public string? Status { get; set; }
        public int Stock { get; set; }

        public ICollection<Inventory>? Inventories { get; set; } = new List<Inventory>();
        public ProductDetail? ProductDetail { get; set; }
    }
}
