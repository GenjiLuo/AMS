using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;
using AMS.Model.dto;
using AMS.Model.Enum;
using Newtonsoft.Json;

namespace AMS.Model.poco
{
    public class EstimateRepairParts : BaseModel
    {
        public Guid PartsId { get; set; }
        [ForeignKey("PartsId")]
        public virtual Parts Parts { get; set; }

        public Guid ServiceBookingId { get; set; }
        [ForeignKey("ServiceBookingId")]
        public virtual ServiceBooking ServiceBooking { get; set; }

        public Guid? ServiceRepairId { get; set; }
        [ForeignKey("ServiceRepairId")]
        public virtual ServiceRepair ServiceRepair { get; set; }
        public int Count { get; set; }
        public decimal Price { get; set; }
    }
}
