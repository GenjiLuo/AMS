namespace AMS.Model
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("PartsInventoryHistory")]
    public partial class PartsInventoryHistory
    {
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int Id { get; set; }

        public int? WarehouseId { get; set; }

        public DateTime? Date { get; set; }

        public double? InventoryTotal { get; set; }

        public double? InventoryCount { get; set; }

        public double? InventoryAverage { get; set; }

        public double? SalesIncome { get; set; }

        public double? SalesCount { get; set; }

        public int? CreateBy { get; set; }

        public DateTime? CreateTime { get; set; }

        public int? ModifyBy { get; set; }

        public DateTime? ModifyTime { get; set; }

        public int? PeriodId { get; set; }

        public virtual Warehouse Warehouse { get; set; }
    }
}
