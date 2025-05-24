using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Data_FishingBee.Models
{
    public class Category
    {
        public Guid Id { get; set; }

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

        [Display(Name = "Tên danh mục")]
        public string Name { get; set; } = string.Empty;

        [Display(Name = "Mô tả")]
        public string? Description { get; set; }

        [Display(Name = "Đơn giá")]
        public decimal Price { get; set; } // Giả sử bạn đã thêm field này

        public ICollection<Product> Products { get; set; } = new List<Product>();
    }
}
