using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using AMS.Model.Enum;
using AMS.Model.poco;

namespace AMS.Model.dto
{
    public class ServiceRepairDto : BaseDto
    {
        public ServiceRepairDto()
        {
            ServiceRepairItem = new List<ServiceRepairItemDto>();
            EstimateRepairParts = new List<EstimateRepairPartsDto>();
            RepairParts=new List<RepairPartsDto>();
        }
        public Guid CarId { get; set; }
        public string CarPlateNum{ get; set; }

        public Guid? ServiceBookingId { get; set; }

        public ServiceRepairState ServiceRepairState { get; set; }
        public ServiceWashState ServiceWashState { get; set; }
        public DateTime? ServiceDateTime { get; set; }
        public DateTime? EstimateLeaveTime { get; set; }
        public DateTime? LeaveTime { get; set; }

        public ServiceType ServiceType { get; set; }

        public Guid ServiceAdvisorId { get; set; }
        public string ServiceAdvisorName { get; set; }

        public string ContactName { get; set; }
        public string ContactPhone { get; set; }
        public string RepairDescription { get; set; }
        public string CustomerDescription { get; set; }

        public  List<ServiceRepairItemDto> ServiceRepairItem { get; set; }
        public  List<EstimateRepairPartsDto> EstimateRepairParts { get; set; }
        public  List<RepairPartsDto> RepairParts { get; set; }
    }
}
