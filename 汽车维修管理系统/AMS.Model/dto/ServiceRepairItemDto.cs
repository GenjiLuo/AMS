using System;
using System.ComponentModel.DataAnnotations.Schema;
using AMS.Model.poco;

namespace AMS.Model.dto
{
    public class ServiceRepairItemDto : BaseDto
    {
        public Guid? ServiceRepairId { get; set; }
        public Guid? ServiceBookingId { get; set; }
        public Guid RepairItemId { get; set; }
        public string RepairItemName { get; set; }

        public float? WordHour { get; set; } 
        public decimal? Price { get; set; }
        public Guid? MainOperatorId { get; set; }
        public string MainOperatorName { get; set; }
    }
}
