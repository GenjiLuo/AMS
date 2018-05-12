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
    public class BillNoSetting : BaseModel
    {
        public string Prefix { get; set; }
        public BillDateFormat DateFormat { get; set; }
        public BillSerNoLength SerNoLength { get; set; }
        public bool DailyReset { get; set; }
        public string BillNoPreview { get; set; }
    }
}
