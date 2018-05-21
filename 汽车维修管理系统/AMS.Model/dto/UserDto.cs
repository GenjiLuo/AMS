using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AMS.Model.dto
{
    public class UserDto:BaseDto
    {
        public UserDto()
        {
            UserJobs=new List<UserJobDto>();
        }
        public string Account { get; set; }
        public string Password { get; set; }
        public string Email { get; set; }
        public string Tel { get; set; }
        public Guid OrgId { get; set; }
        public string OrgName { get; set; }
        public string OrgHope { get; set; }
        public List<UserJobDto> UserJobs { get; set; }
    }
}
