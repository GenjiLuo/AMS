using System;
using System.ComponentModel.DataAnnotations.Schema;
using AMS.Model.poco;

namespace AMS.Model.dto
{
    public class PartsInDto : BaseDto
    {
        public Guid PartsBuyId { get; set; }
        public Guid PartsDictionaryId { get; set; }
        public Guid? PartsId { get; set; }
        public string PartsName { get; set; }
        public string PartsCode { get; set; }
        public string BrandName { get; set; }
        public Guid WarehouseId { get; set; }
        public string WarehouseName { get; set; }
        public int Count { get; set; }
        public decimal SupplierPrice { get; set; }
    }
}
