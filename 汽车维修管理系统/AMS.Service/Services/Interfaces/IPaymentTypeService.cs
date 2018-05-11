using System;
using System.Collections.Generic;
using AMS.Model.dto;
using AMS.Model.ResponseModel;

namespace AMS.Service.Services.Interfaces
{
    public interface IPaymentTypeService
    {
        List<PaymentTypeDto> GetAllPaymentType();
        ResModel AddPaymentType(PaymentTypeDto paymentTypeDto, UserDto operationUser);
        PaymentTypeDto GetOnePaymentType(Guid paymentTypeId);
        ResModel UpdatePaymentType(PaymentTypeDto paymentTypeDto, UserDto operationUser);
        ResModel DeletePaymentType(Guid paymentTypeId);
        List<PaymentTypeDto> QueryPaymentType(string keyword);
    }
}
