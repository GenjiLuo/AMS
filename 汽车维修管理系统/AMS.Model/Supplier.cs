namespace AMS.Model
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Supplier")]
    public partial class Supplier
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Supplier()
        {
            PartsInventories = new HashSet<PartsInventory>();
            PartsInventoryChanges = new HashSet<PartsInventoryChange>();
            PartsInventoryRequests = new HashSet<PartsInventoryRequest>();
            PartsInventoryRequestDetails = new HashSet<PartsInventoryRequestDetail>();
            PeriodWarehouseBillings = new HashSet<PeriodWarehouseBilling>();
        }

        public int Id { get; set; }

        [StringLength(255)]
        public string Name { get; set; }

        [StringLength(255)]
        public string Code { get; set; }

        [StringLength(20)]
        public string Contactor { get; set; }

        [StringLength(255)]
        public string MobilePhone { get; set; }

        [StringLength(255)]
        public string Tel { get; set; }

        [StringLength(255)]
        public string Fax { get; set; }

        [StringLength(255)]
        public string BusinessField { get; set; }

        [StringLength(255)]
        public string BusinessAccount { get; set; }

        [StringLength(255)]
        public string Address { get; set; }

        [StringLength(50)]
        public string Gender { get; set; }

        [Column(TypeName = "date")]
        public DateTime? BirthDate { get; set; }

        [StringLength(255)]
        public string Email { get; set; }

        [StringLength(20)]
        public string QQ { get; set; }

        [StringLength(250)]
        public string WeChat { get; set; }

        public string Description { get; set; }

        [StringLength(255)]
        public string SupplierNameExtension { get; set; }

        public double? NeedPay { get; set; }

        [StringLength(255)]
        public string ShortName { get; set; }

        public int? CreateBy { get; set; }

        public DateTime? CreateTime { get; set; }

        public int? ModifyBy { get; set; }

        public DateTime? ModifyTime { get; set; }

        [StringLength(255)]
        public string AccountBank { get; set; }

        public int? MallSupplierId { get; set; }

        public bool? IsSysPublic { get; set; }

        public int? OrganizationId { get; set; }

        public int? SupplierLevelId { get; set; }

        [StringLength(255)]
        public string BuildInMark { get; set; }

        public virtual Organization Organization { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<PartsInventory> PartsInventories { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<PartsInventoryChange> PartsInventoryChanges { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<PartsInventoryRequest> PartsInventoryRequests { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<PartsInventoryRequestDetail> PartsInventoryRequestDetails { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<PeriodWarehouseBilling> PeriodWarehouseBillings { get; set; }

        public virtual SupplierLevel SupplierLevel { get; set; }
    }
}
