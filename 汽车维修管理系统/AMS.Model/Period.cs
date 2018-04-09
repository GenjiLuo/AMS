namespace AMS.Model
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Period")]
    public partial class Period
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Period()
        {
            PartsInventoryChanges = new HashSet<PartsInventoryChange>();
            PartsInventoryRequests = new HashSet<PartsInventoryRequest>();
            PartsInventoryRequestDetails = new HashSet<PartsInventoryRequestDetail>();
            PartsPaymentHistories = new HashSet<PartsPaymentHistory>();
            PeriodInventoryHistories = new HashSet<PeriodInventoryHistory>();
            PeriodWarehouseBillings = new HashSet<PeriodWarehouseBilling>();
        }

        public int Id { get; set; }

        [StringLength(20)]
        public string Name { get; set; }

        public DateTime? StartDate { get; set; }

        public DateTime? EndDate { get; set; }

        public int? ShopId { get; set; }

        public double? StartStorage { get; set; }

        public double? EndStorage { get; set; }

        public int? WarehouseId { get; set; }

        public int? CreateBy { get; set; }

        public DateTime? CreateTime { get; set; }

        public int? ModifyBy { get; set; }

        public DateTime? ModifyTime { get; set; }

        public int? PreviousId { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<PartsInventoryChange> PartsInventoryChanges { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<PartsInventoryRequest> PartsInventoryRequests { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<PartsInventoryRequestDetail> PartsInventoryRequestDetails { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<PartsPaymentHistory> PartsPaymentHistories { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<PeriodInventoryHistory> PeriodInventoryHistories { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<PeriodWarehouseBilling> PeriodWarehouseBillings { get; set; }
    }
}
