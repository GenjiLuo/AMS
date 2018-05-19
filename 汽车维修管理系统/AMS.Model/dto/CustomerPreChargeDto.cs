using System;
using System.Collections.Generic;
using AMS.Model.Enum;
using AMS.Model.poco;

namespace AMS.Model.dto
{
    public class CustomerPreChargeDto : BaseDto
    {
        public Guid CustomerId { get; set; }
        public CustomerType CustomerType { get; set; }
        public CustomerLevel Level { get; set; }
        public string ContactName { get; set; }
        public string ContactPhone { get; set; }

        public decimal TotalCost { get; set; }
        public decimal PreChargeMoney { get; set; }

    }
}
