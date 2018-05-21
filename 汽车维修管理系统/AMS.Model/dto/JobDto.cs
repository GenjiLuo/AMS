using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using AMS.Model.poco;

namespace AMS.Model.dto
{
    public class JobDto : BaseDto
    {
        public JobDto()
        {
            JobMenus=new List<JobMenuDto>();
        }
        public Guid OrgId { get; set; }
        public string OrgName { get; set; }
        public List<JobMenuDto> JobMenus { get; set; }
    }
}
