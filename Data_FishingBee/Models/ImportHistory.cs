using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data_FishingBee.Models
{
    public class ImportHistory
    {
       
        public Guid Id { get; set; }

        [ForeignKey("Inventory")]
        public Guid InventoryId { get; set; }

        [ForeignKey("Supplier")]
        public Guid SupplierId { get; set; }

        public Guid CreatedBy { get; set; }
        public DateTime CreatedTime { get; set; }
        public Guid ModifiedBy { get; set; }
        public DateTime? ModifiedTime { get; set; }
        public string Status { get; set; }
        public int Quantity { get; set; }
        public decimal UnitPrice { get; set; }
        public string UnitName { get; set; }

        public Inventory? Inventory { get; set; }
        public Supplier? Supplier { get; set; }
    }
}
