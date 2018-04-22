using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AMS.Model.poco
{
    public class Menu
    {
        public Menu()
        {
            SubMenu = new HashSet<Menu>();
        }
        public Guid Id { get; set; }
        [Required]
        public string Name { get; set; }
        public string Icon { get; set; }
        public string SelectedIcon { get; set; }
        public string Url { get; set; }

        public Guid? ParentId { get; set; }
        [ForeignKey("ParentId")]
        public virtual ICollection<Menu> SubMenu { get; set; }
        public virtual Menu ParentMenu { get; set; }
    }
}
