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
    public class RepairItem : BaseModel
    {
        public RepairItem()
        {
            ServiceRepairItem=new HashSet<ServiceRepairItem>();
        }
        public string SerNum { get; set; }
        public float WorkHour { get; set; }
        public decimal Price { get; set; }
        public bool IsHot { get; set; }
        public Guid RepairItemTypeId { get; set; }
        [ForeignKey("RepairItemTypeId")]
        public virtual RepairItemType RepairItemType { get; set; }
        public virtual ICollection<ServiceRepairItem> ServiceRepairItem { get; set; }
    }
}
