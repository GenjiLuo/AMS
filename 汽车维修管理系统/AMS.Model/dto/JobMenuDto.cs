using System;

namespace AMS.Model.dto
{
    public class JobMenuDto : BaseDto
    {
        public Guid JobId { get; set; }
        public string JobName { get; set; }
        public Guid MenuId { get; set; }
        public string MenuName { get; set; }
    }
}
