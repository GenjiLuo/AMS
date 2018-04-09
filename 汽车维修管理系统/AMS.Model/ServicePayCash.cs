namespace AMS.Model
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("ServicePayCash")]
    public partial class ServicePayCash
    {
        public int Id { get; set; }

        public int? ServiceCreditId { get; set; }

        public int? OrganizationId { get; set; }

        public int? CustomerId { get; set; }

        [StringLength(255)]
        public string FlowStatus { get; set; }

        [StringLength(50)]
        public string OrderNo { get; set; }

        public int? ServicePaymentTypeId { get; set; }

        public decimal? DiscountCash { get; set; }

        public decimal? PayCash { get; set; }

        public int? ServiceTicketTypeId { get; set; }

        [StringLength(50)]
        public string ManualOrderNo { get; set; }

        public int? ConfirmUserId { get; set; }

        public DateTime? ConfirmDate { get; set; }

        [StringLength(255)]
        public string Remark { get; set; }

        public int? CreateBy { get; set; }

        public DateTime? CreateTime { get; set; }

        public int? ModifyBy { get; set; }

        public DateTime? ModifyTime { get; set; }

        public virtual Customer Customer { get; set; }

        public virtual Organization Organization { get; set; }

        public virtual ServiceCredit ServiceCredit { get; set; }

        public virtual User User { get; set; }

        public virtual User User1 { get; set; }

        public virtual ServicePaymentType ServicePaymentType { get; set; }

        public virtual ServiceTicketType ServiceTicketType { get; set; }
    }
}
