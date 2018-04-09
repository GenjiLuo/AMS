namespace AMS.Model
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("RepairItemCode")]
    public partial class RepairItemCode
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public RepairItemCode()
        {
            CustomerPackageDetails = new HashSet<CustomerPackageDetail>();
            CustomerPackageManageDetailRecords = new HashSet<CustomerPackageManageDetailRecord>();
            CustomerPackageOrderDetails = new HashSet<CustomerPackageOrderDetail>();
            PackageDetails = new HashSet<PackageDetail>();
            ServiceBookingRepairItems = new HashSet<ServiceBookingRepairItem>();
            ServiceCarRepairItems = new HashSet<ServiceCarRepairItem>();
            ServiceCarRepairItemShams = new HashSet<ServiceCarRepairItemSham>();
        }

        public int Id { get; set; }

        [StringLength(2000)]
        public string Code { get; set; }

        [StringLength(2000)]
        public string Name { get; set; }

        [StringLength(2000)]
        public string ShortName { get; set; }

        public int? CreateBy { get; set; }

        public DateTime? CreateTime { get; set; }

        public int? ModifyBy { get; set; }

        public DateTime? ModifyTime { get; set; }

        public double? RefRepairHours { get; set; }

        public decimal? RefUnitPrice { get; set; }

        [StringLength(2000)]
        public string Remark { get; set; }

        public int? ParentId { get; set; }

        public int? RepairItemTypeId { get; set; }

        public decimal? PicCount { get; set; }

        public int? SprayPartId { get; set; }

        [StringLength(255)]
        public string BuildInMark { get; set; }

        public int? OrganizationId { get; set; }

        public bool IsEnable { get; set; }

        public bool? IsSysPublic { get; set; }

        public bool IsHot { get; set; }

        public virtual CarSprayPart CarSprayPart { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<CustomerPackageDetail> CustomerPackageDetails { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<CustomerPackageManageDetailRecord> CustomerPackageManageDetailRecords { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<CustomerPackageOrderDetail> CustomerPackageOrderDetails { get; set; }

        public virtual Organization Organization { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<PackageDetail> PackageDetails { get; set; }

        public virtual RepairItemType RepairItemType { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<ServiceBookingRepairItem> ServiceBookingRepairItems { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<ServiceCarRepairItem> ServiceCarRepairItems { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<ServiceCarRepairItemSham> ServiceCarRepairItemShams { get; set; }
    }
}
