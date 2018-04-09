namespace AMS.Model
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("DailyFinanceDetail")]
    public partial class DailyFinanceDetail
    {
        public int Id { get; set; }

        public int DailyFinanceItemID { get; set; }

        [Required]
        [StringLength(50)]
        public string BillNo { get; set; }

        public decimal Amount { get; set; }

        public int? PaymentType { get; set; }

        [StringLength(50)]
        public string PayTarget { get; set; }

        public int? Operator { get; set; }

        public int? CreateBy { get; set; }

        public DateTime? CreateTime { get; set; }

        public int? ModifyBy { get; set; }

        public DateTime? ModifyTime { get; set; }

        [StringLength(500)]
        public string Remark { get; set; }

        public bool? IsSysPublic { get; set; }

        public int? OrganizationId { get; set; }

        public virtual Organization Organization { get; set; }

        public virtual DailyFinanceItem DailyFinanceItem { get; set; }
    }
}
