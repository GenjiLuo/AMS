namespace AMS.Model
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("SMSAutoSend")]
    public partial class SMSAutoSend
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public SMSAutoSend()
        {
            ShortMessageSends = new HashSet<ShortMessageSend>();
        }

        public int Id { get; set; }

        public int CustomerId { get; set; }

        public int? CarId { get; set; }

        [Required]
        [StringLength(255)]
        public string Extend { get; set; }

        [Required]
        [StringLength(255)]
        public string SmsType { get; set; }

        [Required]
        [StringLength(255)]
        public string SmsFreeSignName { get; set; }

        [Required]
        [StringLength(255)]
        public string SmsParam { get; set; }

        [Required]
        [StringLength(255)]
        public string RecNum { get; set; }

        [Required]
        [StringLength(255)]
        public string SmsTemplatedCode { get; set; }

        public bool IsSend { get; set; }

        public int OrganizationId { get; set; }

        public int SendCount { get; set; }

        public DateTime CreateDate { get; set; }

        public decimal? LatestMessageMileage { get; set; }

        public virtual Car Car { get; set; }

        public virtual Customer Customer { get; set; }

        public virtual Organization Organization { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<ShortMessageSend> ShortMessageSends { get; set; }
    }
}
