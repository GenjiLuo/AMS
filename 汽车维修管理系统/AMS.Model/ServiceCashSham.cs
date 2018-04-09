namespace AMS.Model
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("ServiceCashSham")]
    public partial class ServiceCashSham
    {
        public int Id { get; set; }

        public int? ServiceCarShamId { get; set; }

        public int? TicketTypeId { get; set; }

        [StringLength(50)]
        public string TicketNo { get; set; }

        [StringLength(255)]
        public string Remarak { get; set; }

        public int? CreateBy { get; set; }

        public int? ModifyBy { get; set; }

        public decimal? CashPay { get; set; }

        public decimal? BankCardPay { get; set; }

        public decimal? CheckPay { get; set; }

        public decimal? CreditCardPay { get; set; }

        public decimal? NotPay { get; set; }

        public DateTime? ModifyTime { get; set; }

        public DateTime? CreateTime { get; set; }
    }
}
