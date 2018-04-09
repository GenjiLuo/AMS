namespace AMS.Model
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class SystemPermission
    {
        public int Id { get; set; }

        public int PermissionId { get; set; }

        [Required]
        [StringLength(255)]
        public string PermissionName { get; set; }

        public DateTime? CreateTime { get; set; }

        public DateTime? ModifyTime { get; set; }

        public virtual Permission Permission { get; set; }
    }
}
