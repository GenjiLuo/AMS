namespace AMS.Model
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("MemberCardCharge")]
    public partial class MemberCardCharge
    {
        public int Id { get; set; }

        public int? OrganizationId { get; set; }

        public int? MemberCardId { get; set; }

        [StringLength(255)]
        public string BillNo { get; set; }

        public int? StrategyId { get; set; }

        public decimal? Money { get; set; }

        public decimal? Emoney { get; set; }

        public double? CurrentBalance { get; set; }

        public int? FinanceBusinessRecordId { get; set; }

        public int? MemberScoreId { get; set; }

        [StringLength(255)]
        public string CreateUserId { get; set; }

        [StringLength(255)]
        public string Remarks { get; set; }

        public int? CreateBy { get; set; }

        public DateTime? CreateTime { get; set; }

        public int? ModifyBy { get; set; }

        public DateTime? ModifyTime { get; set; }

        public int ChargeType { get; set; }

        public bool IsIn { get; set; }

        public int? RelatedChargeId { get; set; }

        public int? CustomerCashRequestId { get; set; }

        public int Status { get; set; }

        public virtual CustomerCashRequest CustomerCashRequest { get; set; }

        public virtual FinanceBusinessRecord FinanceBusinessRecord { get; set; }

        public virtual MemberCard MemberCard { get; set; }

        public virtual MemberChargeStrategy MemberChargeStrategy { get; set; }

        public virtual MemberCardScore MemberCardScore { get; set; }

        public virtual Organization Organization { get; set; }
    }
}
