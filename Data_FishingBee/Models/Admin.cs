using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data_FishingBee.Models
{
    public class Admin
    {
        public int Id { get; set; }  // Khóa chính riêng của Admin
        public int UserId { get; set; }  // Khóa ngoại tham chiếu đến User.Id

        public string? FullName { get; set; }
        public string? Permissions { get; set; }
        public string? Status { get; set; }
        public string? Descriptions { get; set; }

        public DateTime? CreatedTime { get; set; }
        public string? CreatedBy { get; set; }
        public DateTime? ModifiedTime { get; set; }
        public string? ModifiedBy { get; set; }

        // Navigation Property
        public User User { get; set; } = null!;
        public CustomerSupport? CustomerSupport { get; set; }
        public Bill? Bill { get; set; }

    }
}
