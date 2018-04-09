namespace AMS.Model
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Package")]
    public partial class Package
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Package()
        {
            CustomerPackages = new HashSet<CustomerPackage>();
            CustomerPackageManageRecords = new HashSet<CustomerPackageManageRecord>();
            CustomerPackageOrders = new HashSet<CustomerPackageOrder>();
            FilesPackages = new HashSet<FilesPackage>();
            PackageDetails = new HashSet<PackageDetail>();
            PackageUseOrgs = new HashSet<PackageUseOrg>();
        }

        public int Id { get; set; }

        [Required]
        [StringLength(255)]
        public string Code { get; set; }

        [Required]
        [StringLength(255)]
        public string Name { get; set; }

        public int Status { get; set; }

        public decimal ActualPrice { get; set; }

        public decimal? DiscountPrice { get; set; }

        public decimal SalePrice { get; set; }

        [StringLength(255)]
        public string Remark { get; set; }

        public bool Deleted { get; set; }

        public int CreateBy { get; set; }

        public DateTime CreateTime { get; set; }

        public int ModifyBy { get; set; }

        public DateTime ModifyTime { get; set; }

        public bool? IsSysPublic { get; set; }

        public int? OrganizationId { get; set; }

        public bool IsShare { get; set; }

        public int PromotionStatus { get; set; }

        public DateTime? OnSaleDateTime { get; set; }

        public DateTime? OffSaleDateTime { get; set; }

        [StringLength(255)]
        public string SaleOffRemark { get; set; }

        public int? InitialQuantity { get; set; }

        [StringLength(255)]
        public string Ellipsis { get; set; }

        [StringLength(255)]
        public string PackageSummary { get; set; }

        [StringLength(4000)]
        public string PurchaseNotes { get; set; }

        public bool IsCurrency { get; set; }

        public bool IsLimitPurchase { get; set; }

        public int LimitPurchaseQuantity { get; set; }

        [StringLength(255)]
        public string Highlights { get; set; }

        [StringLength(255)]
        public string SecondHighlights { get; set; }

        [StringLength(255)]
        public string Describe { get; set; }

        public decimal? Cardinality { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<CustomerPackage> CustomerPackages { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<CustomerPackageManageRecord> CustomerPackageManageRecords { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<CustomerPackageOrder> CustomerPackageOrders { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<FilesPackage> FilesPackages { get; set; }

        public virtual Organization Organization { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<PackageDetail> PackageDetails { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<PackageUseOrg> PackageUseOrgs { get; set; }
    }
}
