namespace AMS.Model
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("ReportTrdx")]
    public partial class ReportTrdx
    {
        public int Id { get; set; }

        [StringLength(200)]
        public string ReportType { get; set; }

        [StringLength(100)]
        public string FileName { get; set; }

        [StringLength(200)]
        public string FilePath { get; set; }

        public bool? IsSystem { get; set; }

        public bool? IsDefault { get; set; }

        public int? CreateBy { get; set; }

        public DateTime? CreateTime { get; set; }

        [StringLength(255)]
        public string Remark { get; set; }

        public int? ModifyBy { get; set; }

        public DateTime? ModifyTime { get; set; }
    }
}
