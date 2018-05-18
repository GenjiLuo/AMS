using System;
using System.ComponentModel.DataAnnotations.Schema;
using AMS.Model.poco;

namespace AMS.Model.dto
{
    public class ServiceRepairAccountTicketDto : BaseDto
    {
        public ServiceRepairDto ServiceRepair { get; set; }
        public Guid ServiceRepairId { get; set; }

        public decimal WorkHourMoney
        {
            get
            {
                var workHourMoney=new decimal(0);
                if (ServiceRepair != null)
                {
                    foreach (var repairItem in ServiceRepair.ServiceRepairItem)
                    {
                        workHourMoney += repairItem.Price.Value * repairItem.WorkHour.Value;
                    }
                }

                return workHourMoney;
            }
            set { WorkHourMoney = value; }
        }

        public decimal PartsMoney
        {
            get
            {
                var partsMoney = new decimal(0);
                if (ServiceRepair != null)
                {
                    foreach (var repairParts in ServiceRepair.RepairParts)
                    {
                        partsMoney += repairParts.Price * repairParts.Count;
                    }
                }

                return partsMoney;
            }
            set { PartsMoney = value; }
        }

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
    }
}
