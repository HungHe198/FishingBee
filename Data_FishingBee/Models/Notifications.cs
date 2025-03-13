using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data_FishingBee.Models
{
    public class Notifications
    {
        public Guid Id { get; set; }  // Khóa chính

        public Guid EmployeeId { get; set; }  // Khóa ngoại liên kết với Employee
        public string Title { get; set; } = string.Empty;
        public Guid? CreatedBy { get; set; }
        public DateTime? CreatedTime { get; set; }
        public Guid? ModifiedBy { get; set; }
        public DateTime? ModifiedTime { get; set; }
        public string? Status { get; set; }
        public string Content { get; set; } = string.Empty;
        public string? NotificationType { get; set; }

        public Guid? SenderId { get; set; }
        public Guid? ReceiverId { get; set; }

        public DateTime? ExpiredAt { get; set; }
        public int? Priority { get; set; }
        public string? AttachmentUrl { get; set; }

        // Navigation Property
        public Employee Employee { get; set; } = null!;
    }
}
