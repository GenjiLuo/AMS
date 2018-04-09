namespace AMS.Model
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("PartsInventoryWarning")]
    public partial class PartsInventoryWarning
    {
        public int Id { get; set; }

        public int PartsDictionaryId { get; set; }

        public int WarehouseId { get; set; }

        public decimal MinCount { get; set; }

        public decimal MaxCount { get; set; }

        public int? CreateBy { get; set; }

        public DateTime? CreateTime { get; set; }

        public int? ModifyBy { get; set; }

        public DateTime? ModifyTime { get; set; }

        public bool? IsSysPublic { get; set; }

        public int? OrganizationId { get; set; }

        public virtual Organization Organization { get; set; }

        public virtual PartsDictionary PartsDictionary { get; set; }

        public virtual Warehouse Warehouse { get; set; }
    }
}
