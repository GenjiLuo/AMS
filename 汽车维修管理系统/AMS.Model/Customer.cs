namespace AMS.Model
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Customer")]
    public partial class Customer
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Customer()
        {
            Cars = new HashSet<Car>();
            ConsumerExpensesRecords = new HashSet<ConsumerExpensesRecord>();
            ConsumerRebatesRecords = new HashSet<ConsumerRebatesRecord>();
            ConsumerRebatesRecords1 = new HashSet<ConsumerRebatesRecord>();
            CustomerCashRequests = new HashSet<CustomerCashRequest>();
            CustomerMessages = new HashSet<CustomerMessage>();
            CustomerPrePayments = new HashSet<CustomerPrePayment>();
            CustomerRebatesIncomes = new HashSet<CustomerRebatesIncome>();
            FinanceBusinessRecords = new HashSet<FinanceBusinessRecord>();
            CustomerPackages = new HashSet<CustomerPackage>();
            CustomerPackageConsumes = new HashSet<CustomerPackageConsume>();
            CustomerPackageManageRecords = new HashSet<CustomerPackageManageRecord>();
            CustomerPackageOrders = new HashSet<CustomerPackageOrder>();
            PartsInventoryRequests = new HashSet<PartsInventoryRequest>();
            PeriodWarehouseBillings = new HashSet<PeriodWarehouseBilling>();
            PrePaymentDetailOrders = new HashSet<PrePaymentDetailOrder>();
            PrePaymentDetails = new HashSet<PrePaymentDetail>();
            ServiceCredits = new HashSet<ServiceCredit>();
            ServiceEvaluates = new HashSet<ServiceEvaluate>();
            ServiceEvaluateHistories = new HashSet<ServiceEvaluateHistory>();
            ServicePayCashes = new HashSet<ServicePayCash>();
            SMSAutoSends = new HashSet<SMSAutoSend>();
            Users = new HashSet<User>();
        }

        public int Id { get; set; }

        public int OrganizationId { get; set; }

        [Required]
        [StringLength(255)]
        public string Name { get; set; }

        [StringLength(255)]
        public string NameExtension { get; set; }

        [StringLength(255)]
        public string CustomerType { get; set; }

        [StringLength(200)]
        public string Address { get; set; }

        public string PasswordHash { get; set; }

        public string SecurityStamp { get; set; }

        public int? CreateBy { get; set; }

        public DateTime? CreateTime { get; set; }

        public int? ModifyBy { get; set; }

        public DateTime? ModifyTime { get; set; }

        public int? MallCustomerId { get; set; }

        [StringLength(255)]
        public string PromoCode { get; set; }

        [StringLength(255)]
        public string InvitationCode { get; set; }

        public int? DistributionResiterType { get; set; }

        public decimal? PirPayMent { get; set; }

        public int CustomerLevelId { get; set; }

        public bool? IsSysPublic { get; set; }

        [StringLength(255)]
        public string InvitationName { get; set; }

        [StringLength(255)]
        public string Mobile { get; set; }

        [StringLength(255)]
        public string Gender { get; set; }

        [Required]
        [StringLength(255)]
        public string RegisterType { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Car> Cars { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<ConsumerExpensesRecord> ConsumerExpensesRecords { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<ConsumerRebatesRecord> ConsumerRebatesRecords { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<ConsumerRebatesRecord> ConsumerRebatesRecords1 { get; set; }

        public virtual CustomerLevel CustomerLevel { get; set; }

        public virtual Organization Organization { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<CustomerCashRequest> CustomerCashRequests { get; set; }

        public virtual CustomerInfo CustomerInfo { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<CustomerMessage> CustomerMessages { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<CustomerPrePayment> CustomerPrePayments { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<CustomerRebatesIncome> CustomerRebatesIncomes { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<FinanceBusinessRecord> FinanceBusinessRecords { get; set; }

        public virtual MemberCard MemberCard { get; set; }

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
        public virtual ICollection<PeriodWarehouseBilling> PeriodWarehouseBillings { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<PrePaymentDetailOrder> PrePaymentDetailOrders { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<PrePaymentDetail> PrePaymentDetails { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<ServiceCredit> ServiceCredits { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<ServiceEvaluate> ServiceEvaluates { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<ServiceEvaluateHistory> ServiceEvaluateHistories { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<ServicePayCash> ServicePayCashes { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<SMSAutoSend> SMSAutoSends { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<User> Users { get; set; }

        public virtual WeChatMember WeChatMember { get; set; }
    }
}
