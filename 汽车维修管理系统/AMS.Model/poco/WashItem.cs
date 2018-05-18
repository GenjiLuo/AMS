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
    public class WashItem : BaseModel
    {
        public WashItem()
        {
            ServiceWashItems=new HashSet<ServiceWashItem>();
        }
        public decimal Price { get; set; }

        public virtual ICollection<ServiceWashItem> ServiceWashItems { get; set; }
    }
}
