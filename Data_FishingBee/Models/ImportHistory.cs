using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Data_FishingBee.Models
{
    public class ImportHistory
    {
        [Display(Name = "Mã phiếu nhập")]
        public Guid Id { get; set; }

        [ForeignKey("Inventory")]
        [Display(Name = "Kho hàng")]
        public Guid InventoryId { get; set; }

        [ForeignKey("Supplier")]
        [Display(Name = "Nhà cung cấp")]
        public Guid SupplierId { get; set; }

        [Display(Name = "Người tạo")]
        public Guid CreatedBy { get; set; }

        [Display(Name = "Thời gian tạo")]
        public DateTime CreatedTime { get; set; }

        [Display(Name = "Người sửa")]
        public Guid ModifiedBy { get; set; }

        [Display(Name = "Thời gian sửa")]
        public DateTime? ModifiedTime { get; set; }

        [Display(Name = "Trạng thái")]
        public string Status { get; set; }

        [Display(Name = "Số lượng")]
        public int Quantity { get; set; }

        [Display(Name = "Đơn giá")]
        public decimal UnitPrice { get; set; }

        [Display(Name = "Đơn vị tính của biến thể")]
        public string UnitName { get; set; }

        [Display(Name = "Kho hàng")]
        public Inventory? Inventory { get; set; }

        [Display(Name = "Nhà cung cấp")]
        public Supplier? Supplier { get; set; }
    }
}
