using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AMS.Model.dto
{
    public class MenuDto:BaseDto
    {
        public MenuDto()
        {
            SubMenuDto=new List<MenuDto>();
        }
        public string Icon { get; set; }
        public string SelectedIcon { get; set; }
        public string Url { get; set; }
        public Guid? ParentId { get; set; }
        public string QuickMenuIcon { get; set; }

        public List<MenuDto> SubMenuDto { get; set; }
    }
}
