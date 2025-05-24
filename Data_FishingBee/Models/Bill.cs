using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
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

        [Display(Name = "Người tạo")]
        public Guid? CreatedBy { get; set; }

        [Display(Name = "Thời gian tạo")]
        public DateTime? CreatedTime { get; set; }

        [Display(Name = "Người sửa")]
        public Guid? ModifiedBy { get; set; }

        [Display(Name = "Thời gian sửa")]
        public DateTime? ModifiedTime { get; set; }

        [Display(Name = "Trạng thái")]
        public string? Status { get; set; }

        // Thông tin người mua
        [Display(Name = "Mã đơn hàng")]
        public string InvoiceCode { get; set; } = string.Empty;

        [Display(Name = "Tổng tiền")]
        public decimal TotalPrice { get; set; }

        [Display(Name = "Tên khách hàng")]
        public string CustomerName { get; set; } = string.Empty;

        [Display(Name = "Số điện thoại khách hàng")]
        public string CustomerPhone { get; set; } = string.Empty;

        [Display(Name = "Địa chỉ khách hàng")]
        public string CustomerAddress { get; set; } = string.Empty;

        // Thông tin người xác nhận
        [Display(Name = "Tên nhân viên xác nhận")]
        public string? EmployeeName { get; set; } = string.Empty;

        [Display(Name = "Số điện thoại nhân viên")]
        public string? EmployeePhone { get; set; } = string.Empty;

        [Display(Name = "Địa chỉ nhân viên")]
        public string? EmployeeAddress { get; set; } = string.Empty;

        // Thông tin người giao hàng
        [Display(Name = "Tên người giao hàng")]
        public string? DeliveryName { get; set; } = string.Empty;

        [Display(Name = "Số điện thoại người giao hàng")]
        public string? DeliveryPhone { get; set; } = string.Empty;

        [Display(Name = "Địa chỉ người giao hàng")]
        public string? DeliveryAddress { get; set; } = string.Empty;

        [Display(Name = "Ghi chú giao hàng")]
        public string? DeliveryNote { get; set; } = string.Empty;

        [Display(Name = "Phương thức thanh toán")]
        public string PaymentMethod { get; set; } = string.Empty;
        // Navigation Properties
        public ICollection<BillDetail>? BillDetails { get; set; } = new List<BillDetail>();

    }
}
