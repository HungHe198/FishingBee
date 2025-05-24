using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Data_FishingBee.Models
{
    public class CustomerActivityLog
    {
        [Key]
        public Guid Id { get; set; }  // Primary Key

        [ForeignKey("Customer")]
        [Display(Name = "Khách hàng")]
        public Guid CustomerId { get; set; } // Foreign Key

        [Display(Name = "Thời gian")]
        public DateTime Time { get; set; }

        [Display(Name = "Loại hoạt động")]
        public string ActivityType { get; set; } = string.Empty;

        [Display(Name = "Địa chỉ IP")]
        public string? IPAddress { get; set; }

        [Display(Name = "Vị trí")]
        public string? Location { get; set; }

        [Display(Name = "Tự động đăng xuất")]
        public bool IsAutoLogout { get; set; }

        [Display(Name = "Thời lượng phiên (giây)")]
        public int SessionDuration { get; set; } // Thời gian phiên tính bằng giây

        // Navigation Property
        public virtual Customer Customer { get; set; } = null!;
    }
}
