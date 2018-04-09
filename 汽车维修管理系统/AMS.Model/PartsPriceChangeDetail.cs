namespace AMS.Model
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("PartsPriceChangeDetail")]
    public partial class PartsPriceChangeDetail
    {
        public int Id { get; set; }

        public int? PartsPriceChangeId { get; set; }

        public int? PartsDictionaryId { get; set; }

        public double? SupplierPrice { get; set; }

        public double? NewSupplierPrice { get; set; }

        public double? WholesalePrice { get; set; }

        public double? NewWholesalePrice { get; set; }

        public double? SalePrice { get; set; }

        public double? NewSalePrice { get; set; }

        public double? SettlementPrice { get; set; }

        public double? NewSettlementPrice { get; set; }

        public double? TransferPrice { get; set; }

        public double? NewTransferPrice { get; set; }

        public int? CreateBy { get; set; }

        public DateTime? CreateTime { get; set; }

        public int? ModifyBy { get; set; }

        public DateTime? ModifyTime { get; set; }

        public virtual PartsDictionary PartsDictionary { get; set; }

        public virtual PartsPriceChange PartsPriceChange { get; set; }
    }
}
