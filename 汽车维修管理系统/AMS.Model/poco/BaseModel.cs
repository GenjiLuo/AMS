using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AMS.Model.poco
{
    public class BaseModel
    {
        public Guid Id { get; set; }
        public string Name { get; set; }

        public int? OrderNum { get; set; }
        public string Description { get; set; }

        public Guid? CreateBy { get; set; }
        public int State { get; set; }
        public int OperationType { get; set; }
        public DateTime? CreateTime { get; set; }
        public Guid? UpdateBy { get; set; }
        public DateTime? UpdateTime { get; set; }
    }
}
