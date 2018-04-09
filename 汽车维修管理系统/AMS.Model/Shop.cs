namespace AMS.Model
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Shop")]
    public partial class Shop
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Shop()
        {
            FakePartsInventoryRequests = new HashSet<FakePartsInventoryRequest>();
            PartsUniqueSNs = new HashSet<PartsUniqueSN>();
            PeriodWarehouseBillings = new HashSet<PeriodWarehouseBilling>();
            PeriodWarehouseBillings1 = new HashSet<PeriodWarehouseBilling>();
            PeriodWarehouseBillings2 = new HashSet<PeriodWarehouseBilling>();
            ReportBusinessObjectives = new HashSet<ReportBusinessObjective>();
        }

        public int Id { get; set; }

        [StringLength(255)]
        public string Name { get; set; }

        public string Description { get; set; }

        public int? Area { get; set; }

        public int? WarehouseId { get; set; }

        [StringLength(255)]
        public string Address { get; set; }

        [StringLength(255)]
        public string Phone { get; set; }

        [StringLength(100)]
        public string OpeningBank { get; set; }

        [StringLength(50)]
        public string AccountNo { get; set; }

        [StringLength(255)]
        public string ShopCode { get; set; }

        public int? CreateBy { get; set; }

        public int? ModifyBy { get; set; }

        public DateTime? CreateTime { get; set; }

        public DateTime? ModifyTime { get; set; }

        [StringLength(50)]
        public string ShopLicenseNo { get; set; }

        public bool IsOpen { get; set; }

        public int OrganizationId { get; set; }

        [StringLength(255)]
        public string IdentityCode { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<FakePartsInventoryRequest> FakePartsInventoryRequests { get; set; }

        public virtual Organization Organization { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<PartsUniqueSN> PartsUniqueSNs { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<PeriodWarehouseBilling> PeriodWarehouseBillings { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<PeriodWarehouseBilling> PeriodWarehouseBillings1 { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<PeriodWarehouseBilling> PeriodWarehouseBillings2 { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<ReportBusinessObjective> ReportBusinessObjectives { get; set; }

        public virtual Warehouse Warehouse { get; set; }
    }
}
