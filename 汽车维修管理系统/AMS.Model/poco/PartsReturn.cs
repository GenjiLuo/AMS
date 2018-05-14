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
    public class PartsReturn : BaseModel
    {
        public PartsReturn()
        {
            PartsOuts = new HashSet<PartsOut>();
        }
        public Guid SupplierId { get; set; }
        [ForeignKey("SupplierId")]
        public virtual Supplier Supplier { get; set; }
        public string BillNo { get; set; }
        public int BillNoIndex { get; set; }
        public new PartsReturnState State { get; set; }
        public string ApplyUser { get; set; }
        public string CheckUser { get; set; }
        public DateTime? OperationTime { get; set; }
        public decimal TotalMoney { get; set; }

        public virtual ICollection<PartsOut> PartsOuts { get; set; }
    }
}
