namespace AMS.Model
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("MemberCardChargeOrder")]
    public partial class MemberCardChargeOrder
    {
        public int Id { get; set; }

        [StringLength(255)]
        public string BillNo { get; set; }

        public int? MemberCardId { get; set; }

        public int? StrategyId { get; set; }

        public decimal? Money { get; set; }

        public decimal? EMoney { get; set; }

        public int? OrganizationId { get; set; }

        [StringLength(255)]
        public string Remarks { get; set; }

        public decimal? CurrentBalance { get; set; }

        public DateTime? CreateTime { get; set; }

        public int? CreateBy { get; set; }

        public DateTime? ModifyTime { get; set; }

        public int? ModifyBy { get; set; }

        [StringLength(255)]
        public string Status { get; set; }

        public int? CustomerCashRequestId { get; set; }

        public virtual CustomerCashRequest CustomerCashRequest { get; set; }

        public virtual MemberCard MemberCard { get; set; }

        public virtual Organization Organization { get; set; }

        public virtual MemberChargeStrategy MemberChargeStrategy { get; set; }
    }
}
