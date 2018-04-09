namespace AMS.Model
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("CustomerPackage")]
    public partial class CustomerPackage
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public CustomerPackage()
        {
            CustomerPackageUseOrgs = new HashSet<CustomerPackageUseOrg>();
            CustomerPackageConsumes = new HashSet<CustomerPackageConsume>();
            CustomerPackageDetails = new HashSet<CustomerPackageDetail>();
            CustomerPackageManageRecords = new HashSet<CustomerPackageManageRecord>();
        }

        public int Id { get; set; }

        public int CustomerId { get; set; }

        public int? CarId { get; set; }

        public int PackageId { get; set; }

        [Required]
        [StringLength(255)]
        public string BillNo { get; set; }

        public DateTime ValidStartDate { get; set; }

        public DateTime ValidEndDate { get; set; }

        public decimal Count { get; set; }

        public decimal SalePrice { get; set; }

        public decimal ShouldPayMoney { get; set; }

        public decimal ActualPayMoney { get; set; }

        [StringLength(4000)]
        public string Remark { get; set; }

        public int? MemberConsumeId { get; set; }

        public int? FinanceBusinessRecordId { get; set; }

        public bool Deleted { get; set; }

        public int? CreateBy { get; set; }

        public DateTime CreateTime { get; set; }

        public int? ModifyBy { get; set; }

        public DateTime ModifyTime { get; set; }

        public bool? IsSysPublic { get; set; }

        public int? OrganizationId { get; set; }

        [StringLength(255)]
        public string ConsumeCode { get; set; }

        public bool IsShare { get; set; }

        public bool IsCurrency { get; set; }

        public virtual Car Car { get; set; }

        public virtual Customer Customer { get; set; }

        public virtual Organization Organization { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<CustomerPackageUseOrg> CustomerPackageUseOrgs { get; set; }

        public virtual User User { get; set; }

        public virtual FinanceBusinessRecord FinanceBusinessRecord { get; set; }

        public virtual MemberCardConsume MemberCardConsume { get; set; }

        public virtual Organization Organization1 { get; set; }

        public virtual Package Package { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<CustomerPackageConsume> CustomerPackageConsumes { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<CustomerPackageDetail> CustomerPackageDetails { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<CustomerPackageManageRecord> CustomerPackageManageRecords { get; set; }
    }
}
