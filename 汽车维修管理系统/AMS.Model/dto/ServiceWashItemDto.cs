using System;
using System.ComponentModel.DataAnnotations.Schema;
using AMS.Model.poco;

namespace AMS.Model.dto
{
    public class ServiceWashItemDto : BaseDto
    {
        public Guid WashItemId { get; set; }
        public string WashItemName { get; set; }
        public decimal WashItemPrice { get; set; }

        public Guid ServiceRepairId { get; set; }
        public  ServiceRepairDto ServiceRepair { get; set; }
    }
}
