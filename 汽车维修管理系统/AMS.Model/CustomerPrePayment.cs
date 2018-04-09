namespace AMS.Model
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("CustomerPrePayment")]
    public partial class CustomerPrePayment
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public CustomerPrePayment()
        {
            CustomerPrePaymentDetails = new HashSet<CustomerPrePaymentDetail>();
        }

        public int Id { get; set; }

        public int OrganizationId { get; set; }

        public int CustomerId { get; set; }

        public decimal? TotalCost { get; set; }

        public decimal? UsedCost { get; set; }

        public decimal? UsableCost { get; set; }

        public int? CreateBy { get; set; }

        public DateTime? CreateTime { get; set; }

        public int? ModifyBy { get; set; }

        public DateTime? ModifyTime { get; set; }

        public bool? IsSysPublic { get; set; }

        public virtual Customer Customer { get; set; }

        public virtual Organization Organization { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<CustomerPrePaymentDetail> CustomerPrePaymentDetails { get; set; }
    }
}
