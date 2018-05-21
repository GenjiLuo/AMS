using System;
using System.ComponentModel.DataAnnotations.Schema;
using AMS.Model.poco;

namespace AMS.Model.dto
{
    public class UserJobDto : BaseDto
    {
        public Guid JobId { get; set; }
        public string JobName { get; set; }
        public Guid UserId { get; set; }
        public string UserName { get; set; }
    }
}
