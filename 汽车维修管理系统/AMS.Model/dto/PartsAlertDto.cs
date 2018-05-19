using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using AMS.Model.poco;

namespace AMS.Model.dto
{
    public class PartsAlertDto : BaseDto
    {
        public string PartsCode { get; set; }
        public string PartsName { get; set; }
        public string WarehouseName { get; set; }
        public int CurrentCount { get; set; }
        public int? LowestAlertCount { get; set; }
        public int? HighestAlertCount { get; set; }
    }
}
