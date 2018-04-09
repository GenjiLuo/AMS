namespace AMS.Model
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("PrePaymentDetailOrder")]
    public partial class PrePaymentDetailOrder
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

        [Required]
        [StringLength(255)]
        public string Status { get; set; }

        public virtual Customer Customer { get; set; }
    }
}
