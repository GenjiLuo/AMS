namespace AMS.Model
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("OrgModuleItem")]
    public partial class OrgModuleItem
    {
        public int Id { get; set; }

        public int OrganizationId { get; set; }

        [StringLength(255)]
        public string Remark { get; set; }

        public int? CreateBy { get; set; }

        public DateTime? CreateTime { get; set; }

        public int? ModifyBy { get; set; }

        public DateTime? ModifyTime { get; set; }

        public int? PermissionsId { get; set; }

        public virtual Organization Organization { get; set; }

        public virtual Permission Permission { get; set; }
    }
}
