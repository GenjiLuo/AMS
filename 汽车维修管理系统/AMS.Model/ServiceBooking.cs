namespace AMS.Model
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("ServiceBooking")]
    public partial class ServiceBooking
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public ServiceBooking()
        {
            ServiceBookingRepairItems = new HashSet<ServiceBookingRepairItem>();
            ServiceCars = new HashSet<ServiceCar>();
        }

        public int Id { get; set; }

        public int? RepairTypeId { get; set; }

        public int? RepairAdviserId { get; set; }

        public int? OrganizationId { get; set; }

        public DateTime? BookingDate { get; set; }

        [StringLength(2000)]
        public string CarContact { get; set; }

        [StringLength(2000)]
        public string CarContactPhone { get; set; }

        [StringLength(2000)]
        public string CarContactAddress { get; set; }

        [StringLength(2000)]
        public string AppointUnit { get; set; }

        [StringLength(500)]
        public string AppointDescription { get; set; }

        [StringLength(500)]
        public string RepairNotes { get; set; }

        [StringLength(200)]
        public string ImportantNotice { get; set; }

        [StringLength(500)]
        public string Remark { get; set; }

        public int? CreateBy { get; set; }

        public DateTime? CreateTime { get; set; }

        public int? ModifyBy { get; set; }

        public DateTime? ModifyTime { get; set; }

        public decimal? SumLaborHoursCost { get; set; }

        public decimal? SumMaterialCost { get; set; }

        public decimal? SumManageCost { get; set; }

        public double? ManageCostRate { get; set; }

        public decimal? TotalCost { get; set; }

        [StringLength(10)]
        public string FlowStatus { get; set; }

        [StringLength(255)]
        public string BookingNo { get; set; }

        public int? CarId { get; set; }

        [StringLength(200)]
        public string BookingType { get; set; }

        public bool? IsSysPublic { get; set; }

        [StringLength(255)]
        public string DevKey { get; set; }

        [StringLength(255)]
        public string DevName { get; set; }

        [StringLength(255)]
        public string ShopKey { get; set; }

        [StringLength(255)]
        public string OriginalBillNo { get; set; }

        public virtual Car Car { get; set; }

        public virtual Organization Organization { get; set; }

        public virtual RepairType RepairType { get; set; }

        public virtual User User { get; set; }

        public virtual User User1 { get; set; }

        public virtual User User2 { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<ServiceBookingRepairItem> ServiceBookingRepairItems { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<ServiceCar> ServiceCars { get; set; }
    }
}
