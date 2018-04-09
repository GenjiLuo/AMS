namespace AMS.Model
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("CarPrefix")]
    public partial class CarPrefix
    {
        public int Id { get; set; }

        public int UserId { get; set; }

        [Required]
        [StringLength(10)]
        public string Cityprefix { get; set; }

        [Required]
        [StringLength(10)]
        public string Letterprefix { get; set; }

        public bool IsDefault { get; set; }

        public int CreateBy { get; set; }

        public DateTime CreateTime { get; set; }

        public int ModifyBy { get; set; }

        public DateTime ModifyTime { get; set; }

        public virtual User User { get; set; }
    }
}
