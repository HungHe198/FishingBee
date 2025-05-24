using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations; // Thêm namespace này
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data_FishingBee.Models
{
    public class ProductDetail
    {
        [Display(Name = "Mã chi tiết sản phẩm")]
        public Guid Id { get; set; }  // Khóa chính

        [Display(Name = "Mã sản phẩm")]
        public Guid ProductId { get; set; } // FK đến Product

        [Display(Name = "Người tạo")]
        public Guid? CreatedBy { get; set; }

        [Display(Name = "Thời gian tạo")]
        public DateTime? CreatedTime { get; set; }

        [Display(Name = "Người sửa đổi")]
        public Guid? ModifiedBy { get; set; }

        [Display(Name = "Thời gian sửa đổi")]
        public DateTime? ModifiedTime { get; set; }

        [Display(Name = "Trạng thái")]
        public string? Status { get; set; }

        [Display(Name = "Mô tả")]
        public string? Description { get; set; }

        [Display(Name = "Giá trị thuộc tính")]
        public string? AttributeValue { get; set; }

        [Display(Name = "Giá")]
        public decimal Price { get; set; }

        [Display(Name = "Tồn kho")]
        public decimal Stock { get; set; }

        // Navigation Property
        [Display(Name = "Chi tiết hóa đơn")]
        public ICollection<BillDetail>? BillDetails { get; set; } = new List<BillDetail>();

        [Display(Name = "Giỏ hàng - Chi tiết sản phẩm")]
        public ICollection<Cart_PD>? Cart_PDs { get; set; } = new List<Cart_PD>();

        [Display(Name = "Sản phẩm")]
        public Product Product { get; set; } = null!;

        [Display(Name = "Kho hàng")]
        public Inventory Inventory { get; set; } = null!;
    }
}