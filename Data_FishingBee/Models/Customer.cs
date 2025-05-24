using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Data_FishingBee.Models
{
    public class Customer
    {
        public Guid Id { get; set; }

        [Display(Name = "Tài khoản người dùng")]
        public Guid UserId { get; set; }

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

        [Display(Name = "Họ và tên")]
        public string FullName { get; set; } = string.Empty;

        [Display(Name = "Số CCCD/CMND")]
        public string IDCardNumber { get; set; } = string.Empty;

        [Display(Name = "Địa chỉ")]
        public string? Address { get; set; }

        [Display(Name = "Ngày sinh")]
        public DateTime? DoB { get; set; }

        [Display(Name = "Điểm tích lũy")]
        public int LoyaltyPoints { get; set; }

        public ICollection<CustomerActivityLog>? CustomerActivityLogs { get; set; } = new List<CustomerActivityLog>();
        public ICollection<Cart>? Carts { get; set; } = new List<Cart>();
        public ICollection<Bill>? Bills { get; set; } = new List<Bill>();
        public ICollection<CustomerSupport>? CustomerSupports { get; set; } = new List<CustomerSupport>();

        public User? User { get; set; }
    }
}
