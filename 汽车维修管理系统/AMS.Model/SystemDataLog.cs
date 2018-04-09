namespace AMS.Model
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("SystemDataLog")]
    public partial class SystemDataLog
    {
        public int Id { get; set; }

        public int UserId { get; set; }

        public int OrganizationId { get; set; }

        public int OperationType { get; set; }

        [Required]
        public string OriginalValues { get; set; }

        [Required]
        public string CurrentValues { get; set; }

        public bool Deleted { get; set; }

        public int? CreateBy { get; set; }

        public DateTime? CreateDate { get; set; }

        public int? ModifyBy { get; set; }

        public DateTime? ModifyDate { get; set; }

        public DateTime? CreateTime { get; set; }

        public DateTime? ModifyTime { get; set; }

        public virtual Organization Organization { get; set; }

        public virtual User User { get; set; }

        public virtual User User1 { get; set; }
    }
}
