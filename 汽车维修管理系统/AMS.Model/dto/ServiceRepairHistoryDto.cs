using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using AMS.Model.Enum;
using AMS.Model.poco;

namespace AMS.Model.dto
{
    public class ServiceRepairHistoryDto : BaseDto
    {
        public ServiceRepairHistoryDto()
        {
            ServiceRepairItem = new List<ServiceRepairItemDto>();
            EstimateRepairParts = new List<EstimateRepairPartsDto>();
            RepairParts=new List<RepairPartsDto>();
            ServiceWashItems=new List<ServiceWashItemDto>();
        }
        public Guid CarId { get; set; }
        public string BillNo { get; set; }
        public string CarPlateNum{ get; set; }
        public string CarVIN { get; set; }
        public string CustomerName { get; set; }
        public string CustomerPhone { get; set; }
        public string CurrentMileage { get; set; }

        public ServiceRepairState? ServiceRepairState { get; set; }
        public ServiceWashState? ServiceWashState { get; set; }
        public DateTime? ServiceDateTime { get; set; }
        public DateTime? LeaveTime { get; set; }
        public ServiceType? ServiceType { get; set; }

        public Guid? ServiceAdvisorId { get; set; }
        public string ServiceAdvisorName { get; set; }

        public string ContactName { get; set; }
        public string ContactPhone { get; set; }
        public string RepairDescription { get; set; }
        public string CustomerDescription { get; set; }

        public decimal TotalRepairItemMoney
        {
            get
            {
                var totalMoney = new decimal(0);
                foreach (var repairItem in ServiceRepairItem)
                {
                    if (repairItem.Price.HasValue && repairItem.WorkHour.HasValue)
                    {
                        totalMoney += repairItem.Price.Value * repairItem.WorkHour.Value;
                    }
                }
                return totalMoney;
            }
        }

        public decimal TotalPartsMoney
        {
            get
            {
                var totalMoney = new decimal(0);
                foreach (var parts in RepairParts)
                {
                    totalMoney += parts.Price * parts.Count;
                }
                return totalMoney;
            }
        }

        public decimal TotalMoney
        {
            get
            {
                var totalMoney = new decimal(0);
                foreach (var repairItem in ServiceRepairItem)
                {
                    if (repairItem.Price.HasValue && repairItem.WorkHour.HasValue)
                    {
                        totalMoney += repairItem.Price.Value * repairItem.WorkHour.Value;
                    }
                }

                foreach (var parts in RepairParts)
                {
                    totalMoney += parts.Price * parts.Count;
                }
                return totalMoney;
            }
        }

        public  List<ServiceRepairItemDto> ServiceRepairItem { get; set; }
        public  List<EstimateRepairPartsDto> EstimateRepairParts { get; set; }
        public  List<RepairPartsDto> RepairParts { get; set; }
        public List<ServiceWashItemDto> ServiceWashItems { get; set; }
    }
}
