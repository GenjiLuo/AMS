﻿using System;
using System.Collections.Generic;
using System.Linq;
using AMS.Model.dto;
using AMS.Model.poco;
using AMS.Model.Repositories.Interfaces;
using AMS.Model.ResponseModel;

namespace AMS.Model.Repositories.Implements
{
    public class CustomerRepository : ICustomerRepository
    {
        public List<CustomerDto> GetAllCustomer()
        {
            using (var db=new ModelContext())
            {
                var customers = db.Customer.Select(i => new CustomerDto()
                {
                    Id = i.Id,
                    Name = i.Name,
                    CustomerType = i.CustomerType,
                    Level = i.Level,
                    MobilePhone = i.MobilePhone,
                    ServicePassword = i.ServicePassword,
                    ContactName = i.ContactName,
                    IDCard = i.IDCard,
                    FixPhone = i.FixPhone,
                    Address = i.Address,
                    WeChat = i.WeChat,
                    Gender = i.Gender,
                    Birthday = i.Birthday,
                    QQ = i.QQ,
                    Hobby = i.Hobby
                }).ToList();
                return customers;
            }
        }

        public CustomerDto GetOneCustomer(Guid customerId)
        {
            using (var db=new ModelContext())
            {
                var customer = db.Customer.Where(i => i.Id == customerId).Select(i => new CustomerDto()
                {
                    Id = i.Id,
                    Name = i.Name,
                    CustomerType = i.CustomerType,
                    Level = i.Level,
                    MobilePhone = i.MobilePhone,
                    ServicePassword = i.ServicePassword,
                    ContactName = i.ContactName,
                    IDCard = i.IDCard,
                    FixPhone = i.FixPhone,
                    Address = i.Address,
                    WeChat = i.WeChat,
                    Gender = i.Gender,
                    Birthday = i.Birthday,
                    QQ = i.QQ,
                    Hobby = i.Hobby
                }).FirstOrDefault();
                return customer;
            }
        }

        public ResModel AddCustomer(CustomerDto customerDto, UserDto operationUser)
        {
            using (var db=new ModelContext())
            {
                var customer = new Customer()
                {
                    Id = Guid.NewGuid(),
                    Name = customerDto.Name,
                    CustomerType = customerDto.CustomerType,
                    Level = customerDto.Level,
                    MobilePhone = customerDto.MobilePhone,
                    ServicePassword = customerDto.ServicePassword,
                    ContactName = customerDto.ContactName,
                    IDCard = customerDto.IDCard,
                    FixPhone = customerDto.FixPhone,
                    Address = customerDto.Address,
                    WeChat = customerDto.WeChat,
                    Gender = customerDto.Gender,
                    Birthday = customerDto.Birthday,
                    QQ = customerDto.QQ,
                    Hobby = customerDto.Hobby
                };
                try
                {
                    db.Customer.Add(customer);
                    db.SaveChanges();
                }
                catch (Exception e)
                {
                    return new ResModel(){Msg = "添加用户失败",Success = false};
                }
                return new ResModel() { Msg = "添加用户成功", Success = true };
            }
        }

        public ResModel UpdateCustomer(CustomerDto customerDto, UserDto operationUser)
        {
            using (var db=new ModelContext())
            {
                var customer = db.Customer.FirstOrDefault(i => i.Id == customerDto.Id);
                if (customer == null)
                {
                    return new ResModel(){Msg = "更新用户失败，未找到该客户",Success = false};
                }

                try
                {
                    customer.Name = customerDto.Name;
                    customer.CustomerType = customerDto.CustomerType;
                    customer.Level = customerDto.Level;
                    customer.MobilePhone = customerDto.MobilePhone;
                    customer.ServicePassword = customerDto.ServicePassword;
                    customer.ContactName = customerDto.ContactName;
                    customer.IDCard = customerDto.IDCard;
                    customer.FixPhone = customerDto.FixPhone;
                    customer.Address = customerDto.Address;
                    customer.WeChat = customerDto.WeChat;
                    customer.Gender = customerDto.Gender;
                    customer.Birthday = customerDto.Birthday;
                    customer.QQ = customerDto.QQ;
                    customer.Hobby = customerDto.Hobby;
                    db.SaveChanges();
                }
                catch (Exception e)
                {
                    return new ResModel(){Msg = "更新用户失败",Success = false};
                }
                return new ResModel() { Msg = "更新用户成功", Success = true };
            }
        }

        public ResModel DeleteCustomer(Guid customerDtoId)
        {
            using (var db = new ModelContext())
            {
                var customer = db.Customer.FirstOrDefault(i => i.Id == customerDtoId);
                if (customer == null)
                {
                    return new ResModel() { Msg = "删除用户失败，未找到该客户", Success = false };
                }

                try
                {
                    db.Customer.Remove(customer);
                    db.SaveChanges();
                }
                catch (Exception e)
                {
                    return new ResModel() { Msg = "删除用户失败", Success = false };
                }
                return new ResModel() { Msg = "删除用户成功", Success = true };
            }
        }
    }
}
