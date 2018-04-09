namespace AMS.Model
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("PartsInventoryChange")]
    public partial class PartsInventoryChange
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public PartsInventoryChange()
        {
            PartsInventoryChangeRefSNs = new HashSet<PartsInventoryChangeRefSN>();
        }

        [StringLength(255)]
        public string VoucherNo { get; set; }

        public int? PartsDictionaryId { get; set; }

        [StringLength(255)]
        public string Operation { get; set; }

        public double? Count { get; set; }

        public DateTime? Date { get; set; }

        [StringLength(255)]
        public string SourceWarehouseArea { get; set; }

        [StringLength(255)]
        public string TargetWarehouseArea { get; set; }

        public double? SupplierPrice { get; set; }

        public double? CostPrice { get; set; }

        public double? ReturnGoodsUnitPrice { get; set; }

        [StringLength(255)]
        public string PaymentType { get; set; }

        public bool? IsIn { get; set; }

        public int? PartsInventoryRequestId { get; set; }

        public int? RelatedCustomerId { get; set; }

        public int? RelatedCarId { get; set; }

        public int? SupplierId { get; set; }

        public int? ServiceCarId { get; set; }

        public int? SourceWarehouseId { get; set; }

        public int? TargetWarehouseId { get; set; }

        public int? OperatorId { get; set; }

        public int? CreateBy { get; set; }

        public DateTime? CreateTime { get; set; }

        public int? ModifyBy { get; set; }

        public DateTime? ModifyTime { get; set; }

        public int Id { get; set; }

        [StringLength(200)]
        public string GlobalId { get; set; }

        public int? PeriodId { get; set; }

        public int? MallPartId { get; set; }

        public virtual PartsDictionary PartsDictionary { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<PartsInventoryChangeRefSN> PartsInventoryChangeRefSNs { get; set; }

        public virtual User User { get; set; }

        public virtual PartsInventoryRequest PartsInventoryRequest { get; set; }

        public virtual Period Period { get; set; }

        public virtual Warehouse Warehouse { get; set; }

        public virtual Supplier Supplier { get; set; }

        public virtual Warehouse Warehouse1 { get; set; }
    }
}
