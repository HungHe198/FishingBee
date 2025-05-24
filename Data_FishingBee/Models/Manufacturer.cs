using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Data_FishingBee.Models
{
    public class Manufacturer
    {
        [Display(Name = "Mã nhà sản xuất")]
        public Guid Id { get; set; }

        [Display(Name = "Tên nhà sản xuất")]
        public string Name { get; set; }

        [Display(Name = "Người tạo")]
        public Guid? CreatedBy { get; set; }

        [Display(Name = "Thời gian tạo")]
        public DateTime? CreatedTime { get; set; }

        [Display(Name = "Trạng thái")]
        public string Status { get; set; }

        [Display(Name = "Mô tả")]
        public string? Description { get; set; }

        [Display(Name = "Đường dẫn hình ảnh")]
        public string? ImageUrl { get; set; }

        [Display(Name = "Danh sách sản phẩm")]
        public ICollection<Product>? Products { get; set; } = new List<Product>();
    }
}
