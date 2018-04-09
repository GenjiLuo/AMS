namespace AMS.Model
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("MenuTemplateDetail")]
    public partial class MenuTemplateDetail
    {
        public int Id { get; set; }

        public int MenuTemplateId { get; set; }

        public int PermissionsId { get; set; }

        public int? CreateBy { get; set; }

        public DateTime? CreateTime { get; set; }

        public int? ModifyBy { get; set; }

        public DateTime? ModifyTime { get; set; }

        public virtual MenuTemplate MenuTemplate { get; set; }

        public virtual Permission Permission { get; set; }
    }
}
