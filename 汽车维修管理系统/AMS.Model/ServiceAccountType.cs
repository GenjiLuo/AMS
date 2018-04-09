namespace AMS.Model
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("ServiceAccountType")]
    public partial class ServiceAccountType
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public ServiceAccountType()
        {
            FakePartsInventoryRequestDetails = new HashSet<FakePartsInventoryRequestDetail>();
            PartsInventoryRequestDetails = new HashSet<PartsInventoryRequestDetail>();
            ServiceBookingRepairItems = new HashSet<ServiceBookingRepairItem>();
            ServiceCarRepairItems = new HashSet<ServiceCarRepairItem>();
            ServiceCarRepairItemShams = new HashSet<ServiceCarRepairItemSham>();
            ServiceOtherCharges = new HashSet<ServiceOtherCharge>();
            ServiceOtherChargeShams = new HashSet<ServiceOtherChargeSham>();
        }

        public int Id { get; set; }

        [StringLength(20)]
        public string Name { get; set; }

        [StringLength(20)]
        public string ShortName { get; set; }

        [StringLength(200)]
        public string Remark { get; set; }

        public int? CreateBy { get; set; }

        public DateTime? CreateTime { get; set; }

        public int? ModifyBy { get; set; }

        public DateTime? ModifyTime { get; set; }

        public bool IsDefault { get; set; }

        public int? OrganizationId { get; set; }

        public bool IsSysPublic { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<FakePartsInventoryRequestDetail> FakePartsInventoryRequestDetails { get; set; }

        public virtual Organization Organization { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<PartsInventoryRequestDetail> PartsInventoryRequestDetails { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<ServiceBookingRepairItem> ServiceBookingRepairItems { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<ServiceCarRepairItem> ServiceCarRepairItems { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<ServiceCarRepairItemSham> ServiceCarRepairItemShams { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<ServiceOtherCharge> ServiceOtherCharges { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<ServiceOtherChargeSham> ServiceOtherChargeShams { get; set; }
    }
}
