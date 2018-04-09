namespace AMS.Model
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("CustomerDistributionActivityChange")]
    public partial class CustomerDistributionActivityChange
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public CustomerDistributionActivityChange()
        {
            CustomerDistributionActivityChangeDetails = new HashSet<CustomerDistributionActivityChangeDetail>();
        }

        public int Id { get; set; }

        public int CustomerDistributionActivityId { get; set; }

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

        public int? LogoId { get; set; }

        public int? RegisterPicId { get; set; }

        public virtual CustomerDistributionActivity CustomerDistributionActivity { get; set; }

        public virtual FileResource FileResource { get; set; }

        public virtual FileResource FileResource1 { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<CustomerDistributionActivityChangeDetail> CustomerDistributionActivityChangeDetails { get; set; }
    }
}
