using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AMS.Model.poco
{
    public class Organization:BaseModel
    {
        public Organization()
        {
            User = new HashSet<User>();
            SubOrg = new HashSet<Organization>();
        }

        public virtual ICollection<User> User { get; set; }
        public string OrgHope { get; set; }
        public int State { get; set; }

        public Guid? ParentId { get; set; }
        [ForeignKey("ParentId")]
        public virtual ICollection<Organization> SubOrg { get; set; }
        public virtual Organization ParentOrg { get; set; }
    }
}
