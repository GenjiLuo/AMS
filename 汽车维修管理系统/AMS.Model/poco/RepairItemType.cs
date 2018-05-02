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
    public class RepairItemType : BaseDto
    {
        public RepairItemType()
        {
            RepairItem=new HashSet<RepairItem>();
        }
        public virtual ICollection<RepairItem> RepairItem { get; set; }
    }
}
