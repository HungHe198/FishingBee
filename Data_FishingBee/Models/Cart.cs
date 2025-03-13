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
        public int Id { get; set; }  // Primary Key

        [ForeignKey("Customer")]
        public int CustomerId { get; set; } // Foreign Key

        public string? CreatedBy { get; set; }
        public DateTime CreatedTime { get; set; }
        public DateTime LastUpdateTime { get; set; }
        public string Status { get; set; } = "Active"; // Mặc định là Active

        // Navigation Property
        public virtual Customer Customer { get; set; } = null!;
    }
}
