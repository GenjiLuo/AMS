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
    public class JobMenu : BaseModel
    {
        public Guid JobId { get; set; }
        [ForeignKey("JobId")]
        public virtual Job Job { get; set; }
        public Guid MenuId { get; set; }
        [ForeignKey("MenuId")]
        public virtual Menu Menu { get; set; }
    }
}
