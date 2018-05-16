using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using AMS.Model.Enum;
using AMS.Model.poco;

namespace AMS.Model.dto
{
    public class ServiceBookingDto : BaseDto
    {
        public ServiceBookingDto()
        {
            EstimateRepairParts = new List<EstimateRepairPartsDto>();
            ServiceRepairItem=new List<ServiceRepairItemDto>();
        }
        public string BillNo { get; set; }
        public DateTime BookingCreateTime { get; set; }
        public DateTime ServiceRepairTime { get; set; }
        public Guid CarId { get; set; }
        public ServiceBookingState ServiceBookingState { get; set; }

        public string CarPlateNum { get; set; }

        public string ContactName { get; set; }
        public string ContactPhone { get; set; }
        public string ContactAddress { get; set; }
        public Guid ServiceAdvisorId { get; set; }
        public string ServiceAdvisorName { get; set; }

        public Guid RepairTypeId { get; set; }
        public string RepairTypeName { get; set; }
        public string CustomerDescription { get; set; }
        public string RepairDescription { get; set; }
        public string Remark { get; set; }

        public  List<EstimateRepairPartsDto> EstimateRepairParts { get; set; }
        public  List<ServiceRepairItemDto> ServiceRepairItem { get; set; }
    }
}
