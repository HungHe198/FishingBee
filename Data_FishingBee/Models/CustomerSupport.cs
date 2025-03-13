using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data_FishingBee.Models
{
    public class CustomerSupport
    {
        public Guid Id { get; set; }  // Khóa chính

        public Guid AdminId { get; set; } // FK đến Admin
        public Guid CustomerId { get; set; } // FK đến Customer

        public Guid? CreatedBy { get; set; }
        public DateTime? CreatedTime { get; set; }
        public Guid? ModifiedBy { get; set; }
        public DateTime? ModifiedTime { get; set; }
        public string? Status { get; set; }

        public string Subject { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public string? Resolution { get; set; }
        public DateTime? ResolvedAt { get; set; }

        public string? CustomerFeedback { get; set; }
        public int? RatingForSupport { get; set; } // Đánh giá hỗ trợ, có thể null

        // Navigation Properties
        public Admin Admin { get; set; } = null!;
        public Customer Customer { get; set; } = null!;
    }
}
