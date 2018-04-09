namespace AMS.Model
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("PartsPaymentHistory")]
    public partial class PartsPaymentHistory
    {
        public int? PartsInventoryRequestId { get; set; }

        [StringLength(255)]
        public string PaymentType { get; set; }

        public double? PaidMoney { get; set; }

        public int? CreateBy { get; set; }

        public DateTime? CreateTime { get; set; }

        public int? ModifyBy { get; set; }

        public DateTime? ModifyTime { get; set; }

        [StringLength(255)]
        public string BillNo { get; set; }

        public int Id { get; set; }

        public int? PeriodId { get; set; }

        public int? FinanceBusinessRecordId { get; set; }

        public virtual PartsInventoryRequest PartsInventoryRequest { get; set; }

        public virtual Period Period { get; set; }
    }
}
