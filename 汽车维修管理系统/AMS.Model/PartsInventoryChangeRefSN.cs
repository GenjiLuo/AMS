namespace AMS.Model
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("PartsInventoryChangeRefSN")]
    public partial class PartsInventoryChangeRefSN
    {
        public int Id { get; set; }

        public int PartsInventoryChangeId { get; set; }

        public int PartsInventoryRequestDetailId { get; set; }

        public int? PartsUniqueSnId { get; set; }

        public bool IsIn { get; set; }

        public int? CreateBy { get; set; }

        public DateTime? CreateTime { get; set; }

        public int? ModifyBy { get; set; }

        public DateTime? ModifyTime { get; set; }

        public virtual PartsInventoryChange PartsInventoryChange { get; set; }

        public virtual User User { get; set; }

        public virtual User User1 { get; set; }

        public virtual PartsInventoryRequestDetail PartsInventoryRequestDetail { get; set; }

        public virtual PartsUniqueSN PartsUniqueSN { get; set; }
    }
}
