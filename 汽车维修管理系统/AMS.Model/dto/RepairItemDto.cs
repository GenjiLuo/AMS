using System;
using System.ComponentModel.DataAnnotations.Schema;
using AMS.Model.poco;

namespace AMS.Model.dto
{
    public class RepairItemDto : BaseDto
    {
        public RepairItemDto()
        {
        }
        public string SerNum { get; set; }
        public float WorkHour { get; set; }
        public decimal Price { get; set; }
        public bool IsHot { get; set; }
        public Guid RepairItemTypeId { get; set; }
        public string RepairItemTypeName { get; set; }
    }
}
