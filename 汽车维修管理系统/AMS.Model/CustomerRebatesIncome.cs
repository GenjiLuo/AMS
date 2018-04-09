namespace AMS.Model
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("CustomerRebatesIncome")]
    public partial class CustomerRebatesIncome
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public CustomerRebatesIncome()
        {
            ConsumerExpensesRecords = new HashSet<ConsumerExpensesRecord>();
            ConsumerRebatesRecords = new HashSet<ConsumerRebatesRecord>();
            CustomerCashRequests = new HashSet<CustomerCashRequest>();
        }

        public int Id { get; set; }

        public int CustomerId { get; set; }

        public decimal TotalRebatesAmount { get; set; }

        public decimal RaisedIncomeAmount { get; set; }

        public decimal CashingAmount { get; set; }

        public bool? IsSysPublic { get; set; }

        public int? OrganizationId { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<ConsumerExpensesRecord> ConsumerExpensesRecords { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<ConsumerRebatesRecord> ConsumerRebatesRecords { get; set; }

        public virtual Customer Customer { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<CustomerCashRequest> CustomerCashRequests { get; set; }

        public virtual Organization Organization { get; set; }
    }
}
