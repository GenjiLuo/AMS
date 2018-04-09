namespace AMS.Model
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("SystemBillNoKey")]
    public partial class SystemBillNoKey
    {
        public int Id { get; set; }

        public int SystemBillNoId { get; set; }

        public int OrganizationId { get; set; }

        public int UniqueKey { get; set; }

        public DateTime LastUpdateDate { get; set; }

        public bool Deleted { get; set; }

        public int? CreateBy { get; set; }

        public DateTime CreateTime { get; set; }

        public int? ModifyBy { get; set; }

        public DateTime ModifyTime { get; set; }

        public virtual Organization Organization { get; set; }

        public virtual SystemBillNo SystemBillNo { get; set; }
    }
}
