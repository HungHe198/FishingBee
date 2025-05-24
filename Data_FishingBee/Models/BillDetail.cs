using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data_FishingBee.Models
{
    public class BillDetail
    {
        [Display(Name = "Mã chi tiết đơn hàng")]
        public Guid Id { get; set; }  // Khóa chính

        [Display(Name = "Mã đơn hàng")]
        public Guid BillId { get; set; } // FK đến Bill

        [Display(Name = "Mã chi tiết sản phẩm")]
        public Guid ProductDetailId { get; set; } // FK đến ProductDetail

        [Display(Name = "Người tạo")]
        public Guid? CreatedBy { get; set; }

        [Display(Name = "Thời gian tạo")]
        public DateTime? CreatedTime { get; set; }

        [Display(Name = "Người sửa")]
        public Guid? ModifiedBy { get; set; }

        [Display(Name = "Thời gian sửa")]
        public DateTime? ModifiedTime { get; set; }

        [Display(Name = "Đơn giá")]
        public decimal UnitPrice { get; set; }

        [Display(Name = "Số lượng")]
        public int Amount { get; set; }

        // Navigation Properties
        public Bill Bill { get; set; } = null!;

        public ProductDetail? ProductDetail { get; set; } = null!;
    }
}
