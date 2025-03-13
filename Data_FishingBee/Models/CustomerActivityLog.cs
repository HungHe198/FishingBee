using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data_FishingBee.Models
{
    public class CustomerActivityLog
    {
        [Key]
        public int Id { get; set; }  // Primary Key

        [ForeignKey("Customer")]
        public int CustomerId { get; set; } // Foreign Key

        public DateTime Time { get; set; }
        public string ActivityType { get; set; } = string.Empty;
        public string? IPAddress { get; set; }
        public string? Location { get; set; }
        public bool IsAutoLogout { get; set; }
        public int SessionDuration { get; set; } // Thời gian phiên tính bằng giây

        // Navigation Property
        public virtual Customer Customer { get; set; } = null!;
    }
}
