namespace AMS.Model
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("CustomerPackageManageRecord")]
    public partial class CustomerPackageManageRecord
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public CustomerPackageManageRecord()
        {
            CustomerPackageManageDetailRecords = new HashSet<CustomerPackageManageDetailRecord>();
        }

        public int Id { get; set; }

        public int? CarId { get; set; }

        public int PackageId { get; set; }

        public DateTime ValidStartDate { get; set; }

        public DateTime ValidEndDate { get; set; }

        public decimal Count { get; set; }

        public decimal SalePrice { get; set; }

        public decimal ShouldPayMoney { get; set; }

        public decimal ActualPayMoney { get; set; }

        [StringLength(250)]
        public string Remark { get; set; }

        public int? CreateBy { get; set; }

        public DateTime? CreateTime { get; set; }

        public int? ModifyBy { get; set; }

        public DateTime? ModifyTime { get; set; }

        public bool? IsSysPublic { get; set; }

        public int? OrganizationId { get; set; }

        public int MemberPackgeHandleType { get; set; }

        public bool IsIncrease { get; set; }

        public int MemberPackageId { get; set; }

        public int CustomerId { get; set; }

        public bool IsShare { get; set; }

        public virtual Car Car { get; set; }

        public virtual Customer Customer { get; set; }

        public virtual CustomerPackage CustomerPackage { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<CustomerPackageManageDetailRecord> CustomerPackageManageDetailRecords { get; set; }

        public virtual Organization Organization { get; set; }

        public virtual Organization Organization1 { get; set; }

        public virtual Package Package { get; set; }
    }
}
