namespace AMS.Model
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("HomeQuickLink")]
    public partial class HomeQuickLink
    {
        public int Id { get; set; }

        [Required]
        [StringLength(200)]
        public string Text { get; set; }

        [StringLength(200)]
        public string Url { get; set; }

        [StringLength(200)]
        public string IconSrc { get; set; }

        public int? OrderIndex { get; set; }

        public int HomeUserConfigId { get; set; }

        public int? CreateBy { get; set; }

        public DateTime? CreateTime { get; set; }

        public int? ModifyBy { get; set; }

        public DateTime? ModifyTime { get; set; }

        public virtual HomeUserConfig HomeUserConfig { get; set; }
    }
}
