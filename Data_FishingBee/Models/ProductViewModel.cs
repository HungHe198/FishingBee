using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations; // Thêm namespace này
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data_FishingBee.Models
{
    public class ProductViewModel
    {
        [Display(Name = "Mã sản phẩm")]
        public Guid Id { get; set; }

        [Display(Name = "Tên sản phẩm")]
        public string Name { get; set; } = string.Empty;

        [Display(Name = "Đường dẫn hình ảnh")]
        public string ImageUrl { get; set; } = string.Empty;

        [Display(Name = "Giá tối thiểu")]
        public decimal MinPrice { get; set; }
    }
}