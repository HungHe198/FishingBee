using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data_FishingBee.Models
{
    public class BillDetail
    {
        public Guid Id { get; set; }  // Khóa chính

        public Guid BillId { get; set; } // FK đến Bill
        public Guid ProductDetailId { get; set; } // FK đến ProductDetail

        public Guid? CreatedBy { get; set; }
        public DateTime? CreatedTime { get; set; }
        public Guid? ModifiedBy { get; set; }
        public DateTime? ModifiedTime { get; set; }

        public decimal UnitPrice { get; set; }
        public int Amount { get; set; }

        // Navigation Properties
        public Bill Bill { get; set; } = null!;
        public ProductDetail? ProductDetail { get; set; } = null!;
    }
}
