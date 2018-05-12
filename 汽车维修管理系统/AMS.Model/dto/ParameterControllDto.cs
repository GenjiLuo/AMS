using System.Collections.Generic;
using AMS.Model.Enum;
using AMS.Model.poco;

namespace AMS.Model.dto
{
    public class ParameterControllDto : BaseDto
    {
        public string ParameterName { get; set; }
        public string Value1 { get; set; }
        public string Value2 { get; set; }
        public ParameterValueType Value1Type1 { get; set; }
        public ParameterValueType Value1Type2 { get; set; }
    }
}
