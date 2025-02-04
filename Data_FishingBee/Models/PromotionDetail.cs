﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data_FishingBee.Models
{
    public class PromotionDetail
    {
        public Guid Id { get; set; }
        public string PromotionType { get; set; } // lấy từ bảng promotion
        public int PromotionValue { get; set; }
        public decimal MinPrice { get; set; }
        public decimal MaxDiscountValue { get; set; }
        public DateTime DateStart { get; set; }
        public DateTime DateEnd { get; set; }
        public string? Description { get; set; }
        public Guid PromotionId { get; set; }
        public Promotion? Promotion { get; set; }
        public Guid? CreatedBy { get; set; }
        public DateTime? CreatedTime { get; set; }
        public bool? IsDeleted { get; set; }
        public Guid? DeletedBy { get; set; }
        public DateTime? DeletedTime { get; set; }
        public Guid? ModifiedBy { get; set; }
        public DateTime? ModifiedTime { get; set; }
    }
}
