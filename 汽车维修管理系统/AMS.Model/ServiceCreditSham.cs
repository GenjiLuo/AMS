namespace AMS.Model
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("ServiceCreditSham")]
    public partial class ServiceCreditSham
    {
        public int Id { get; set; }

        public int? ServiceAccountShamId { get; set; }

        public int? CustomerId { get; set; }

        public int? CreateBy { get; set; }

        public int? ModifyBy { get; set; }

        public decimal? CreditPrice { get; set; }

        public DateTime? CreateTime { get; set; }

        public DateTime? ModifyTime { get; set; }

        [StringLength(255)]
        public string Remark { get; set; }
    }
}
