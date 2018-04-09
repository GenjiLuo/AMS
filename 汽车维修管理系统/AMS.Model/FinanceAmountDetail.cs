namespace AMS.Model
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("FinanceAmountDetail")]
    public partial class FinanceAmountDetail
    {
        public int Id { get; set; }

        public int? ServicePaymentTypeId { get; set; }

        public int? FinanceBusinessRecordId { get; set; }

        public decimal Money { get; set; }

        public int? CreateBy { get; set; }

        public DateTime? CreateTime { get; set; }

        public int? ModifyBy { get; set; }

        public DateTime? ModifyTime { get; set; }

        public virtual FinanceBusinessRecord FinanceBusinessRecord { get; set; }

        public virtual ServicePaymentType ServicePaymentType { get; set; }
    }
}
