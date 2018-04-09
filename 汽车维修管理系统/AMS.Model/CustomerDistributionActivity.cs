namespace AMS.Model
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("CustomerDistributionActivity")]
    public partial class CustomerDistributionActivity
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public CustomerDistributionActivity()
        {
            ConsumerExpensesRecords = new HashSet<ConsumerExpensesRecord>();
            ConsumerRebatesRecords = new HashSet<ConsumerRebatesRecord>();
            CustomerDistributionActivityChanges = new HashSet<CustomerDistributionActivityChange>();
            CustomerDistributionActivityDetails = new HashSet<CustomerDistributionActivityDetail>();
        }

        public int Id { get; set; }

        [StringLength(255)]
        public string Title { get; set; }

        [Required]
        [StringLength(500)]
        public string Intro { get; set; }

        [Required]
        [StringLength(255)]
        public string Logo { get; set; }

        [Required]
        [StringLength(255)]
        public string RegisterPic { get; set; }

        public string Content { get; set; }

        public DateTime StartTime { get; set; }

        public DateTime EndTime { get; set; }

        public bool IsLevel2 { get; set; }

        public int Status { get; set; }

        [StringLength(255)]
        public string Remark { get; set; }

        public int? CreateBy { get; set; }

        public DateTime? CreateTime { get; set; }

        public int? ModifyBy { get; set; }

        public DateTime? ModifyTime { get; set; }

        public bool? IsSysPublic { get; set; }

        public int? OrganizationId { get; set; }

        public int? LogoId { get; set; }

        public int? RegisterPicId { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<ConsumerExpensesRecord> ConsumerExpensesRecords { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<ConsumerRebatesRecord> ConsumerRebatesRecords { get; set; }

        public virtual Organization Organization { get; set; }

        public virtual FileResource FileResource { get; set; }

        public virtual FileResource FileResource1 { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<CustomerDistributionActivityChange> CustomerDistributionActivityChanges { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<CustomerDistributionActivityDetail> CustomerDistributionActivityDetails { get; set; }
    }
}
