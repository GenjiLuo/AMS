namespace AMS.Model
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("ServiceCar")]
    public partial class ServiceCar
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public ServiceCar()
        {
            FakePartsInventoryRequests = new HashSet<FakePartsInventoryRequest>();
            FilesServiceCars = new HashSet<FilesServiceCar>();
            PartsInventoryRequests = new HashSet<PartsInventoryRequest>();
            ServiceAccounts = new HashSet<ServiceAccount>();
            ServiceBookingRepairItems = new HashSet<ServiceBookingRepairItem>();
            ServiceCarPlannedFinishTimeChangeHistories = new HashSet<ServiceCarPlannedFinishTimeChangeHistory>();
            ServiceCarRepairItems = new HashSet<ServiceCarRepairItem>();
            ServiceCarShams = new HashSet<ServiceCarSham>();
            ServiceCarViewHistories = new HashSet<ServiceCarViewHistory>();
            ServiceCarWorkProcesses = new HashSet<ServiceCarWorkProcess>();
            ServiceEvaluateHistories = new HashSet<ServiceEvaluateHistory>();
            ServiceOtherCharges = new HashSet<ServiceOtherCharge>();
            ServiceReturnVisitHistories = new HashSet<ServiceReturnVisitHistory>();
            Stations = new HashSet<Station>();
        }

        public int Id { get; set; }

        public int CarId { get; set; }

        [Required]
        [StringLength(50)]
        public string WorkOrderNo { get; set; }

        [Required]
        [StringLength(10)]
        public string FlowStatus { get; set; }

        public int RepairTypeId { get; set; }

        public int RepairAdviserId { get; set; }

        public int? ServiceBookingId { get; set; }

        public DateTime? PlannedFinishDate { get; set; }

        [StringLength(2000)]
        public string CarContact { get; set; }

        [StringLength(2000)]
        public string CarContactPhone { get; set; }

        [StringLength(2000)]
        public string CarContactAddress { get; set; }

        [StringLength(20)]
        public string Mileage { get; set; }

        [StringLength(20)]
        public string NextMileage { get; set; }

        [StringLength(20)]
        public string RemainingOil { get; set; }

        [StringLength(255)]
        public string ImportantNotice { get; set; }

        [StringLength(4000)]
        public string FaultDescription { get; set; }

        [StringLength(2000)]
        public string AppointUnit { get; set; }

        [StringLength(4000)]
        public string RepairInstractions { get; set; }

        [StringLength(100)]
        public string InsuranceCompany { get; set; }

        [StringLength(4000)]
        public string SelfRemark { get; set; }

        [StringLength(500)]
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

        public DateTime? IntoFactoryTime { get; set; }

        public int? ConfirmUserId { get; set; }

        public DateTime? ConfirmDate { get; set; }

        public DateTime? RepairCompletedDate { get; set; }

        public DateTime? ExFactoryDate { get; set; }

        public DateTime? ReturnDate { get; set; }

        public int? FinanceBusinessRecordId { get; set; }

        public int? MemberConsumeId { get; set; }

        [StringLength(255)]
        public string Remark { get; set; }

        public int? CreateBy { get; set; }

        public DateTime? CreateTime { get; set; }

        public int? ModifyBy { get; set; }

        public DateTime? ModifyTime { get; set; }

        public decimal? FakeMaterialsCost { get; set; }

        public decimal? FakeManagementCost { get; set; }

        public int? SheetMetalUserId { get; set; }

        public int? BlendUserId { get; set; }

        public int? PaintUserId { get; set; }

        public DateTime? RepairStartTime { get; set; }

        public DateTime? RequiredCompleteTime { get; set; }

        public int? CurrentWorkProcessId { get; set; }

        public int? WorkProcessStatus { get; set; }

        public int? OrganizationId { get; set; }

        public bool? IsSysPublic { get; set; }

        public bool HasReturnVisited { get; set; }

        public int WorkType { get; set; }

        [StringLength(255)]
        public string DevKey { get; set; }

        [StringLength(255)]
        public string DevName { get; set; }

        [StringLength(255)]
        public string ShopKey { get; set; }

        public virtual Car Car { get; set; }

        public virtual CarAccidentClaim CarAccidentClaim { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<FakePartsInventoryRequest> FakePartsInventoryRequests { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<FilesServiceCar> FilesServiceCars { get; set; }

        public virtual FinanceBusinessRecord FinanceBusinessRecord { get; set; }

        public virtual HealthPushInfo HealthPushInfo { get; set; }

        public virtual MemberCardConsume MemberCardConsume { get; set; }

        public virtual Organization Organization { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<PartsInventoryRequest> PartsInventoryRequests { get; set; }

        public virtual RepairType RepairType { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<ServiceAccount> ServiceAccounts { get; set; }

        public virtual ServiceBooking ServiceBooking { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<ServiceBookingRepairItem> ServiceBookingRepairItems { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<ServiceCarPlannedFinishTimeChangeHistory> ServiceCarPlannedFinishTimeChangeHistories { get; set; }

        public virtual User User { get; set; }

        public virtual User User1 { get; set; }

        public virtual User User2 { get; set; }

        public virtual User User3 { get; set; }

        public virtual ServiceCustomerSource ServiceCustomerSource { get; set; }

        public virtual ServiceOldPartsHandle ServiceOldPartsHandle { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<ServiceCarRepairItem> ServiceCarRepairItems { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<ServiceCarSham> ServiceCarShams { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<ServiceCarViewHistory> ServiceCarViewHistories { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<ServiceCarWorkProcess> ServiceCarWorkProcesses { get; set; }

        public virtual ServiceEvaluate ServiceEvaluate { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<ServiceEvaluateHistory> ServiceEvaluateHistories { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<ServiceOtherCharge> ServiceOtherCharges { get; set; }

        public virtual ServiceReturnVisit ServiceReturnVisit { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<ServiceReturnVisitHistory> ServiceReturnVisitHistories { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Station> Stations { get; set; }
    }
}
