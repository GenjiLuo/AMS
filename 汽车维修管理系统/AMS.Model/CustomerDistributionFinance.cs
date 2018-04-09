namespace AMS.Model
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("CustomerDistributionFinance")]
    public partial class CustomerDistributionFinance
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public CustomerDistributionFinance()
        {
            ConsumerExpensesRecords = new HashSet<ConsumerExpensesRecord>();
            ConsumerRebatesRecords = new HashSet<ConsumerRebatesRecord>();
            CustomerCashRequests = new HashSet<CustomerCashRequest>();
        }

        public int Id { get; set; }

        public int IEType { get; set; }

        [StringLength(255)]
        public string Description { get; set; }

        public decimal Amount { get; set; }

        public DateTime OperateTime { get; set; }

        public int? CreateBy { get; set; }

        public DateTime? CreateTime { get; set; }

        public int? ModifyBy { get; set; }

        public DateTime? ModifyTime { get; set; }

        [Required]
        [StringLength(255)]
        public string Title { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<ConsumerExpensesRecord> ConsumerExpensesRecords { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<ConsumerRebatesRecord> ConsumerRebatesRecords { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<CustomerCashRequest> CustomerCashRequests { get; set; }
    }
}
