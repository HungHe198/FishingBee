using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data_FishingBee.Models
{
    public class Cart
    {
        [Key]
        [Display(Name = "Mã giỏ hàng")]
        public Guid Id { get; set; }  // Primary Key

        [ForeignKey("Customer")]
        [Display(Name = "Mã khách hàng")]
        public Guid CustomerId { get; set; } // Foreign Key

        [Display(Name = "Người tạo")]
        public Guid? CreatedBy { get; set; }

        [Display(Name = "Thời gian tạo")]
        public DateTime CreatedTime { get; set; }

        [Display(Name = "Thời gian cập nhật cuối")]
        public DateTime LastUpdateTime { get; set; }

        [Display(Name = "Trạng thái")]
        public string Status { get; set; } = "Active"; // Mặc định là Active

        // Navigation Property
        [Display(Name = "Khách hàng")]
        public virtual Customer Customer { get; set; } = null!;

        [Display(Name = "Danh sách sản phẩm trong giỏ")]
        public ICollection<Cart_PD>? Cart_PDs { get; set; } = new List<Cart_PD>();
    }
}
