namespace AMS.Model
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("CustomerPrePaymentDetail")]
    public partial class CustomerPrePaymentDetail
    {
        public int Id { get; set; }

        public int CustomerPrePaymentId { get; set; }

        public decimal? Amount { get; set; }

        public int Type { get; set; }

        public int? CreateBy { get; set; }

        public DateTime? CreateTime { get; set; }

        public int? ModifyBy { get; set; }

        public DateTime? ModifyTime { get; set; }

        [StringLength(255)]
        public string BillNo { get; set; }

        [StringLength(255)]
        public string WorkOrderNo { get; set; }

        public virtual CustomerPrePayment CustomerPrePayment { get; set; }
    }
}
