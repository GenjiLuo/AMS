﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AMS.Model.Enum;

namespace AMS.Model.poco
{
    public class Customer : BaseModel
    {
        public Customer()
        {
            Cars = new HashSet<Car>();
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
        public decimal TotalCost { get; set; }

        public virtual ICollection<Car> Cars { get; set; }
    }
}
