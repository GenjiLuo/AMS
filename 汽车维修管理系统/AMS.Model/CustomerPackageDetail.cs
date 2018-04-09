namespace AMS.Model
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("CustomerPackageDetail")]
    public partial class CustomerPackageDetail
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public CustomerPackageDetail()
        {
            CustomerPackageConsumes = new HashSet<CustomerPackageConsume>();
        }

        public int Id { get; set; }

        public int MemberPackageId { get; set; }

        public int Type { get; set; }

        public decimal Count { get; set; }

        public decimal UseCount { get; set; }

        public decimal RemainCount { get; set; }

        public decimal SalePrice { get; set; }

        [StringLength(255)]
        public string Remark { get; set; }

        public bool Deleted { get; set; }

        public int? CreateBy { get; set; }

        public DateTime CreateTime { get; set; }

        public int? ModifyBy { get; set; }

        public DateTime ModifyTime { get; set; }

        public int? PartsDictionaryId { get; set; }

        public int? RepairItemCodeId { get; set; }

        public decimal SettlePrice { get; set; }

        public decimal RoyaltyPrice { get; set; }

        public decimal PromotionPrice { get; set; }

        public virtual CustomerPackage CustomerPackage { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<CustomerPackageConsume> CustomerPackageConsumes { get; set; }

        public virtual PartsDictionary PartsDictionary { get; set; }

        public virtual RepairItemCode RepairItemCode { get; set; }
    }
}
