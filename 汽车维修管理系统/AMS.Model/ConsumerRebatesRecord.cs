namespace AMS.Model
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("ConsumerRebatesRecord")]
    public partial class ConsumerRebatesRecord
    {
        public int Id { get; set; }

        public int CustomerRebatesIncomeId { get; set; }

        public int? WorkOrderId { get; set; }

        public int ConsumerType { get; set; }

        [StringLength(255)]
        public string BillNo { get; set; }

        public decimal? ConsumerAmount { get; set; }

        public int ConsumerId { get; set; }

        public decimal? RebatesRate { get; set; }

        public int RebatesLevel { get; set; }

        public decimal RebatesAmount { get; set; }

        public int ReferenceId { get; set; }

        [Required]
        [StringLength(255)]
        public string InvitationCode { get; set; }

        public int? CustomerDistributionFinanceId { get; set; }

        public int? CreateBy { get; set; }

        public DateTime? CreateTime { get; set; }

        public int? ModifyBy { get; set; }

        public DateTime? ModifyTime { get; set; }

        public int CustomerDistributionActivityId { get; set; }

        public bool? IsSysPublic { get; set; }

        public int? OrganizationId { get; set; }

        public virtual Organization Organization { get; set; }

        public virtual Customer Customer { get; set; }

        public virtual CustomerDistributionActivity CustomerDistributionActivity { get; set; }

        public virtual CustomerDistributionFinance CustomerDistributionFinance { get; set; }

        public virtual CustomerRebatesIncome CustomerRebatesIncome { get; set; }

        public virtual Customer Customer1 { get; set; }
    }
}
