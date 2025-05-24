using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Data_FishingBee.Models
{
    public class Inventory
    {
        [Display(Name = "Mã kho")]
        public Guid Id { get; set; }

        [Display(Name = "Mã chi tiết sản phẩm")]
        public Guid ProductDetailId { get; set; }

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

        [Display(Name = "Tồn kho")]
        public int Stock { get; set; }

        [Display(Name = "Danh sách kho liên quan")]
        public ICollection<Inventory>? Inventories { get; set; } = new List<Inventory>();

        [Display(Name = "Chi tiết sản phẩm")]
        public ProductDetail? ProductDetail { get; set; }
    }
}
