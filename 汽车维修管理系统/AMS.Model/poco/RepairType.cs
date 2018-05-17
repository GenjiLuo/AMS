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
    public class RepairType : BaseModel
    {
        public RepairType()
        {
            ServiceRepairs = new HashSet<ServiceRepair>();
            ServiceBookings=new HashSet<ServiceBooking>();
        }
        public virtual ICollection<ServiceRepair> ServiceRepairs { get; set; }
        public virtual ICollection<ServiceBooking> ServiceBookings { get; set; }
    }
}
