namespace AMS.Model
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("SystemPersistState")]
    public partial class SystemPersistState
    {
        public int Id { get; set; }

        public int UserId { get; set; }

        [Required]
        [StringLength(4000)]
        public string TargetId { get; set; }

        [Required]
        [StringLength(255)]
        public string Area { get; set; }

        [Required]
        [StringLength(255)]
        public string Controller { get; set; }

        [Required]
        [StringLength(255)]
        public string Action { get; set; }

        public string Options { get; set; }

        public int? CreateBy { get; set; }

        public int? ModifyBy { get; set; }

        public DateTime? CreateTime { get; set; }

        public DateTime? ModifyTime { get; set; }

        public virtual User User { get; set; }
    }
}
