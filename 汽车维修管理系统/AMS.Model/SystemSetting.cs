namespace AMS.Model
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class SystemSetting
    {
        [Key]
        [Column(Order = 0)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int OrganizationId { get; set; }

        [Key]
        [Column(Order = 1)]
        [StringLength(255)]
        public string Key { get; set; }

        [Required]
        [StringLength(4000)]
        public string Value { get; set; }

        public int CSharpTypeCode { get; set; }

        [Required]
        [StringLength(32)]
        public string DbTypeCode { get; set; }

        public int? CreateBy { get; set; }

        public DateTime? CreateTime { get; set; }

        public int? ModifyBy { get; set; }

        public DateTime? ModifyTime { get; set; }

        public virtual Organization Organization { get; set; }
    }
}
