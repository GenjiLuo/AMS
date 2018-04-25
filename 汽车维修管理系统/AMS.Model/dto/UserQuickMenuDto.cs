using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AMS.Model.dto
{
    public class UserQuickMenuDto:BaseDto
    {
        public UserQuickMenuDto()
        {
            AllThirdLevelMenu = new List<UserQuickMenuDto>();
        }
        public Guid MenuId { get; set; }
        public Guid UserId { get; set; }
        public bool IsSelected { get; set; }
        public string QuickMenuIcon { get; set; }
        public string Url { get; set; }
        public List<UserQuickMenuDto> AllThirdLevelMenu { get; set; }
    }
}
