namespace AMS.Model
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("CustomerPackageManageDetailRecord")]
    public partial class CustomerPackageManageDetailRecord
    {
        public int Id { get; set; }

        public int MemberPackageManageRecordId { get; set; }

        public int Type { get; set; }

        public decimal Count { get; set; }

        public decimal UseCount { get; set; }

        public decimal RemainCount { get; set; }

        public decimal SalePrice { get; set; }

        [StringLength(250)]
        public string Remark { get; set; }

        public int? PartsDictionaryId { get; set; }

        public int? RepairItemCodeId { get; set; }

        public int? CreateBy { get; set; }

        public DateTime? CreateTime { get; set; }

        public int? ModifyBy { get; set; }

        public DateTime? ModifyTime { get; set; }

        public decimal SettlePrice { get; set; }

        public decimal RoyaltyPrice { get; set; }

        public decimal PromotionPrice { get; set; }

        public virtual CustomerPackageManageRecord CustomerPackageManageRecord { get; set; }

        public virtual PartsDictionary PartsDictionary { get; set; }

        public virtual RepairItemCode RepairItemCode { get; set; }
    }
}
