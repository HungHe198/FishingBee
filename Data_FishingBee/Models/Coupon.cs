using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data_FishingBee.Models
{
    public class Coupon
    {
        public int Id { get; set; }  // Khóa chính

        public string? CreatedBy { get; set; }
        public DateTime? CreatedTime { get; set; }
        public string? ModifiedBy { get; set; }
        public DateTime? ModifiedTime { get; set; }
        public string? Status { get; set; }

        public string Name { get; set; } = string.Empty;
        public decimal Percent { get; set; }

        public DateTime DateStart { get; set; }
        public DateTime DateEnd { get; set; }

        public decimal MinOfTotalPrice { get; set; }
        public decimal MaxOfDiscount { get; set; }

        public int QuantityAvailable { get; set; }

        public string? Description { get; set; }
        public Bill? Bill { get; set; }
    }
}
