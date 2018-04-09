namespace AMS.Model
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class PartsInventoryImport
    {
        public int Id { get; set; }

        [Required]
        [StringLength(200)]
        public string ShopName { get; set; }

        [Required]
        [StringLength(200)]
        public string WarehouseName { get; set; }

        [Required]
        [StringLength(200)]
        public string PartsSerialNo { get; set; }

        [Required]
        [StringLength(200)]
        public string PartsName { get; set; }

        [Required]
        [StringLength(200)]
        public string SupplierName { get; set; }

        public double Count { get; set; }

        public double SupplierPrice { get; set; }

        [StringLength(200)]
        public string WarehouzeZoneName { get; set; }

        [Required]
        [StringLength(200)]
        public string Brand { get; set; }

        [Required]
        [StringLength(200)]
        public string Model { get; set; }

        [Required]
        [StringLength(200)]
        public string Unit { get; set; }

        [Required]
        [StringLength(200)]
        public string PartType { get; set; }

        [Required]
        [StringLength(1000)]
        public string CarTypes { get; set; }

        public double SalePrice { get; set; }
    }
}
