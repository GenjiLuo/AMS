using System;
using System.ComponentModel.DataAnnotations.Schema;
using AMS.Model.poco;

namespace AMS.Model.dto
{
    public class EstimateRepairPartsDto : BaseDto
    {
        public Guid PartsId { get; set; }
        public string PartsCode { get; set; }
        public string PartsName { get; set; }
        public Guid? ServiceRepairId { get; set; }
        public Guid ServiceBookingId { get; set; }
        public Guid ServiceAccountTypeId { get; set; }
        public string ServiceAccountTypeName { get; set; }
        public int Count { get; set; }
        public int MaxCount { get; set; }
        public decimal Price { get; set; }
        public string WarehouseName { get; set; }
    }
}
