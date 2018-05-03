using System;
using System.Collections.Generic;
using AMS.Model.dto;
using AMS.Model.ResponseModel;

namespace AMS.Model.Repositories.Interfaces
{
    public interface ICustomerRepository
    {
        List<CustomerDto> GetAllCustomer();
        CustomerDto GetOneCustomer(Guid customerId);
        ResModel AddCustomer(CustomerDto customerDto, UserDto operationUser);
        ResModel UpdateCustomer(CustomerDto customerDto, UserDto operationUser);
        ResModel DeleteCustomer(Guid customerDtoId);
    }
}
