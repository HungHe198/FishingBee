using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Data_FishingBee.Models
{
    public class Employee
    {
        [Display(Name = "Mã nhân viên")]
        public Guid Id { get; set; }  // Khóa chính

        [Display(Name = "Tài khoản người dùng")]
        public Guid UserId { get; set; }  // Khóa ngoại tham chiếu User.Id

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

        [Display(Name = "Mã định danh")]
        public string Code { get; set; } = string.Empty;

        [Display(Name = "Họ và tên")]
        public string Fullname { get; set; } = string.Empty;

        [Display(Name = "Chức vụ")]
        public string Position { get; set; } = string.Empty;

        [Display(Name = "Mức lương")]
        public decimal Salary { get; set; }

        [Display(Name = "Ngày tuyển dụng")]
        public DateTime? HireDate { get; set; }

        [Display(Name = "Số CMND/CCCD")]
        public string? IDCardNumber { get; set; }

        // Navigation Property
        public User? User { get; set; } = null!;

        [Display(Name = "Thông báo")]
        public ICollection<Notifications>? Notifications { get; set; }

        [Display(Name = "Hóa đơn")]
        public ICollection<Bill>? Bills { get; set; }
    }
}
