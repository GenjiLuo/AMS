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
    public class PartsIn : BaseModel
    {
        public Guid PartsBuyId { get; set; }
        [ForeignKey("PartsBuyId")]
        public virtual PartsBuy PartsBuy { get; set; }

        public Guid PartsDictionaryId { get; set; }
        [ForeignKey("PartsDictionaryId")]
        public virtual PartsDictionary PartsDictionary { get; set; }

        public Guid? PartsId { get; set; }
        [ForeignKey("PartsId")]
        public virtual Parts Parts { get; set; }

        public int Count { get; set; }
        public decimal SupplierPrice { get; set; }
    }
}
