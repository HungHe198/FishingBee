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
        public Guid Id { get; set; }
        public Guid UserId { get; set; }

        public Guid? CreatedBy { get; set; }
        public DateTime? CreatedTime { get; set; }
        public Guid? ModifiedBy { get; set; }
        public DateTime? ModifiedTime { get; set; }
        public string? Status { get; set; }
        public string FullName { get; set; } = string.Empty;
        public string IDCardNumber { get; set; } = string.Empty;
        public string? Address { get; set; }
        public DateTime? DoB { get; set; }
        public int LoyaltyPoints { get; set; }

        public ICollection<CustomerActivityLog>? CustomerActivityLogs { get; set; } = new List<CustomerActivityLog>();
        public ICollection<Cart>? Carts { get; set; } = new List<Cart>();
        public ICollection<Bill>? Bills { get; set; } = new List<Bill>();
        public ICollection<CustomerSupport>? CustomerSupports { get; set; } = new List<CustomerSupport>();
        public User? User { get; set; }
    }
}
