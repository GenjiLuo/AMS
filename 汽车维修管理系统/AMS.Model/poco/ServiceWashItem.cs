using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AMS.Model.dto;

namespace AMS.Model.poco
{
    public class ServiceWashItem : BaseModel
    {
        public Guid WashItemId { get; set; }
        [ForeignKey("WashItemId")]
        public virtual WashItem WashItem { get; set; }

        public Guid ServiceRepairId { get; set; }
        [ForeignKey("ServiceRepairId")]
        public virtual ServiceRepair ServiceRepair { get; set; }
    }
}
