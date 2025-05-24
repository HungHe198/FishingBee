using System;
using System.ComponentModel.DataAnnotations;

namespace Data_FishingBee.Models
{
    public class CartItemViewModel
    {
        [Display(Name = "Mã mục giỏ hàng")]
        public Guid Id { get; set; }

        [Display(Name = "Tên sản phẩm")]
        public string ProductName { get; set; }

        [Display(Name = "Thông tin chi tiết")]
        public string ProductDetail { get; set; }

        [Display(Name = "Hình ảnh")]
        public string ImageUrl { get; set; }

        [Display(Name = "Đơn giá")]
        public decimal Price { get; set; }

        [Display(Name = "Số lượng")]
        public int Quantity { get; set; }
    }
}
