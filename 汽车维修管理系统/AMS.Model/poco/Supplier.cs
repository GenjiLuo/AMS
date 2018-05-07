using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AMS.Model.poco
{
    public class Supplier : BaseModel
    {
        [Required]
        public string Code { get; set; }
        public string ContactName { get; set; }
        public string MobilePhone { get; set; }
        public string FixPhone { get; set; }
        public string Fax { get; set; }
        public string MajorOrigin { get; set; }
        public string BankName { get; set; }
        public string BankAccount { get; set; }
        public string Address { get; set; }
        public int? Gender { get; set; }
        public DateTime? Birthday { get; set; }
        public string Wechat { get; set; }
        public string QQ { get; set; }
    }

}
