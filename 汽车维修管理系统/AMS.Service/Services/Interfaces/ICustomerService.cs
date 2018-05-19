using System;
using System.Collections.Generic;
using AMS.Model.dto;
using AMS.Model.ResponseModel;

namespace AMS.Service.Services.Interfaces
{
    public interface ICustomerService
    {
        List<CustomerDto> GetAllCustomer();
        CustomerDto GetOneCustomer(Guid customerId);
        ResModel AddCustomer(CustomerDto customerDto, UserDto operationUser);
        ResModel UpdateCustomer(CustomerDto customerDto, UserDto operationUser);
        ResModel DeleteCustomer(Guid customerDtoId);
        List<CustomerDto> QueryCustomer(string customerName, string tel, string contact, string plateNum);
        List<CustomerPreChargeDto> GetAllCustomerPreCharges();
        ResModel UpdatePreCharge(CustomerDto customerDto, UserDto operationUser);

    }
}
