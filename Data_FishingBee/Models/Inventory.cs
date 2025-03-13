using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data_FishingBee.Models
{
    public class Inventory
    {
        public int Id { get; set; }
        public int ProductDetailId { get; set; }

        public string? CreatedBy { get; set; }
        public DateTime? CreatedTime { get; set; }
        public string? ModifiedBy { get; set; }
        public DateTime? ModifiedTime { get; set; }
        public string? Status { get; set; }
        public int Stock { get; set; }

        public ProductDetail ProductDetail { get; set; } = null!;
        public ImportHistory ImportHistory { get; set; } = null!;
    }
}
