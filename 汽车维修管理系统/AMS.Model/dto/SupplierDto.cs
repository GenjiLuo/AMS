using System;
using AMS.Model.poco;

namespace AMS.Model.dto
{
    public class SupplierDto : BaseDto
    {
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
