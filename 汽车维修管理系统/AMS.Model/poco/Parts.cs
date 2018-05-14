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
    public class Parts : BaseModel
    {
        public Parts()
        {
            PartsIns=new HashSet<PartsIn>();
            PartsOuts =new HashSet<PartsOut>();
        }
        public Guid PartsDictionaryId { get; set; }
        [ForeignKey("PartsDictionaryId")]
        public virtual PartsDictionary PartsDictionary { get; set; }

        public decimal Price { get; set; }
        public int Count { get; set; }

        public Guid? WarehouseId { get; set; }
        [ForeignKey("WarehouseId")]
        public virtual Warehouse Warehouse { get; set; }

        public virtual ICollection<PartsIn> PartsIns { get; set; }
        public virtual ICollection<PartsOut> PartsOuts { get; set; }
    }
}
