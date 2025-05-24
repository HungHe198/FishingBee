using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations; // Thêm namespace này
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data_FishingBee.Models
{
    public class Product
    {
        [Display(Name = "Mã sản phẩm")]
        public Guid Id { get; set; }

        [Display(Name = "Mã danh mục")]
        public Guid CategoryId { get; set; }

        [Display(Name = "Mã nhà sản xuất")]
        public Guid ManufacturerId { get; set; }

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

        [Display(Name = "Tên sản phẩm")]
        public string? Name { get; set; }

        [Display(Name = "Tên thuộc tính")]
        public string? AttributeName { get; set; }

        [Display(Name = "Đơn vị thuộc tính")]
        public string? AttributeUnit { get; set; }

        [Display(Name = "Chi tiết sản phẩm")]
        public ICollection<ProductDetail>? ProductDetails { get; set; } = new List<ProductDetail>();

        [Display(Name = "Hình ảnh sản phẩm")]
        public ICollection<ProductImage>? ProductImages { get; set; } = new List<ProductImage>();

        [Display(Name = "Danh mục")]
        public Category? Category { get; set; }

        [Display(Name = "Nhà sản xuất")]
        public Manufacturer? Manufacturer { get; set; }
    }
}