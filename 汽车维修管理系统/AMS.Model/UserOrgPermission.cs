namespace AMS.Model
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("UserOrgPermission")]
    public partial class UserOrgPermission
    {
        public int Id { get; set; }

        public int UserId { get; set; }

        public int OrgId { get; set; }

        public int? CreateBy { get; set; }

        public DateTime? CreateTime { get; set; }

        public int? ModifyBy { get; set; }

        public DateTime? ModifyTime { get; set; }

        public virtual Organization Organization { get; set; }

        public virtual User User { get; set; }
    }
}
