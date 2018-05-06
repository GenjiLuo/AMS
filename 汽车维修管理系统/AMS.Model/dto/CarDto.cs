using System;
using System.Collections.Generic;
using AMS.Model.poco;

namespace AMS.Model.dto
{
    public class CarDto : BaseDto
    {
        public CarDto()
        {
        }
        public Guid CustomerId { get; set; }
        public string CustomerName { get; set; }
        public string CustomerPhone { get; set; }

        public string CarOwnerName { get; set; }
        public string CarOwnerPhone { get; set; }

        public string VIN { get; set; }
        public string PlateNum { get; set; }

        public Guid ModelId { get; set; }
        public string BrandName { get; set; }
        public string SeriesName { get; set; }
        public string ModelName { get; set; }
        public decimal Price { get; set; }
        public string FullName { get; set; }
        public string Color { get; set; }

        public string EngineModelNo { get; set; }
        public string EngineNo { get; set; }
        public string CarLabel { get; set; }
        public string CarImg { get; set; }
        public DateTime? CarRegisterTime { get; set; }
        public DateTime? MaintainExpireTime { get; set; }
        public int? CurrentMileage { get; set; }
        public int? NextMaintainMileage { get; set; }
        public DateTime? YearlyCheckTime { get; set; }
        public DateTime? SecondLevelMaintainTime { get; set; }
        public DateTime? LevelCheckTime { get; set; }
        public DateTime? TailCheckTime { get; set; }
        public DateTime? InsuranceExpireTime { get; set; }
        public string InsuranceOrg { get; set; }
        public string InsuranceNo { get; set; }

        public DateTime? FirstServiceTime { get; set; }
        public DateTime? LastServiceTime { get; set; }
    }
}
