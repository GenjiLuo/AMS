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
    public class ParameterControl : BaseModel
    {
        [Index(IsUnique = true)]
        [StringLength(100)]
        public string ParameterName { get; set; }
        public string Value1 { get; set; }
        public string Value2 { get; set; }
        public ParameterValueType Value1Type1 { get; set; }
        public ParameterValueType Value1Type2 { get; set; }
    }
}
