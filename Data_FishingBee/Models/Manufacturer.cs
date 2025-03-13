using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data_FishingBee.Models
{
    public class Manufacturer
    {
        public Guid Id { get; set; }
        public string Name { get; set; }

        public Guid? CreatedBy { get; set; }
        public DateTime? CreatedTime { get; set; }
        public string Status { get; set; }
        public string? Description { get; set; }
        public ICollection<Product>? Products { get; set; } = new List<Product>();
    }
}
