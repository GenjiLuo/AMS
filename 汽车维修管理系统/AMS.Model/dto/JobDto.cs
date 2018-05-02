using System;
using System.ComponentModel.DataAnnotations.Schema;
using AMS.Model.poco;

namespace AMS.Model.dto
{
    public class Job : BaseDto
    {
        public Job()
        {
        }
        public Guid OrgId { get; set; }
        [ForeignKey("OrgId")]
        public virtual Organization Org { get; set; }
    }
}
