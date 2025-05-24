using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data_FishingBee.Models
{
    public class Cart_PD
    {
        [Key]
        [Display(Name = "Mã mục giỏ hàng")]
        public Guid Id { get; set; }  // Primary Key

        [ForeignKey("ProductDetail")]
        [Display(Name = "Mã chi tiết sản phẩm")]
        public Guid ProductDetailId { get; set; } // Foreign Key đến ProductDetail

        [ForeignKey("Cart")]
        [Display(Name = "Mã giỏ hàng")]
        public Guid CartId { get; set; } // Foreign Key đến Cart

        [Display(Name = "Số lượng")]
        public int Quantity { get; set; }

        // Navigation Properties
        [Display(Name = "Chi tiết sản phẩm")]
        public virtual ProductDetail ProductDetail { get; set; } = null!;

        [Display(Name = "Giỏ hàng")]
        public virtual Cart Cart { get; set; } = null!;

        [Display(Name = "Trạng thái")]
        public int Status { get; set; }
    }
}
