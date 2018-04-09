namespace AMS.Model
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("CustomerCashRequest")]
    public partial class CustomerCashRequest
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public CustomerCashRequest()
        {
            CashRequestRequestparameters = new HashSet<CashRequestRequestparameter>();
            MemberCardCharges = new HashSet<MemberCardCharge>();
            MemberCardChargeOrders = new HashSet<MemberCardChargeOrder>();
        }

        public int Id { get; set; }

        public int CustomerRebatesIncomeId { get; set; }

        [Required]
        [StringLength(255)]
        public string BillNO { get; set; }

        public decimal CashMoney { get; set; }

        public int RequestCustomerId { get; set; }

        public int Staus { get; set; }

        public DateTime RequestTime { get; set; }

        public DateTime? ConfirmTime { get; set; }

        public DateTime? CompletedTime { get; set; }

        public int? CustomerDistributionFinanceId { get; set; }

        public int? CreateBy { get; set; }

        public DateTime? CreateTime { get; set; }

        public int? ModifyBy { get; set; }

        public DateTime? ModifyTime { get; set; }

        public int? ConfirmBy { get; set; }

        public int? RequestType { get; set; }

        [StringLength(255)]
        public string ErrCode { get; set; }

        [StringLength(255)]
        public string ErrCodeDes { get; set; }

        [StringLength(255)]
        public string WechatOpenId { get; set; }

        public bool? IsSysPublic { get; set; }

        public int? OrganizationId { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<CashRequestRequestparameter> CashRequestRequestparameters { get; set; }

        public virtual Customer Customer { get; set; }

        public virtual Organization Organization { get; set; }

        public virtual User User { get; set; }

        public virtual CustomerDistributionFinance CustomerDistributionFinance { get; set; }

        public virtual CustomerRebatesIncome CustomerRebatesIncome { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<MemberCardCharge> MemberCardCharges { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<MemberCardChargeOrder> MemberCardChargeOrders { get; set; }
    }
}
