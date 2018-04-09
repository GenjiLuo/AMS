namespace AMS.Model
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Car")]
    public partial class Car
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Car()
        {
            CarFaultsMessages = new HashSet<CarFaultsMessage>();
            CarInsurances = new HashSet<CarInsurance>();
            CarLabelRelations = new HashSet<CarLabelRelation>();
            FilesCars = new HashSet<FilesCar>();
            FinanceBusinessRecords = new HashSet<FinanceBusinessRecord>();
            CustomerPackages = new HashSet<CustomerPackage>();
            CustomerPackageConsumes = new HashSet<CustomerPackageConsume>();
            CustomerPackageManageRecords = new HashSet<CustomerPackageManageRecord>();
            CustomerPackageOrders = new HashSet<CustomerPackageOrder>();
            PartsInventoryRequests = new HashSet<PartsInventoryRequest>();
            ServiceBookings = new HashSet<ServiceBooking>();
            ServiceCars = new HashSet<ServiceCar>();
            ServiceCarShams = new HashSet<ServiceCarSham>();
            SMSAutoSends = new HashSet<SMSAutoSend>();
        }

        public int Id { get; set; }

        public int? CustomerId { get; set; }

        [StringLength(255)]
        public string CarOwner { get; set; }

        [StringLength(255)]
        public string CarOwnerMobile { get; set; }

        [StringLength(255)]
        public string CarNo { get; set; }

        [StringLength(255)]
        public string CarNoExtension { get; set; }

        [StringLength(255)]
        public string Brand { get; set; }

        [StringLength(200)]
        public string BrandModel { get; set; }

        [StringLength(20)]
        public string Color { get; set; }

        [StringLength(100)]
        public string WMI { get; set; }

        [StringLength(200)]
        public string EngineModel { get; set; }

        [StringLength(100)]
        public string VIN { get; set; }

        public int? CarTypeId { get; set; }

        public DateTime? RegistrationDate { get; set; }

        [StringLength(200)]
        public string InsuranceCompany { get; set; }

        [StringLength(200)]
        public string InsuranceNumber { get; set; }

        public DateTime? YearlyCheckDate { get; set; }

        public DateTime? NextMaintenanceDate { get; set; }

        public DateTime? NextInsuranceDate { get; set; }

        public int? CurrentMileage { get; set; }

        public DateTime? LastSyncTime { get; set; }

        public DateTime? CompleteMaintenanceDate { get; set; }

        public DateTime? RatingDate { get; set; }

        public DateTime? ExpiredVehicleInspectionDate { get; set; }

        public DateTime? LatestRepairDate { get; set; }

        [StringLength(255)]
        public string ObdBrand { get; set; }

        [StringLength(255)]
        public string ObdDeviceId { get; set; }

        public DateTime? ObdInstallDate { get; set; }

        public int? MemberLevel { get; set; }

        public double? MemberScore { get; set; }

        public decimal? ExpenseAmount { get; set; }

        public decimal? NeedPayAmount { get; set; }

        public string Description { get; set; }

        public int? CreateBy { get; set; }

        public DateTime? CreateTime { get; set; }

        public int? ModifyBy { get; set; }

        public DateTime? ModifyTime { get; set; }

        public int? LatestRepairMileage { get; set; }

        public int? NextMaintenanceMileage { get; set; }

        public bool? IsSysPublic { get; set; }

        public int? OrganizationId { get; set; }

        public virtual Organization Organization { get; set; }

        public virtual CarType CarType { get; set; }

        public virtual User User { get; set; }

        public virtual Customer Customer { get; set; }

        public virtual User User1 { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<CarFaultsMessage> CarFaultsMessages { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<CarInsurance> CarInsurances { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<CarLabelRelation> CarLabelRelations { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<FilesCar> FilesCars { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<FinanceBusinessRecord> FinanceBusinessRecords { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<CustomerPackage> CustomerPackages { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<CustomerPackageConsume> CustomerPackageConsumes { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<CustomerPackageManageRecord> CustomerPackageManageRecords { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<CustomerPackageOrder> CustomerPackageOrders { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<PartsInventoryRequest> PartsInventoryRequests { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<ServiceBooking> ServiceBookings { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<ServiceCar> ServiceCars { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<ServiceCarSham> ServiceCarShams { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<SMSAutoSend> SMSAutoSends { get; set; }
    }
}
