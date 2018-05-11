using System;
using System.Collections.Generic;
using AMS.Model.dto;
using AMS.Model.Repositories.Implements;
using AMS.Model.Repositories.Interfaces;
using AMS.Model.ResponseModel;
using AMS.Service.Services.Interfaces;

namespace AMS.Service.Services.Implements
{
    public class PaymentTypeService : IPaymentTypeService
    {
        private readonly IPaymentTypeRepository _paymentTypeRepository;

        public PaymentTypeService()
        {
            _paymentTypeRepository=new PaymentTypeRepository();
        }

        public List<PaymentTypeDto> GetAllPaymentType()
        {
            return _paymentTypeRepository.GetAllPaymentType();
        }

        public ResModel AddPaymentType(PaymentTypeDto paymentTypeDto, UserDto operationUser)
        {
            return _paymentTypeRepository.AddPaymentType(paymentTypeDto, operationUser);
        }

        public PaymentTypeDto GetOnePaymentType(Guid paymentTypeId)
        {
            return _paymentTypeRepository.GetOnePaymentType(paymentTypeId);
        }

        public ResModel UpdatePaymentType(PaymentTypeDto paymentTypeDto, UserDto operationUser)
        {
            return _paymentTypeRepository.UpdatePaymentType(paymentTypeDto, operationUser);
        }

        public ResModel DeletePaymentType(Guid paymentTypeId)
        {
            return _paymentTypeRepository.DeletePaymentType(paymentTypeId);
        }

        public List<PaymentTypeDto> QueryPaymentType(string keyword)
        {
            return _paymentTypeRepository.QueryPaymentType(keyword);
        }
    }
}
