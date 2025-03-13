using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data_FishingBee.Models
{
    public class Customer
    {
        
        public int Id { get; set; }

       
        public int UserId { get; set; }

        public string? CreatedBy { get; set; }
        public DateTime? CreatedTime { get; set; }
        public string? ModifiedBy { get; set; }
        public DateTime? ModifiedTime { get; set; }
        public string? Status { get; set; }
        public string FullName { get; set; } = string.Empty;
        public string IDCardNumber { get; set; } = string.Empty;
        public string? Address { get; set; }
        public DateTime? DoB { get; set; }
        public int LoyaltyPoints { get; set; }
    }
}
