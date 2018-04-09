namespace AMS.Model
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("PartsInventoryRequest")]
    public partial class PartsInventoryRequest
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public PartsInventoryRequest()
        {
            PartsInventories = new HashSet<PartsInventory>();
            PartsInventoryChanges = new HashSet<PartsInventoryChange>();
            PartsInventoryRequestDetails = new HashSet<PartsInventoryRequestDetail>();
            PartsPaymentHistories = new HashSet<PartsPaymentHistory>();
        }

        public int Id { get; set; }

        public int? SupplierId { get; set; }

        [StringLength(255)]
        public string RequestType { get; set; }

        [Required]
        [StringLength(50)]
        public string BillNo { get; set; }

        public double? Count { get; set; }

        public DateTime? RequestDate { get; set; }

        public int? RequestUserId { get; set; }

        public int? RelatedCustomerId { get; set; }

        public int? RelatedCarId { get; set; }

        [StringLength(255)]
        public string PaymentType { get; set; }

        [StringLength(255)]
        public string Status { get; set; }

        public DateTime? ConfirmDate { get; set; }

        public int? ConfirmUserId { get; set; }

        public DateTime? PaymentDate { get; set; }

        public int? RelatedOrderId { get; set; }

        public int? RelatedUserId { get; set; }

        public int? ServiceBookingId { get; set; }

        public int? ServiceCarId { get; set; }

        public int? ServiceCarShamId { get; set; }

        public int? ServiceTicketTypeId { get; set; }

        public double? NeedPaymentMoney { get; set; }

        public int? DocMakerUserId { get; set; }

        public int? PeriodId { get; set; }

        [StringLength(255)]
        public string Remark { get; set; }

        public int? CreateBy { get; set; }

        public DateTime? CreateTime { get; set; }

        public int? ModifyBy { get; set; }

        public DateTime? ModifyTime { get; set; }

        public int? MallOrderId { get; set; }

        [StringLength(50)]
        public string RelatedOrderIdBillNo { get; set; }

        public int? MallReturnOrderId { get; set; }

        public int? OrganizationId { get; set; }

        public bool IsSysPublic { get; set; }

        public decimal TotalTaxation { get; set; }

        public decimal TotalPreTaxAmount { get; set; }

        public bool IsInvoice { get; set; }

        public virtual Car Car { get; set; }

        public virtual Customer Customer { get; set; }

        public virtual Organization Organization { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<PartsInventory> PartsInventories { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<PartsInventoryChange> PartsInventoryChanges { get; set; }

        public virtual User User { get; set; }

        public virtual Period Period { get; set; }

        public virtual User User1 { get; set; }

        public virtual User User2 { get; set; }

        public virtual ServiceCar ServiceCar { get; set; }

        public virtual ServiceTicketType ServiceTicketType { get; set; }

        public virtual Supplier Supplier { get; set; }

        public virtual User User3 { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<PartsInventoryRequestDetail> PartsInventoryRequestDetails { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<PartsPaymentHistory> PartsPaymentHistories { get; set; }
    }
}
