using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data_FishingBee.Models
{
    public class User
    {
        public int Id { get; set; }  // Khóa chính

        public string? CreatedBy { get; set; }
        public DateTime? CreatedTime { get; set; }
        public string? ModifiedBy { get; set; }
        public DateTime? ModifiedTime { get; set; }
        public string? Status { get; set; }

        public string Username { get; set; } = string.Empty;
        public string Password { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public string? PhoneNumber { get; set; }
        public string? UserType { get; set; }

        // Navigation property để liên kết với Admin (nếu có)
        public Admin? Admin { get; set; }
        public Customer? Customer { get; set; }
        public Employee? Employee { get; set; }
    }
}
