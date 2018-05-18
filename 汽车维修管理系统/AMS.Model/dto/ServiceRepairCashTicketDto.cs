using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using AMS.Model.poco;

namespace AMS.Model.dto
{
    public class ServiceRepairCashTicketDto : BaseDto
    {
        public Guid ServiceRepairAccountTicketId { get; set; }
        public ServiceRepairAccountTicketDto ServiceRepairAccountTicket { get; set; }

        public List<ServiceRpairPaymentDto> ServiceRpairPayments { get; set; }
        public decimal ShouldPay { get; set; }
        public decimal RealPay { get; set; }
        public decimal BackLittle { get; set; }

        public Guid? ServiceTicketTypeId { get; set; }
        public string  ServiceTicketTypeName { get; set; }
        public string TaxBillNo { get; set; }

    }

    public class ServiceRpairPaymentDto : BaseDto
    {
        public Guid ServiceRepairCashTicketId { get; set; }
        public Guid PaymentTypeId { get; set; }
        public string PaymentTypeName { get; set; }

        public decimal Money { get; set; }
    }
}
