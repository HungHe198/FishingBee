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
        public int Id { get; set; }  // Primary Key

        [ForeignKey("ProductDetail")]
        public int ProductDetailId { get; set; } // Foreign Key đến ProductDetail

        [ForeignKey("Cart")]
        public int CartId { get; set; } // Foreign Key đến Cart

        // Navigation Properties
        public virtual ProductDetail ProductDetail { get; set; } = null!;
        public virtual Cart Cart { get; set; } = null!;
    }
}
