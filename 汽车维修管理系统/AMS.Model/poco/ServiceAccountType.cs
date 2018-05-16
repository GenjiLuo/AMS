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
    public class ServiceAccountType : BaseModel
    {
        public ServiceAccountType()
        {
            EstimateRepairParts=new HashSet<EstimateRepairParts>();
            ServiceRepairItems=new HashSet<ServiceRepairItem>();
        }
        public virtual ICollection<EstimateRepairParts> EstimateRepairParts { get; set; }
        public virtual ICollection<ServiceRepairItem> ServiceRepairItems { get; set; }
    }
}
