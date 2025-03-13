using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data_FishingBee.Models
{
    public class BillDetail
    {
        public int Id { get; set; }  // Khóa chính

        public int BillId { get; set; } // FK đến Bill
        public int ProductDetailId { get; set; } // FK đến ProductDetail

        public string? CreatedBy { get; set; }
        public DateTime? CreatedTime { get; set; }
        public string? ModifiedBy { get; set; }
        public DateTime? ModifiedTime { get; set; }
        public string? Status { get; set; }

        public decimal UnitPrice { get; set; }
        public int Amount { get; set; }

        // Navigation Properties
        public Bill Bill { get; set; } = null!;
    }
}
