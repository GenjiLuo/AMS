using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AMS.Model.dto;
using AMS.Model.Enum;
using Newtonsoft.Json;

namespace AMS.Model.poco
{
    public class ServiceRepair : BaseModel
    {
        public ServiceRepair()
        {
            ServiceRepairItem = new HashSet<ServiceRepairItem>();
            EstimateRepairParts = new HashSet<EstimateRepairParts>();
            RepairParts=new HashSet<RepairParts>();
        }
        public string BillNo { get; set; }
        public int BillNoIndex { get; set; }
        public Guid CarId { get; set; }
        [ForeignKey("CarId")]
        public Car Car { get; set; }

        public Guid? ServiceBookingId { get; set; }
        [ForeignKey("ServiceBookingId")]
        public virtual ServiceBooking ServiceBooking { get; set; }

        public ServiceRepairState? ServiceRepairState { get; set; }
        public ServiceWashState? ServiceWashState { get; set; }
        public ServiceType? ServiceType { get; set; }

        public Guid? RepairTypeId { get; set; }
        [ForeignKey("RepairTypeId")]
        public virtual RepairType RepairType { get; set; }

        public DateTime? ServiceDateTime { get; set; }
        public DateTime? EstimateLeaveTime { get; set; }
        public DateTime? LeaveTime { get; set; }
        public Guid? ServiceAdvisorId { get; set; }
        [ForeignKey("ServiceAdvisorId")]
        public virtual User ServiceAdvisor { get; set; }

        public string ContactName { get; set; }
        public string ContactPhone { get; set; }
        public string RepairDescription { get; set; }
        public string CustomerDescription { get; set; }

        public virtual ICollection<ServiceRepairItem> ServiceRepairItem { get; set; }
        public virtual ICollection<EstimateRepairParts> EstimateRepairParts { get; set; }
        public virtual ICollection<RepairParts> RepairParts { get; set; }
    }
}
