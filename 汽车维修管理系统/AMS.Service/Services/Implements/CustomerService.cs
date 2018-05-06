using System;
using System.Collections.Generic;
using AMS.Model.dto;
using AMS.Model.Repositories.Implements;
using AMS.Model.Repositories.Interfaces;
using AMS.Model.ResponseModel;
using AMS.Service.Services.Interfaces;

namespace AMS.Service.Services.Implements
{
    public class CustomerService : ICustomerService
    {
        private readonly ICustomerRepository _customerRepository;

        public CustomerService()
        {
            _customerRepository=new CustomerRepository();
        }
        public List<CustomerDto> GetAllCustomer()
        {
            return _customerRepository.GetAllCustomer();
        }

        public CustomerDto GetOneCustomer(Guid customerId)
        {
            return _customerRepository.GetOneCustomer(customerId);
        }

        public ResModel AddCustomer(CustomerDto customerDto, UserDto operationUser)
        {
            return _customerRepository.AddCustomer(customerDto, operationUser);
        }

        public ResModel UpdateCustomer(CustomerDto customerDto, UserDto operationUser)
        {
            return _customerRepository.UpdateCustomer(customerDto, operationUser);
        }

        public ResModel DeleteCustomer(Guid customerDtoId)
        {
            return _customerRepository.DeleteCustomer(customerDtoId);
        }

        public List<CustomerDto> QueryCustomer(string customerName, string tel, string contact, string plateNum)
        {
            return _customerRepository.QueryCustomer(customerName,tel,contact,plateNum);
        }
    }
}
