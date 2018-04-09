namespace AMS.Model
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("MessageStack")]
    public partial class MessageStack
    {
        public int Id { get; set; }

        [Required]
        [StringLength(4000)]
        public string Message { get; set; }

        [StringLength(255)]
        public string Remark { get; set; }

        public DateTime? CreateTime { get; set; }

        public DateTime? ModifyTime { get; set; }

        public int Status { get; set; }

        public int FailTimes { get; set; }
    }
}
