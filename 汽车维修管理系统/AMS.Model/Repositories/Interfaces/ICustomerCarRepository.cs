using System;
using System.Collections.Generic;
using AMS.Model.dto;
using AMS.Model.ResponseModel;

namespace AMS.Model.Repositories.Interfaces
{
    public interface ICustomerCarRepository
    {
        List<CustomerCarDto> GetAllCustomerCar();
        List<CustomerCarDto> GetAllCustomerCarByCustomerId(Guid customerId);

        CustomerCarDto GetOneCustomerCar(Guid customerCarId);
        ResModel AddCustomerCar(CustomerCarDto customerCarDto, UserDto operationUser);
        ResModel UpdateCustomerCar(CustomerCarDto customerCarDto, UserDto operationUser);
        ResModel DeleteCustomerCar(Guid customerCarId);
    }
}
