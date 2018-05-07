using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AMS.Model.dto;

namespace AMS.Model.poco
{
    public class PartsType : BaseModel
    {
        public PartsType()
        {
            SubPartsType = new HashSet<PartsType>();
            PartsDictionary=new HashSet<PartsDictionary>();
        }

        public Guid? ParentId { get; set; }
        [ForeignKey("ParentId")]
        public virtual PartsType ParentPartsType { get; set; }
        public virtual ICollection<PartsType> SubPartsType { get; set; }
        public virtual ICollection<PartsDictionary> PartsDictionary { get; set; }
    }
}
