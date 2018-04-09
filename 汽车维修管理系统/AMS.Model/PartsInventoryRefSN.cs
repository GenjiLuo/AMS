namespace AMS.Model
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("PartsInventoryRefSN")]
    public partial class PartsInventoryRefSN
    {
        public int Id { get; set; }

        public int PartsInventoryId { get; set; }

        public int PartsUniqueSnId { get; set; }

        public int? CreateBy { get; set; }

        public DateTime? CreateTime { get; set; }

        public int? ModifyBy { get; set; }

        public DateTime? ModifyTime { get; set; }

        public bool Deleted { get; set; }

        public virtual PartsInventory PartsInventory { get; set; }

        public virtual User User { get; set; }

        public virtual User User1 { get; set; }

        public virtual PartsUniqueSN PartsUniqueSN { get; set; }
    }
}
