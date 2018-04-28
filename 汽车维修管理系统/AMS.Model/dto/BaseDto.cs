using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AMS.Model.dto
{
    public class BaseDto
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public int? OrderNum { get; set; }
        public string Description { get; set; }

        public int State { get; set; }
        public Guid? CreateBy { get; set; }
        public DateTime? CreateTime { get; set; }
        public Guid? UpdateBy { get; set; }
        public DateTime? UpdateTime { get; set; }
    }
}
