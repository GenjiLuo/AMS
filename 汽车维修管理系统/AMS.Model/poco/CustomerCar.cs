using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace AMS.Model.poco
{
    public class CustomerCar : BaseModel
    {
        public CustomerCar()
        {
        }
        public Guid CustomerId { get; set; }
        [ForeignKey("CustomerId")]
        public virtual Customer Customer { get; set; }

        public string VIN { get; set; }
        public string PlateNum { get; set; }

        public Guid CarId { get; set; }
        [ForeignKey("CarId")]
        public virtual Car CarInfo { get; set; }

        public string EngineModelNo { get; set; }
        public string EngineNo { get; set; }
        public string CarLabel { get; set; }
        public string CarImg { get; set; }
        public DateTime? CarRegisterTime { get; set; }
        public DateTime? MaintainExpireTime { get; set; }
        public int? NextMaintainMileage { get; set; }
        public DateTime? YearlyCheckTime { get; set; }
        public DateTime? SecondLevelMaintainTime { get; set; }
        public DateTime? LevelCheckTime { get; set; }
        public DateTime? TailCheckTime { get; set; }
        public DateTime? InsuranceExpireTime { get; set; }
        public string InsuranceOrg { get; set; }
        public string InsuranceNo { get; set; }
    }
}
