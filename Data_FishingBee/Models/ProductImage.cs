using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations; // Thêm namespace này
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data_FishingBee.Models
{
    public class ProductImage
    {
        [Display(Name = "Mã hình ảnh")]
        public Guid Id { get; set; }

        [Display(Name = "Mã sản phẩm")]
        public Guid ProductId { get; set; }

        [Display(Name = "Đường dẫn hình ảnh")]
        public string ImageUrl { get; set; } // Đường dẫn của từng ảnh

        [Display(Name = "Sản phẩm")]
        public virtual Product Product { get; set; }
    }
}