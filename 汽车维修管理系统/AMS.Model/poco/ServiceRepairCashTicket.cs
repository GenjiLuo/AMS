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
    public class ServiceRepairCashTicket : BaseModel
    {
        public ServiceRepairCashTicket()
        {
            ServiceRpairPayments=new HashSet<ServiceRpairPayment>();
        }
        public Guid ServiceRepairAccountTicketId { get; set; }
        [ForeignKey("ServiceRepairAccountTicketId")]
        public virtual ServiceRepairAccountTicket ServiceRepairAccountTicket { get; set; }

        public Guid? ServiceTicketTypeId { get; set; }
        [ForeignKey("ServiceTicketTypeId")]
        public virtual ServiceTicketType ServiceTicketType { get; set; }
        public string TaxBillNo { get; set; }

        public decimal ShouldPay { get; set; }
        public decimal RealPay { get; set; }
        public decimal BackLittle { get; set; }
        public virtual ICollection<ServiceRpairPayment> ServiceRpairPayments { get; set; }
    }

    public class ServiceRpairPayment : BaseModel
    {
        public Guid ServiceRepairCashTicketId { get; set; }
        [ForeignKey("ServiceRepairCashTicketId")]
        public virtual ServiceRepairCashTicket ServiceRepairCashTicket { get; set; }

        public Guid PaymentTypeId { get; set; }
        [ForeignKey("PaymentTypeId")]
        public virtual PaymentType PaymentType { get; set; }

        public decimal Money { get; set; }
    }
}
