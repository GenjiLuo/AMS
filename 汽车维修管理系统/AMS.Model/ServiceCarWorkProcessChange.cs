namespace AMS.Model
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("ServiceCarWorkProcessChange")]
    public partial class ServiceCarWorkProcessChange
    {
        public int Id { get; set; }

        public int ServiceCarWorkProcessId { get; set; }

        public int Status { get; set; }

        public DateTime StartTime { get; set; }

        public DateTime? EndTime { get; set; }

        [StringLength(255)]
        public string Remark { get; set; }

        public DateTime? CreateTime { get; set; }

        public int? CreateBy { get; set; }

        public DateTime? ModifyTime { get; set; }

        public int? ModifyBy { get; set; }

        public virtual ServiceCarWorkProcess ServiceCarWorkProcess { get; set; }
    }
}
