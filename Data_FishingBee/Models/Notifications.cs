using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Data_FishingBee.Models
{
    public class Notifications
    {
        [Display(Name = "Mã thông báo")]
        public Guid Id { get; set; }  // Khóa chính

        [Display(Name = "Mã nhân viên")]
        public Guid EmployeeId { get; set; }  // Khóa ngoại liên kết với Employee

        [Display(Name = "Tiêu đề")]
        public string Title { get; set; } = string.Empty;

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

        [Display(Name = "Nội dung")]
        public string Content { get; set; } = string.Empty;

        [Display(Name = "Loại thông báo")]
        public string? NotificationType { get; set; }

        [Display(Name = "Người gửi")]
        public Guid? SenderId { get; set; }

        [Display(Name = "Người nhận")]
        public Guid? ReceiverId { get; set; }

        [Display(Name = "Hạn hiệu lực")]
        public DateTime? ExpiredAt { get; set; }

        [Display(Name = "Độ ưu tiên")]
        public int? Priority { get; set; }

        [Display(Name = "Tệp đính kèm")]
        public string? AttachmentUrl { get; set; }

        // Navigation Property
        [Display(Name = "Nhân viên")]
        public Employee Employee { get; set; } = null!;
    }
}
