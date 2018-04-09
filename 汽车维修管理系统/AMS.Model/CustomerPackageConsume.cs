namespace AMS.Model
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("CustomerPackageConsume")]
    public partial class CustomerPackageConsume
    {
        public int Id { get; set; }

        public int OrganizationId { get; set; }

        public int ServiceAccountId { get; set; }

        public int? CustomerId { get; set; }

        public int? CarId { get; set; }

        public int MemberPackageId { get; set; }

        public int MemberPackageDetailId { get; set; }

        public decimal UseCount { get; set; }

        public decimal RemainCount { get; set; }

        public decimal SalePrice { get; set; }

        public int CreateBy { get; set; }

        public DateTime CreateTime { get; set; }

        public int ModifyBy { get; set; }

        public DateTime ModifyTime { get; set; }

        public bool? IsSysPublic { get; set; }

        public int ConsumeType { get; set; }

        public bool IsConsume { get; set; }

        public int? RelatedConsumeId { get; set; }

        public decimal SettlePrice { get; set; }

        public decimal RoyaltyPrice { get; set; }

        public decimal PromotionPrice { get; set; }

        public virtual Car Car { get; set; }

        public virtual Customer Customer { get; set; }

        public virtual CustomerPackage CustomerPackage { get; set; }

        public virtual CustomerPackageDetail CustomerPackageDetail { get; set; }

        public virtual Organization Organization { get; set; }
    }
}
