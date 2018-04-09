namespace AMS.Model
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("SMSVCodeSession")]
    public partial class SMSVCodeSession
    {
        public int Id { get; set; }

        public DateTime SendTime { get; set; }

        public DateTime ExpireTime { get; set; }

        [Required]
        [StringLength(500)]
        public string VCode { get; set; }

        [Required]
        [StringLength(255)]
        public string Phone { get; set; }
    }
}
