namespace AMS.Model
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("ServiceCredit")]
    public partial class ServiceCredit
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public ServiceCredit()
        {
            ServicePayCashes = new HashSet<ServicePayCash>();
        }

        public int Id { get; set; }

        public int? ServiceAccountId { get; set; }

        public int? CustomerId { get; set; }

        public decimal? CreditPrice { get; set; }

        public decimal? LaborHoursPrice { get; set; }

        [StringLength(200)]
        public string Remark { get; set; }

        public DateTime? CreateTime { get; set; }

        public int? CreateBy { get; set; }

        public DateTime? ModifyTime { get; set; }

        public int? ModifyBy { get; set; }

        public virtual Customer Customer { get; set; }

        public virtual ServiceAccount ServiceAccount { get; set; }

        public virtual User User { get; set; }

        public virtual User User1 { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<ServicePayCash> ServicePayCashes { get; set; }
    }
}
