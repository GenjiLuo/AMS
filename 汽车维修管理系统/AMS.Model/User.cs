namespace AMS.Model
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("User")]
    public partial class User
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public User()
        {
            Cars = new HashSet<Car>();
            Cars1 = new HashSet<Car>();
            CarFaultyCarMessageHandleHistories = new HashSet<CarFaultyCarMessageHandleHistory>();
            CarFaultyCarMessageHandleHistories1 = new HashSet<CarFaultyCarMessageHandleHistory>();
            CarPrefixes = new HashSet<CarPrefix>();
            CustomerCashRequests = new HashSet<CustomerCashRequest>();
            CustomerPackages = new HashSet<CustomerPackage>();
            FakePartsInventoryRequests = new HashSet<FakePartsInventoryRequest>();
            FakePartsInventoryRequests1 = new HashSet<FakePartsInventoryRequest>();
            FakePartsInventoryRequests2 = new HashSet<FakePartsInventoryRequest>();
            FakePartsInventoryRequests3 = new HashSet<FakePartsInventoryRequest>();
            FakePartsInventoryRequestDetails = new HashSet<FakePartsInventoryRequestDetail>();
            FakePartsInventoryRequestDetails1 = new HashSet<FakePartsInventoryRequestDetail>();
            HomeUserConfigs = new HashSet<HomeUserConfig>();
            MemberCardScores = new HashSet<MemberCardScore>();
            PartsInventoryChanges = new HashSet<PartsInventoryChange>();
            PartsInventoryChangeRefSNs = new HashSet<PartsInventoryChangeRefSN>();
            PartsInventoryChangeRefSNs1 = new HashSet<PartsInventoryChangeRefSN>();
            PartsInventoryRefSNs = new HashSet<PartsInventoryRefSN>();
            PartsInventoryRefSNs1 = new HashSet<PartsInventoryRefSN>();
            PartsInventoryRequests = new HashSet<PartsInventoryRequest>();
            PartsInventoryRequests1 = new HashSet<PartsInventoryRequest>();
            PartsInventoryRequests2 = new HashSet<PartsInventoryRequest>();
            PartsInventoryRequests3 = new HashSet<PartsInventoryRequest>();
            PartsPriceChanges = new HashSet<PartsPriceChange>();
            PartsPriceChanges1 = new HashSet<PartsPriceChange>();
            PartsUniqueSNs = new HashSet<PartsUniqueSN>();
            PartsUniqueSNs1 = new HashSet<PartsUniqueSN>();
            ServiceAccounts = new HashSet<ServiceAccount>();
            ServiceAccounts1 = new HashSet<ServiceAccount>();
            ServiceBookings = new HashSet<ServiceBooking>();
            ServiceBookings1 = new HashSet<ServiceBooking>();
            ServiceBookings2 = new HashSet<ServiceBooking>();
            ServiceBookingRepairItems = new HashSet<ServiceBookingRepairItem>();
            ServiceBookingRepairItems1 = new HashSet<ServiceBookingRepairItem>();
            ServiceCars = new HashSet<ServiceCar>();
            ServiceCars1 = new HashSet<ServiceCar>();
            ServiceCars2 = new HashSet<ServiceCar>();
            ServiceCars3 = new HashSet<ServiceCar>();
            ServiceCarPlannedFinishTimeChangeHistories = new HashSet<ServiceCarPlannedFinishTimeChangeHistory>();
            ServiceCarPlannedFinishTimeChangeHistories1 = new HashSet<ServiceCarPlannedFinishTimeChangeHistory>();
            ServiceCarRepairItems = new HashSet<ServiceCarRepairItem>();
            ServiceCarRepairItems1 = new HashSet<ServiceCarRepairItem>();
            ServiceCarRepairItems2 = new HashSet<ServiceCarRepairItem>();
            ServiceCarRepairItemShams = new HashSet<ServiceCarRepairItemSham>();
            ServiceCarShams = new HashSet<ServiceCarSham>();
            ServiceCarShams1 = new HashSet<ServiceCarSham>();
            ServiceCarViewHistories = new HashSet<ServiceCarViewHistory>();
            ServiceCarWorkProcesses = new HashSet<ServiceCarWorkProcess>();
            ServiceCredits = new HashSet<ServiceCredit>();
            ServiceCredits1 = new HashSet<ServiceCredit>();
            ServicePayCashes = new HashSet<ServicePayCash>();
            ServicePayCashes1 = new HashSet<ServicePayCash>();
            SystemActivityLogs = new HashSet<SystemActivityLog>();
            SystemActivityLogs1 = new HashSet<SystemActivityLog>();
            SystemDataLogs = new HashSet<SystemDataLog>();
            SystemDataLogs1 = new HashSet<SystemDataLog>();
            SystemPersistStates = new HashSet<SystemPersistState>();
            UserAppClients = new HashSet<UserAppClient>();
            UserEmployeeLabels = new HashSet<UserEmployeeLabel>();
            UserOrgPermissions = new HashSet<UserOrgPermission>();
            UserRoles = new HashSet<UserRole>();
            UserWarehouses = new HashSet<UserWarehous>();
            Warehouses = new HashSet<Warehouse>();
        }

        public int Id { get; set; }

        public int? UserPostId { get; set; }

        public int? OrganizationId { get; set; }

        [StringLength(255)]
        public string UserNo { get; set; }

        [StringLength(20)]
        public string Name { get; set; }

        [StringLength(255)]
        public string Email { get; set; }

        [StringLength(255)]
        public string Phone { get; set; }

        [StringLength(255)]
        public string UserName { get; set; }

        [StringLength(255)]
        public string NormalizedUserName { get; set; }

        [StringLength(255)]
        public string UserNameExtension { get; set; }

        [StringLength(255)]
        public string Password { get; set; }

        [StringLength(255)]
        public string PasswordFormat { get; set; }

        [StringLength(255)]
        public string HashAlgorithm { get; set; }

        [StringLength(255)]
        public string PasswordSalt { get; set; }

        [StringLength(255)]
        public string RegistrationStatus { get; set; }

        [StringLength(255)]
        public string EmailStatus { get; set; }

        [StringLength(255)]
        public string EmailChallengeToken { get; set; }

        public int? CreateBy { get; set; }

        public int? ModifyBy { get; set; }

        public DateTime? CreateTime { get; set; }

        public DateTime? ModifyTime { get; set; }

        public bool ViewAllServiceCar { get; set; }

        public int? CustomerId { get; set; }

        [StringLength(255)]
        public string ServicePwd { get; set; }

        public DateTime? LastLogonTime { get; set; }

        [StringLength(255)]
        public string Token { get; set; }

        public bool? IsSysPublic { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Car> Cars { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Car> Cars1 { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<CarFaultyCarMessageHandleHistory> CarFaultyCarMessageHandleHistories { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<CarFaultyCarMessageHandleHistory> CarFaultyCarMessageHandleHistories1 { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<CarPrefix> CarPrefixes { get; set; }

        public virtual Customer Customer { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<CustomerCashRequest> CustomerCashRequests { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<CustomerPackage> CustomerPackages { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<FakePartsInventoryRequest> FakePartsInventoryRequests { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<FakePartsInventoryRequest> FakePartsInventoryRequests1 { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<FakePartsInventoryRequest> FakePartsInventoryRequests2 { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<FakePartsInventoryRequest> FakePartsInventoryRequests3 { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<FakePartsInventoryRequestDetail> FakePartsInventoryRequestDetails { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<FakePartsInventoryRequestDetail> FakePartsInventoryRequestDetails1 { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<HomeUserConfig> HomeUserConfigs { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<MemberCardScore> MemberCardScores { get; set; }

        public virtual Organization Organization { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<PartsInventoryChange> PartsInventoryChanges { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<PartsInventoryChangeRefSN> PartsInventoryChangeRefSNs { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<PartsInventoryChangeRefSN> PartsInventoryChangeRefSNs1 { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<PartsInventoryRefSN> PartsInventoryRefSNs { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<PartsInventoryRefSN> PartsInventoryRefSNs1 { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<PartsInventoryRequest> PartsInventoryRequests { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<PartsInventoryRequest> PartsInventoryRequests1 { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<PartsInventoryRequest> PartsInventoryRequests2 { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<PartsInventoryRequest> PartsInventoryRequests3 { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<PartsPriceChange> PartsPriceChanges { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<PartsPriceChange> PartsPriceChanges1 { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<PartsUniqueSN> PartsUniqueSNs { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<PartsUniqueSN> PartsUniqueSNs1 { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<ServiceAccount> ServiceAccounts { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<ServiceAccount> ServiceAccounts1 { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<ServiceBooking> ServiceBookings { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<ServiceBooking> ServiceBookings1 { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<ServiceBooking> ServiceBookings2 { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<ServiceBookingRepairItem> ServiceBookingRepairItems { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<ServiceBookingRepairItem> ServiceBookingRepairItems1 { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<ServiceCar> ServiceCars { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<ServiceCar> ServiceCars1 { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<ServiceCar> ServiceCars2 { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<ServiceCar> ServiceCars3 { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<ServiceCarPlannedFinishTimeChangeHistory> ServiceCarPlannedFinishTimeChangeHistories { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<ServiceCarPlannedFinishTimeChangeHistory> ServiceCarPlannedFinishTimeChangeHistories1 { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<ServiceCarRepairItem> ServiceCarRepairItems { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<ServiceCarRepairItem> ServiceCarRepairItems1 { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<ServiceCarRepairItem> ServiceCarRepairItems2 { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<ServiceCarRepairItemSham> ServiceCarRepairItemShams { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<ServiceCarSham> ServiceCarShams { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<ServiceCarSham> ServiceCarShams1 { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<ServiceCarViewHistory> ServiceCarViewHistories { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<ServiceCarWorkProcess> ServiceCarWorkProcesses { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<ServiceCredit> ServiceCredits { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<ServiceCredit> ServiceCredits1 { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<ServicePayCash> ServicePayCashes { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<ServicePayCash> ServicePayCashes1 { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<SystemActivityLog> SystemActivityLogs { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<SystemActivityLog> SystemActivityLogs1 { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<SystemDataLog> SystemDataLogs { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<SystemDataLog> SystemDataLogs1 { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<SystemPersistState> SystemPersistStates { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<UserAppClient> UserAppClients { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<UserEmployeeLabel> UserEmployeeLabels { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<UserOrgPermission> UserOrgPermissions { get; set; }

        public virtual UserPreference UserPreference { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<UserRole> UserRoles { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<UserWarehous> UserWarehouses { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Warehouse> Warehouses { get; set; }
    }
}
