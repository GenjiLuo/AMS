namespace AMS.Model
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class PrePaymentDetail
    {
        public int Id { get; set; }

        public int CustomerId { get; set; }

        public decimal Money { get; set; }

        public int Type { get; set; }

        public int CreateBy { get; set; }

        public DateTime CreateTime { get; set; }

        public int ModifyBy { get; set; }

        public DateTime ModifyTime { get; set; }

        [Required]
        [StringLength(255)]
        public string BillNo { get; set; }

        [StringLength(255)]
        public string WorkOrderNo { get; set; }

        public virtual Customer Customer { get; set; }
    }
}
