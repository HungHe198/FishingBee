using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data_FishingBee.Models
{
    public class Admin
    {
        public Guid Id { get; set; }  // Khóa chính riêng của Admin
        public Guid UserId { get; set; }  // Khóa ngoại tham chiếu đến User.Id

        public string? FullName { get; set; }
        public string? Permissions { get; set; }
        public string? Status { get; set; }
        public string? Descriptions { get; set; }

        public DateTime? CreatedTime { get; set; }
        public Guid? CreatedBy { get; set; }
        public DateTime? ModifiedTime { get; set; }
        public Guid? ModifiedBy { get; set; }

        // Navigation Property
        public User? User { get; set; } = null!;
        public ICollection<CustomerSupport>? CustomerSupports { get; set; }
        public ICollection<Bill>? Bills { get; set; }

    }
}
