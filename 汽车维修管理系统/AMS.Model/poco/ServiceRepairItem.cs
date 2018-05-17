using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AMS.Model.dto;
using Newtonsoft.Json;

namespace AMS.Model.poco
{
    public class ServiceRepairItem : BaseModel
    {
        public Guid RepairItemId { get; set; }
        [ForeignKey("RepairItemId")]
        public virtual RepairItem RepairItem { get; set; }

        public Guid? ServiceBookingId { get; set; }
        [ForeignKey("ServiceBookingId")]
        public virtual ServiceBooking ServiceBooking { get; set; }

        public Guid? ServiceRepairId { get; set; }
        [ForeignKey("ServiceRepairId")]
        public virtual ServiceRepair ServiceRepair { get; set; }

        public decimal? WorkHour { get; set; } 
        public decimal? Price { get; set; }
        public Guid? MainOperatorId { get; set; }
        [ForeignKey("MainOperatorId")]
        public virtual User MainOperator { get; set; }

        public Guid ServiceAccountTypeId { get; set; }
        [ForeignKey("ServiceAccountTypeId")]
        public virtual ServiceAccountType ServiceAccountType { get; set; }
    }
}
