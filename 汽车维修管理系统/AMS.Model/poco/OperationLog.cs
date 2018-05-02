using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AMS.Model.poco
{
    public class OperationLog : BaseModel
    {
        public string ModuleName { get; set; }
        public string OperationDesc { get; set; }
        public DateTime OperationTime { get; set; }
        public string IpAddress { get; set; }

        public Guid OperationUserId { get; set; }
        [ForeignKey("OperationUserId")]
        public virtual User OpertionUser { get; set; } 
    }
}
