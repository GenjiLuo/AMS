﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AMS.Model.dto;
using Newtonsoft.Json;

namespace AMS.Model.poco
{
    public class PaymentType : BaseModel
    {
        public PaymentType()
        {
            ServiceRpairPayments=new HashSet<ServiceRpairPayment>();
        }
        public string IconUrl { get; set; }
        public string SelectedIconUrl { get; set; }
        public virtual ICollection<ServiceRpairPayment> ServiceRpairPayments { get; set; }
    }
}
