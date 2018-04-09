namespace AMS.Model
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("PeriodInventoryHistory")]
    public partial class PeriodInventoryHistory
    {
        public int Id { get; set; }

        public int? PartsDictionaryId { get; set; }

        public int? PeriodId { get; set; }

        public int? CreateBy { get; set; }

        public DateTime? CreateTime { get; set; }

        public int? ModifyBy { get; set; }

        public DateTime? ModifyTime { get; set; }

        public double? EndCount { get; set; }

        public double? StartCount { get; set; }

        public double? BuyInCount { get; set; }

        public double? OtherInCount { get; set; }

        public double? BuyReturnCount { get; set; }

        public double? SaleOutCount { get; set; }

        public double? SaleReturnCount { get; set; }

        public double? OtherOutCount { get; set; }

        public double? RepairOutCount { get; set; }

        public double? RepairReturnCount { get; set; }

        public virtual PartsDictionary PartsDictionary { get; set; }

        public virtual Period Period { get; set; }
    }
}
