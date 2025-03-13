using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data_FishingBee.Models
{
    public class Supplier
    {
        public int Id { get; set; }  // Khóa chính

        public string? CreatedBy { get; set; }
        public DateTime? CreatedTime { get; set; }
        public string? ModifiedBy { get; set; }
        public DateTime? ModifiedTime { get; set; }
        public string? Status { get; set; }

        public string SupplierName { get; set; } = string.Empty;
        public string? ContactName { get; set; }
        public string? Address { get; set; }
        public string? City { get; set; }
        public string? Country { get; set; }

        public string? PhoneNumber { get; set; }
        public string? Email { get; set; }
        public string? Website { get; set; }

        public string? Notes { get; set; }

        public ImportHistory? ImportHistory { get; set; }
    }
}
