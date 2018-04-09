namespace AMS.Model
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("CustomerMessage")]
    public partial class CustomerMessage
    {
        public int Id { get; set; }

        public int OrganizationId { get; set; }

        public int CustomerId { get; set; }

        public int? CarId { get; set; }

        public int MessageType { get; set; }

        public string Message { get; set; }

        public int HasReaded { get; set; }

        public DateTime? ReadTime { get; set; }

        [StringLength(200)]
        public string Remark { get; set; }

        public int? CreateBy { get; set; }

        public DateTime? CreateTime { get; set; }

        public int? ModifyBy { get; set; }

        public DateTime? ModifyTime { get; set; }

        public int? LatestMessageMileage { get; set; }

        public bool? IsSysPublic { get; set; }

        public virtual Customer Customer { get; set; }

        public virtual Organization Organization { get; set; }
    }
}
