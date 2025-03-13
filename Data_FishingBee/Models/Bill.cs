using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data_FishingBee.Models
{
    public class Bill
    {
        public int Id { get; set; }  // Khóa chính

        public int AdminId { get; set; } // FK đến Admin
        public int EmployeeId { get; set; } // FK đến Employee
        public int CustomerId { get; set; } // FK đến Customer
        public int? CouponId { get; set; } // FK đến Coupon (nullable)

        public string? CreatedBy { get; set; }
        public DateTime? CreatedTime { get; set; }
        public string? ModifiedBy { get; set; }
        public DateTime? ModifiedTime { get; set; }
        public string? Status { get; set; }

        public string InvoiceCode { get; set; } = string.Empty;
        public decimal TotalPrice { get; set; }
        public string CustomerName { get; set; } = string.Empty;
        public string PaymentMethod { get; set; } = string.Empty;

        // Navigation Properties
        public ICollection<BillDetail> BillDetails { get; set; } = new List<BillDetail>();

    }
}
