using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AMS.Model.poco
{
    public class User:BaseModel
    {
        public User()
        {
            OperationLogs = new HashSet<OperationLog>();
            ServiceRepairItems=new HashSet<ServiceRepairItem>();
    }
        [Required]
        [Index(IsUnique = true)]
        [MaxLength(50)]
        public string Account { get; set; }
        [Required]
        public string Password { get; set; }
        public string Email { get; set; }
        public string Tel { get; set; }
        public Guid? OrgId { get; set; }

        [ForeignKey("OrgId")]
        public virtual Organization Org { get; set; }
        public virtual ICollection<OperationLog> OperationLogs { get; set; }
        public virtual ICollection<ServiceRepairItem> ServiceRepairItems { get; set; }
    }
}
