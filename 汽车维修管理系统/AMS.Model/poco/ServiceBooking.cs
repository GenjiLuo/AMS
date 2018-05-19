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
    public class ServiceBooking : BaseModel
    {
        public ServiceBooking()
        {
            EstimateRepairParts = new HashSet<EstimateRepairParts>();
            ServiceRepairItem=new HashSet<ServiceRepairItem>();
        }
        public string BillNo { get; set; }
        public int BillNoIndex { get; set; }
        public DateTime BookingCreateTime { get; set; }
        public DateTime ServiceRepairTime { get; set; }
        public Guid CarId { get; set; }
        [ForeignKey("CarId")]
        public virtual Car Car { get; set; }
        public ServiceBookingState ServiceBookingState { get; set; }
        public string ContactName { get; set; }
        public string ContactPhone { get; set; }
        public string ContactAddress { get; set; }
        public string CompanyName { get; set; }
        public Guid ServiceAdvisorId { get; set; }
        [ForeignKey("ServiceAdvisorId")]
        public virtual User ServiceAdvisor { get; set; }

        public Guid RepairTypeId { get; set; }
        [ForeignKey("RepairTypeId")]
        public virtual RepairType RepairType { get; set; }
        public string CustomerDescription { get; set; }
        public string RepairDescription { get; set; }
        public string Remark { get; set; }

        public virtual ICollection<EstimateRepairParts> EstimateRepairParts { get; set; }
        public virtual ICollection<ServiceRepairItem> ServiceRepairItem { get; set; }
    }
}
