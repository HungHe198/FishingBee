using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data_FishingBee.Models
{
    public class Bill
    {
        public Guid Id { get; set; }  // Khóa chính

        public Guid? AdminId { get; set; } // FK đến Admin
        public Guid? EmployeeId { get; set; } // FK đến Employee
        public Guid CustomerId { get; set; } // FK đến Customer
        public Guid? CouponId { get; set; } // FK đến Coupon (nullable)

        public Guid? CreatedBy { get; set; }
        public DateTime? CreatedTime { get; set; }
        public Guid? ModifiedBy { get; set; }
        public DateTime? ModifiedTime { get; set; }
        public string? Status { get; set; }
        // thông tin người mua
        public string InvoiceCode { get; set; } = string.Empty;
        public decimal TotalPrice { get; set; }
        public string CustomerName { get; set; } = string.Empty;
        public string CustomerPhone { get; set; } = string.Empty;
        public string CustomerAddress { get; set; } = string.Empty;
        // thông tin người xác nhận
        public string? EmployeeName { get; set; } = string.Empty;
        public string? EmployeePhone { get; set; } = string.Empty;
        public string? EmployeeAddress { get; set; } = string.Empty;
        // thông tin người giao hàng
        public string? DeliveryName { get; set; } = string.Empty;
        public string? DeliveryPhone { get; set; } = string.Empty;
        public string? DeliveryAddress { get; set; } = string.Empty;
        public string? DeliveryNote { get; set; } = string.Empty;
        /// <summary>
        /// ////////
        /// </summary>
        public string PaymentMethod { get; set; } = string.Empty;

        // Navigation Properties
        public ICollection<BillDetail>? BillDetails { get; set; } = new List<BillDetail>();

    }
}
