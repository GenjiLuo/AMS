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
        public string RepairItemSerNo { get; set; }

        public decimal? WorkHour { get; set; } 
        public decimal? Price { get; set; }
        public Guid? MainOperatorId { get; set; }
        public string MainOperatorName { get; set; }

        public Guid ServiceAccountTypeId { get; set; }
        public string ServiceAccountTypeName { get; set; }
    }
}
