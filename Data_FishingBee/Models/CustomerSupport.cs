using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Data_FishingBee.Models
{
    public class CustomerSupport
    {
        [Display(Name = "Mã hỗ trợ")]
        public Guid Id { get; set; }  // Khóa chính

        [Display(Name = "Quản trị viên hỗ trợ")]
        public Guid AdminId { get; set; } // FK đến Admin

        [Display(Name = "Khách hàng")]
        public Guid CustomerId { get; set; } // FK đến Customer

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

        [Display(Name = "Chủ đề")]
        public string Subject { get; set; } = string.Empty;

        [Display(Name = "Mô tả")]
        public string Description { get; set; } = string.Empty;

        [Display(Name = "Hướng xử lý")]
        public string? Resolution { get; set; }

        [Display(Name = "Thời gian hoàn tất")]
        public DateTime? ResolvedAt { get; set; }

        [Display(Name = "Phản hồi của khách hàng")]
        public string? CustomerFeedback { get; set; }

        [Display(Name = "Đánh giá hỗ trợ")]
        public int? RatingForSupport { get; set; } // Đánh giá hỗ trợ, có thể null

        // Navigation Properties
        public Admin Admin { get; set; } = null!;
        public Customer Customer { get; set; } = null!;
    }
}
