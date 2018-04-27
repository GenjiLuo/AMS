using System;
using AMS.Model.poco;

namespace AMS.Model.dto
{
    public class OrgDto:BaseModel
    {
        public string OrgHope { get; set; }
        public int State { get; set; }
        public Guid? ParentId { get; set; }
    }
}
