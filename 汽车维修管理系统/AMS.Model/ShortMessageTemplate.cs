namespace AMS.Model
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("ShortMessageTemplate")]
    public partial class ShortMessageTemplate
    {
        public int Id { get; set; }

        [StringLength(255)]
        public string Name { get; set; }

        public int? TemplateCategory { get; set; }

        public int? HolidayName { get; set; }

        [StringLength(255)]
        public string Content { get; set; }

        public int? tpl_id { get; set; }

        public int? CheckStatus { get; set; }

        [StringLength(255)]
        public string CheckFailReason { get; set; }

        public bool? IsDefault { get; set; }
    }
}
