namespace AMS.Model
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("PartsDictionary")]
    public partial class PartsDictionary
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public PartsDictionary()
        {
            CustomerPackageDetails = new HashSet<CustomerPackageDetail>();
            CustomerPackageManageDetailRecords = new HashSet<CustomerPackageManageDetailRecord>();
            CustomerPackageOrderDetails = new HashSet<CustomerPackageOrderDetail>();
            FakePartsInventoryRequestDetails = new HashSet<FakePartsInventoryRequestDetail>();
            PackageDetails = new HashSet<PackageDetail>();
            PartsUniqueSNs = new HashSet<PartsUniqueSN>();
            PartsDictionaryCarTypes = new HashSet<PartsDictionaryCarType>();
            PartsInventories = new HashSet<PartsInventory>();
            PartsInventoryChanges = new HashSet<PartsInventoryChange>();
            PartsInventoryRequestDetails = new HashSet<PartsInventoryRequestDetail>();
            PartsInventoryWarnings = new HashSet<PartsInventoryWarning>();
            PartsPriceChangeDetails = new HashSet<PartsPriceChangeDetail>();
            PeriodInventoryHistories = new HashSet<PeriodInventoryHistory>();
            WarehouseZones = new HashSet<WarehouseZone>();
        }

        public int Id { get; set; }

        [Required]
        [StringLength(255)]
        public string SerialNo { get; set; }

        [Required]
        [StringLength(255)]
        public string Name { get; set; }

        [StringLength(255)]
        public string ShortName { get; set; }

        [StringLength(255)]
        public string Brand { get; set; }

        [StringLength(255)]
        public string Model { get; set; }

        [StringLength(255)]
        public string Unit { get; set; }

        [StringLength(255)]
        public string OriginalPlace { get; set; }

        public double SupplierPrice { get; set; }

        public double? WholesalePrice { get; set; }

        public double SalePrice { get; set; }

        public double? TransferPrice { get; set; }

        public double? SettlementPrice { get; set; }

        public double? LimitedPrice { get; set; }

        [StringLength(255)]
        public string Comment { get; set; }

        public int? PartsTypeId { get; set; }

        public int? PartsTagId1 { get; set; }

        public int? PartsTagId2 { get; set; }

        public int? CreateBy { get; set; }

        public DateTime? CreateTime { get; set; }

        public int? ModifyBy { get; set; }

        public DateTime? ModifyTime { get; set; }

        public bool UseUniqueSN { get; set; }

        public decimal? Pricerange { get; set; }

        public bool? IsSysPublic { get; set; }

        public int? OrganizationId { get; set; }

        public decimal? ClaimPrice { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<CustomerPackageDetail> CustomerPackageDetails { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<CustomerPackageManageDetailRecord> CustomerPackageManageDetailRecords { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<CustomerPackageOrderDetail> CustomerPackageOrderDetails { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<FakePartsInventoryRequestDetail> FakePartsInventoryRequestDetails { get; set; }

        public virtual Organization Organization { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<PackageDetail> PackageDetails { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<PartsUniqueSN> PartsUniqueSNs { get; set; }

        public virtual PartsTag PartsTag { get; set; }

        public virtual PartsTag PartsTag1 { get; set; }

        public virtual PartsType PartsType { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<PartsDictionaryCarType> PartsDictionaryCarTypes { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<PartsInventory> PartsInventories { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<PartsInventoryChange> PartsInventoryChanges { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<PartsInventoryRequestDetail> PartsInventoryRequestDetails { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<PartsInventoryWarning> PartsInventoryWarnings { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<PartsPriceChangeDetail> PartsPriceChangeDetails { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<PeriodInventoryHistory> PeriodInventoryHistories { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<WarehouseZone> WarehouseZones { get; set; }
    }
}
