namespace AMS.Model
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("PartsInventory")]
    public partial class PartsInventory
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public PartsInventory()
        {
            PartsInventoryRefSNs = new HashSet<PartsInventoryRefSN>();
            PartsInventoryRequestDetails = new HashSet<PartsInventoryRequestDetail>();
        }

        public int Id { get; set; }

        public int? PartsDictionaryId { get; set; }

        public int? WarehouseId { get; set; }

        public int? WarehouseAreaId { get; set; }

        public int? SupplierId { get; set; }

        public double? Count { get; set; }

        public double? TransferPrice { get; set; }

        public double? LimitedPrice { get; set; }

        public double SupplierPrice { get; set; }

        public double? WholesalePrice { get; set; }

        public double? SalePrice { get; set; }

        public double? SettlementPrice { get; set; }

        [StringLength(255)]
        public string Period { get; set; }

        [StringLength(200)]
        public string GlobalId { get; set; }

        public int? CreateBy { get; set; }

        public DateTime? CreateTime { get; set; }

        public int? ModifyBy { get; set; }

        public DateTime? ModifyTime { get; set; }

        public int? RelatedMallRequestId { get; set; }

        public int? MallPartId { get; set; }

        public virtual PartsDictionary PartsDictionary { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<PartsInventoryRefSN> PartsInventoryRefSNs { get; set; }

        public virtual PartsInventoryRequest PartsInventoryRequest { get; set; }

        public virtual WarehouseZone WarehouseZone { get; set; }

        public virtual Supplier Supplier { get; set; }

        public virtual Warehouse Warehouse { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<PartsInventoryRequestDetail> PartsInventoryRequestDetails { get; set; }
    }
}
