using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Data_FishingBee.Models
{
    public class Coupon
    {
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

        [Display(Name = "Tên mã giảm giá")]
        public string Name { get; set; } = string.Empty;

        [Display(Name = "Phần trăm giảm")]
        public decimal Percent { get; set; }

        [Display(Name = "Ngày bắt đầu")]
        public DateTime DateStart { get; set; }

        [Display(Name = "Ngày kết thúc")]
        public DateTime DateEnd { get; set; }

        [Display(Name = "Giá trị đơn tối thiểu")]
        public decimal MinOfTotalPrice { get; set; }

        [Display(Name = "Giảm tối đa")]
        public decimal MaxOfDiscount { get; set; }

        [Display(Name = "Số lượng còn lại")]
        public int QuantityAvailable { get; set; }

        [Display(Name = "Mô tả")]
        public string? Description { get; set; }

        public ICollection<Bill> Bills { get; set; } = new List<Bill>();
    }
}
