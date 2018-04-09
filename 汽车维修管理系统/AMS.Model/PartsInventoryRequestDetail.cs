namespace AMS.Model
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("PartsInventoryRequestDetail")]
    public partial class PartsInventoryRequestDetail
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public PartsInventoryRequestDetail()
        {
            PartsInventoryChangeRefSNs = new HashSet<PartsInventoryChangeRefSN>();
        }

        public int Id { get; set; }

        public int PartsInventoryRequestId { get; set; }

        public int PartsDictionaryId { get; set; }

        public int? PartsInventoryId { get; set; }

        public int? SupplierId { get; set; }

        public int? SourceWarehouseId { get; set; }

        public int? SourceWarehouseAreaId { get; set; }

        public int? TargetWarehouseId { get; set; }

        public int? TargetWarehouseAreaId { get; set; }

        public double? Count { get; set; }

        public double? ActualCount { get; set; }

        public double? SupplierPrice { get; set; }

        public double? SalePrice { get; set; }

        public double? TransferPrice { get; set; }

        public double? SettlementPrice { get; set; }

        public double? LimitedPrice { get; set; }

        public double? WholesalePrice { get; set; }

        public double? ReturnGoodsUnitPrice { get; set; }

        public int? PaymentTypeId { get; set; }

        [StringLength(200)]
        public string GlobalId { get; set; }

        public int? PeriodId { get; set; }

        [StringLength(255)]
        public string Remark { get; set; }

        public int? CreateBy { get; set; }

        public DateTime? CreateTime { get; set; }

        public int? ModifyBy { get; set; }

        public DateTime? ModifyTime { get; set; }

        public int? MallPartId { get; set; }

        public double? BuyingPrice { get; set; }

        public double? Taxation { get; set; }

        public int? RelatedOrderId { get; set; }

        public virtual PartsDictionary PartsDictionary { get; set; }

        public virtual PartsInventory PartsInventory { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<PartsInventoryChangeRefSN> PartsInventoryChangeRefSNs { get; set; }

        public virtual PartsInventoryRequest PartsInventoryRequest { get; set; }

        public virtual WarehouseZone WarehouseZone { get; set; }

        public virtual WarehouseZone WarehouseZone1 { get; set; }

        public virtual ServiceAccountType ServiceAccountType { get; set; }

        public virtual Period Period { get; set; }

        public virtual Warehouse Warehouse { get; set; }

        public virtual Supplier Supplier { get; set; }

        public virtual Warehouse Warehouse1 { get; set; }
    }
}
