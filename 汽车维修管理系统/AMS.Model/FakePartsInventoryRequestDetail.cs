namespace AMS.Model
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("FakePartsInventoryRequestDetail")]
    public partial class FakePartsInventoryRequestDetail
    {
        public int Id { get; set; }

        public int FakePartsInventoryRequestId { get; set; }

        public int PartsDictionaryId { get; set; }

        public decimal? Count { get; set; }

        public decimal? SalePrice { get; set; }

        public decimal? TotalAmount { get; set; }

        public int? CreateBy { get; set; }

        public DateTime? CreateTime { get; set; }

        public int? ModifyBy { get; set; }

        public DateTime? ModifyTime { get; set; }

        public int? ServiceAccountTypeId { get; set; }

        public virtual FakePartsInventoryRequest FakePartsInventoryRequest { get; set; }

        public virtual User User { get; set; }

        public virtual User User1 { get; set; }

        public virtual PartsDictionary PartsDictionary { get; set; }

        public virtual ServiceAccountType ServiceAccountType { get; set; }
    }
}
