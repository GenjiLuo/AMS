namespace AMS.Model
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("HealthPushInfo")]
    public partial class HealthPushInfo
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public HealthPushInfo()
        {
            HealthPushMsgRequests = new HashSet<HealthPushMsgRequest>();
        }

        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int Id { get; set; }

        public int RIStatus { get; set; }

        public int RIPushFailTime { get; set; }

        public DateTime? RINextPushTime { get; set; }

        [Required]
        public string RIContent { get; set; }

        public DateTime? RIPushTime { get; set; }

        [Required]
        [StringLength(500)]
        public string RIRemark { get; set; }

        public int OrganizationId { get; set; }

        public int CIStatus { get; set; }

        public int CIPushFailTime { get; set; }

        public DateTime? CINextPushTime { get; set; }

        [Required]
        public string CIContent { get; set; }

        public DateTime? CIPushTime { get; set; }

        [Required]
        [StringLength(500)]
        public string CIRemark { get; set; }

        public virtual ServiceCar ServiceCar { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<HealthPushMsgRequest> HealthPushMsgRequests { get; set; }
    }
}
