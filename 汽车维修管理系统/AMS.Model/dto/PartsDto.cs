using System;
using System.ComponentModel.DataAnnotations.Schema;
using AMS.Model.poco;

namespace AMS.Model.dto
{
    public class PartsDto : BaseDto
    {
        public Guid PartsDictionaryId { get; set; }
        public string PartsCode { get; set; }
        public string BrandName { get; set; }
        public string PartsDictionaryName { get; set; }

        public decimal Price { get; set; }
        public int Count { get; set; }

        public Guid PartsBuyId { get; set; }
        public Guid? WarehouseId { get; set; }
    }
}
