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
    public class ServiceRepairAccountTicket : BaseModel
    {
        public ServiceRepairAccountTicket()
        {
            ServiceRepairCashTickets = new HashSet<ServiceRepairCashTicket>();
        }
        public Guid ServiceRepairId { get; set; }
        [ForeignKey("ServiceRepairId")]
        public virtual ServiceRepair ServiceRepair { get; set; }

        public decimal WorkHourMoney { get; set; }
        public decimal PartsMoney { get; set; }
        public decimal ManagementMoney { get; set; }
        public decimal OtherMoney { get; set; }
        public decimal TaxMoney { get; set; }

        public decimal WorkHourDiscount { get; set; }
        public decimal PartsDiscount { get; set; }
        public decimal ManagementDiscount { get; set; }

        public decimal TotalMoney { get; set; }
        public decimal MoveLittle { get; set; }
        public decimal ShouldPay { get; set; }
        public decimal CreditPay { get; set; }
        public decimal RealPay { get; set; }

        public virtual ICollection<ServiceRepairCashTicket> ServiceRepairCashTickets { get; set; }
    }
}
