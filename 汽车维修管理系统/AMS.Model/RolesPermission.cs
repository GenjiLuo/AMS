namespace AMS.Model
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class RolesPermission
    {
        public int Id { get; set; }

        public int? Role_id { get; set; }

        public int? Permission_id { get; set; }

        public int? RoleRecord_Id { get; set; }

        public int? ParentId { get; set; }

        public bool? IsAuthorized { get; set; }

        public int? AccessLevel { get; set; }

        public int? CreateBy { get; set; }

        public int? ModifyBy { get; set; }

        public DateTime? CreateTime { get; set; }

        public DateTime? ModifyTime { get; set; }

        public virtual Permission Permission { get; set; }

        public virtual Role Role { get; set; }
    }
}
