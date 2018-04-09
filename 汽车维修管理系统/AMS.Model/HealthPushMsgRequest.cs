namespace AMS.Model
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("HealthPushMsgRequest")]
    public partial class HealthPushMsgRequest
    {
        public int Id { get; set; }

        public int HealthPushId { get; set; }

        [Required]
        public string Content { get; set; }

        public int Status { get; set; }

        public DateTime? RequestTime { get; set; }

        [Required]
        [StringLength(500)]
        public string Remark { get; set; }

        public int OrganizationId { get; set; }

        public int RequestType { get; set; }

        public virtual HealthPushInfo HealthPushInfo { get; set; }
    }
}
