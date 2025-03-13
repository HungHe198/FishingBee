using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data_FishingBee.Models
{
    public class Employee
    {
        public int Id { get; set; }  // Khóa chính
        public int UserId { get; set; }  // Khóa ngoại tham chiếu User.Id

        public string? CreatedBy { get; set; }
        public DateTime? CreatedTime { get; set; }
        public string? ModifiedBy { get; set; }
        public DateTime? ModifiedTime { get; set; }
        public string? Status { get; set; }

        public string Code { get; set; } = string.Empty;
        public string Fullname { get; set; } = string.Empty;
        public string Position { get; set; } = string.Empty;
        public decimal Salary { get; set; }
        public DateTime? HireDate { get; set; }
        public string? IDCardNumber { get; set; }

        // Navigation Property
        public User User { get; set; } = null!;
        public Notifications Notifications { get; set; } = null!;
        public Bill Bill { get; set; } = null!;

    }
}
