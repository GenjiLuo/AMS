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
    public class PartsOut : BaseModel
    {
        public Guid PartsReturnId { get; set; }
        [ForeignKey("PartsReturnId")]
        public virtual PartsReturn PartsReturn { get; set; }
        public Guid PartsId { get; set; }
        [ForeignKey("PartsId")]
        public virtual Parts Parts { get; set; }

        public int Count { get; set; }
    }
}
