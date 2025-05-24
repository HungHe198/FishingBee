using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data_FishingBee.Models
{
    public class Admin
    {
        //public Guid Id { get; set; }  // Khóa chính riêng của Admin
        //public Guid UserId { get; set; }  // Khóa ngoại tham chiếu đến User.Id

        //public string? FullName { get; set; }
        //public string? Permissions { get; set; }
        //public string? Status { get; set; }
        //public string? Descriptions { get; set; }

        //public DateTime? CreatedTime { get; set; }
        //public Guid? CreatedBy { get; set; }
        //public DateTime? ModifiedTime { get; set; }
        //public Guid? ModifiedBy { get; set; }

        //// Navigation Property
        //public User? User { get; set; } = null!;
        //public ICollection<CustomerSupport>? CustomerSupports { get; set; }
        //public ICollection<Bill>? Bills { get; set; }
        public Guid Id { get; set; }  // Khóa chính riêng của Admin
        public Guid UserId { get; set; }  // Khóa ngoại tham chiếu đến User.Id

        [Display(Name = "Họ và tên")]
        public string? FullName { get; set; }

        [Display(Name = "Phân quyền")]
        public string? Permissions { get; set; }

        [Display(Name = "Trạng thái")]
        public string? Status { get; set; }

        [Display(Name = "Mô tả")]
        public string? Descriptions { get; set; }

        [Display(Name = "Loại người dùng")]
        public string? UserType { get; set; }

        [Display(Name = "Thời gian tạo")]
        public DateTime? CreatedTime { get; set; }

        [Display(Name = "Người tạo")]
        public Guid? CreatedBy { get; set; }

        [Display(Name = "Thời gian sửa")]
        public DateTime? ModifiedTime { get; set; }

        [Display(Name = "Người sửa")]
        public Guid? ModifiedBy { get; set; }

        // Navigation Property
        public User? User { get; set; } = null!;
        public ICollection<CustomerSupport>? CustomerSupports { get; set; }
        public ICollection<Bill>? Bills { get; set; }

    }
}
