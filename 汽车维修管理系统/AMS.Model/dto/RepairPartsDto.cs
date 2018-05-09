using System;
using System.ComponentModel.DataAnnotations.Schema;
using AMS.Model.poco;

namespace AMS.Model.dto
{
    public class RepairPartsDto : BaseDto
    {
        public Guid PartsId { get; set; }
        public string PartsCode { get; set; }
        public string PartsName { get; set; }
        public Guid ServiceRepairId { get; set; }
        public int Count { get; set; }
        public decimal Price { get; set; }
    }
}
