using System;
using System.ComponentModel.DataAnnotations.Schema;
using AMS.Model.poco;

namespace AMS.Model.dto
{
    public class OperationLogDto : BaseDto
    {
        public string  OperatorName { get; set; }
        public string OperatorAccount { get; set; }
        public string ModuleName { get; set; }
        public string OperationDesc { get; set; }
        public DateTime OperationTime { get; set; }
        public string IpAddress { get; set; }
    }
}
