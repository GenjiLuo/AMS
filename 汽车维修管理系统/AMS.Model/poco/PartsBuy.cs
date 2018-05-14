using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AMS.Model.dto;
using AMS.Model.Enum;
using Newtonsoft.Json;

namespace AMS.Model.poco
{
    public class PartsBuy : BaseModel
    {
        public PartsBuy()
        {
            PartsIns = new HashSet<PartsIn>();
        }
        public Guid SupplierId { get; set; }
        [ForeignKey("SupplierId")]
        public virtual Supplier Supplier { get; set; }
        public string BillNo { get; set; } 
        public int BillNoIndex { get; set; }
        public new PartsBuyState State { get; set; }
        public string ApplyUser { get; set; }
        public string CheckUser { get; set; }
        public DateTime? OperationTime { get; set; }
        public decimal TotalMoney { get; set; }
        public decimal ReadyToPay { get; set; }

        public Guid WarehouseId { get; set; }
        [ForeignKey("WarehouseId")]
        public virtual Warehouse Warehouse { get; set; }
        public virtual ICollection<PartsIn> PartsIns { get; set; }
    }
}
 