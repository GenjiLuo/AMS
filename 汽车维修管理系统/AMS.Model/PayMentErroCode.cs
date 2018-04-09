namespace AMS.Model
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("PayMentErroCode")]
    public partial class PayMentErroCode
    {
        public int Id { get; set; }

        [Required]
        [StringLength(255)]
        public string ErrorCode { get; set; }

        [Required]
        [StringLength(500)]
        public string Describe { get; set; }

        [Required]
        [StringLength(255)]
        public string Reason { get; set; }

        [Required]
        [StringLength(255)]
        public string Solution { get; set; }
    }
}
