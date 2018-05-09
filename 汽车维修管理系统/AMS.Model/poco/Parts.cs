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
        public Guid PartsDictionaryId { get; set; }
        [ForeignKey("PartsDictionaryId")]
        public virtual PartsDictionary PartsDictionary { get; set; }

        public decimal Price { get; set; }
        public int Count { get; set; }

        public Guid PartsBuyId { get; set; }
        [ForeignKey("PartsBuyId")]
        public virtual PartsBuy PartsBuy { get; set; }
        public Guid? WarehouseId { get; set; }
    }
}
