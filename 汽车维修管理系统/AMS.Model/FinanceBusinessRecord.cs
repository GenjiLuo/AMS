namespace AMS.Model
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("FinanceBusinessRecord")]
    public partial class FinanceBusinessRecord
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public FinanceBusinessRecord()
        {
            CustomerPackages = new HashSet<CustomerPackage>();
            FinanceAmountDetails = new HashSet<FinanceAmountDetail>();
            MemberCardCharges = new HashSet<MemberCardCharge>();
            ServiceCars = new HashSet<ServiceCar>();
        }

        public int Id { get; set; }

        public int? BusinessTypeId { get; set; }

        public int? ServiceTicketTypeId { get; set; }

        public int? MemberScoreId { get; set; }

        [StringLength(100)]
        public string ServiceTicketNo { get; set; }

        public decimal CustomerPayMoney { get; set; }

        public decimal ShouldPayMoney { get; set; }

        public decimal ChangeMoney { get; set; }

        public int? CreateBy { get; set; }

        public DateTime? CreateTime { get; set; }

        public int? ModifyBy { get; set; }

        public DateTime? ModifyTime { get; set; }

        public int? HandleOrganizationId { get; set; }

        public int? HandleCustomerId { get; set; }

        public int? HandleCarId { get; set; }

        [StringLength(200)]
        public string BillingNo { get; set; }

        public bool? Deleted { get; set; }

        public virtual Car Car { get; set; }

        public virtual Customer Customer { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<CustomerPackage> CustomerPackages { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<FinanceAmountDetail> FinanceAmountDetails { get; set; }

        public virtual MemberCardScore MemberCardScore { get; set; }

        public virtual Organization Organization { get; set; }

        public virtual ServiceTicketType ServiceTicketType { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<MemberCardCharge> MemberCardCharges { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<ServiceCar> ServiceCars { get; set; }
    }
}
