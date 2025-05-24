using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations; // Thêm namespace này
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data_FishingBee.Models
{
    public class User
    {
        [Display(Name = "Mã người dùng")]
        public Guid Id { get; set; }  // Khóa chính

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

        [Display(Name = "Tên người dùng")]
        public string Username { get; set; } = string.Empty;

        [Display(Name = "Mật khẩu")]
        public string Password { get; set; } = string.Empty;

        [Display(Name = "Email")]
        public string Email { get; set; } = string.Empty;

        [Display(Name = "Số điện thoại")]
        public string? PhoneNumber { get; set; }

        [Display(Name = "Loại người dùng")]
        public string? UserType { get; set; }

        // Navigation property để liên kết với Admin (nếu có)
        [Display(Name = "Quản trị viên")]
        public Admin? Admin { get; set; }

        [Display(Name = "Khách hàng")]
        public Customer? Customer { get; set; }

        [Display(Name = "Nhân viên")]
        public Employee? Employee { get; set; }
    }
}