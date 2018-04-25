using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AMS.Model.dto
{
    public class QuickMenuDto:BaseDto
    {
        public Guid MenuId { get; set; }
        public Guid UserId { get; set; }
        public string QuickMenuIcon { get; set; }
        public string Url { get; set; }
    }
}
