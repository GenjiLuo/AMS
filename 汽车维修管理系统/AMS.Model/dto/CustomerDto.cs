﻿using System;
using System.Collections.Generic;
using AMS.Model.Enum;
using AMS.Model.poco;

namespace AMS.Model.dto
{
    public class CustomerDto : BaseDto
    {
        public CustomerDto()
        {
        }
        public CustomerType CustomerType { get; set; }
        public CustomerLevel Level { get; set; }
        public string MobilePhone { get; set; }
        public string ServicePassword { get; set; }
        public string ContactName { get; set; }
        public string ContactPhone { get; set; }
        public string FixPhone { get; set; }
        public string Address { get; set; }
        public string WeChat { get; set; }
        public int Gender { get; set; }
        public DateTime? Birthday { get; set; }
        public string QQ { get; set; }
        public string Hobby { get; set; }

        public decimal PreChargeMoney { get; set; }
        public  List<Car> Cars { get; set; }
    }
}
