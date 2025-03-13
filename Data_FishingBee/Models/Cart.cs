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
        public Guid Id { get; set; }  // Primary Key

        [ForeignKey("Customer")]
        public Guid CustomerId { get; set; } // Foreign Key

        public Guid? CreatedBy { get; set; }
        public DateTime CreatedTime { get; set; }
        public DateTime LastUpdateTime { get; set; }
        public string Status { get; set; } = "Active"; // Mặc định là Active

        // Navigation Property
        public virtual Customer Customer { get; set; } = null!;
        public ICollection<Cart_PD>? Cart_PDs { get; set; } = new List<Cart_PD>();
    }
}
