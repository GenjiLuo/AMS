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
    public class Job: BaseModel
    {
        public Job()
        {
            JobMenus=new HashSet<JobMenu>();
            UserJobs=new HashSet<UserJob>();
        }
        public Guid OrgId { get; set; }
        [ForeignKey("OrgId")]
        public virtual Organization Org { get; set; }

        public virtual ICollection<JobMenu> JobMenus { get; set; }
        public virtual ICollection<UserJob> UserJobs { get; set; }
    }
}
