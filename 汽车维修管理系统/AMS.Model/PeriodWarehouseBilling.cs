namespace AMS.Model
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class PeriodWarehouseBilling
    {
        public int Id { get; set; }

        public int? PeriodId { get; set; }

        [StringLength(20)]
        public string Type { get; set; }

        public double? Total { get; set; }

        public double? Paid { get; set; }

        public int? SupplierId { get; set; }

        public int? CustomerId { get; set; }

        public int? ShopId { get; set; }

        public int? SourceShopId { get; set; }

        public int? TargetShopId { get; set; }

        public int? CreateBy { get; set; }

        public DateTime? CreateTime { get; set; }

        public int? ModifyBy { get; set; }

        public DateTime? ModifyTime { get; set; }

        public bool? IsArrears { get; set; }

        public virtual Customer Customer { get; set; }

        public virtual Period Period { get; set; }

        public virtual Shop Shop { get; set; }

        public virtual Shop Shop1 { get; set; }

        public virtual Supplier Supplier { get; set; }

        public virtual Shop Shop2 { get; set; }
    }
}
