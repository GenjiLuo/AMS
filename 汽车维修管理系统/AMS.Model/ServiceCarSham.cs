namespace AMS.Model
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("ServiceCarSham")]
    public partial class ServiceCarSham
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public ServiceCarSham()
        {
            ServiceAccountShams = new HashSet<ServiceAccountSham>();
            ServiceCarRepairItemShams = new HashSet<ServiceCarRepairItemSham>();
            ServiceOtherChargeShams = new HashSet<ServiceOtherChargeSham>();
        }

        public int Id { get; set; }

        public int? ServiceCarId { get; set; }

        public int OrganizationId { get; set; }

        public int CarId { get; set; }

        [Required]
        [StringLength(50)]
        public string WorkOrderNo { get; set; }

        [Required]
        [StringLength(255)]
        public string FlowStatus { get; set; }

        public int RepairTypeId { get; set; }

        public int RepairAdviserId { get; set; }

        public DateTime? PlannedFinishDate { get; set; }

        [StringLength(2000)]
        public string CarContact { get; set; }

        [StringLength(2000)]
        public string CarContactPhone { get; set; }

        [StringLength(2000)]
        public string CarContactAddress { get; set; }

        [StringLength(50)]
        public string Mileage { get; set; }

        [StringLength(50)]
        public string NextMileage { get; set; }

        [StringLength(50)]
        public string RemainingOil { get; set; }

        [StringLength(255)]
        public string ImportantNotice { get; set; }

        [StringLength(255)]
        public string FaultDescription { get; set; }

        [StringLength(2000)]
        public string AppointUnit { get; set; }

        [StringLength(100)]
        public string RepairInstractions { get; set; }

        [StringLength(100)]
        public string InsuranceCompany { get; set; }

        [StringLength(100)]
        public string SelfRemark { get; set; }

        [StringLength(255)]
        public string CarFaultGraph { get; set; }

        public decimal? EstimateMaterialCost { get; set; }

        public decimal? CarCheckPrice { get; set; }

        public decimal? LaborHoursCost { get; set; }

        public decimal? ActualMaterialCost { get; set; }

        public decimal? OtherCost { get; set; }

        public decimal? ManagementCost { get; set; }

        public decimal? TotalCost { get; set; }

        public decimal? SupplierPrice { get; set; }

        public int? CustomerOriginId { get; set; }

        public int? OldPartsProcessingId { get; set; }

        public DateTime? CreateDate { get; set; }

        public int? ConfirmUserId { get; set; }

        public DateTime? ConfirmDate { get; set; }

        public DateTime? ExFactoryDate { get; set; }

        public DateTime? ReturnDate { get; set; }

        [StringLength(255)]
        public string Remark { get; set; }

        public int? CreateBy { get; set; }

        public DateTime? CreateTime { get; set; }

        public int? ModifyBy { get; set; }

        public DateTime? ModifyTime { get; set; }

        public bool? IsSysPublic { get; set; }

        public virtual Car Car { get; set; }

        public virtual Organization Organization { get; set; }

        public virtual RepairType RepairType { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<ServiceAccountSham> ServiceAccountShams { get; set; }

        public virtual ServiceCar ServiceCar { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<ServiceCarRepairItemSham> ServiceCarRepairItemShams { get; set; }

        public virtual User User { get; set; }

        public virtual ServiceCustomerSource ServiceCustomerSource { get; set; }

        public virtual User User1 { get; set; }

        public virtual ServiceOldPartsHandle ServiceOldPartsHandle { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<ServiceOtherChargeSham> ServiceOtherChargeShams { get; set; }
    }
}
