using System;
using System.Collections.Generic;
using System.Linq;
using AMS.Model.dto;
using AMS.Model.Enum;
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
                    ContactName = i.CustomerType == CustomerType.个人 && i.ContactName == null?i.Name:i.ContactName,
                    ContactPhone = i.CustomerType == CustomerType.个人 && i.ContactPhone == null ? i.MobilePhone : i.ContactPhone,
                    FixPhone = i.FixPhone,
                    Address = i.Address,
                    WeChat = i.WeChat,
                    Gender = i.Gender,
                    Birthday = i.Birthday,
                    QQ = i.QQ,
                    Hobby = i.Hobby,
                    Description = i.Description
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
                    ContactName = i.CustomerType == CustomerType.个人 && i.ContactName == null ? i.Name : i.ContactName,
                    ContactPhone = i.CustomerType == CustomerType.个人 && i.ContactPhone == null ? i.MobilePhone : i.ContactPhone,
                    FixPhone = i.FixPhone,
                    Address = i.Address,
                    WeChat = i.WeChat,
                    Gender = i.Gender,
                    Birthday = i.Birthday,
                    QQ = i.QQ,
                    Hobby = i.Hobby,
                    PreChargeMoney = i.PreChargeMoney,
                    Description = i.Description
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
                    Level = CustomerLevel.普通客户,
                    MobilePhone = customerDto.MobilePhone,
                    ServicePassword = customerDto.ServicePassword,
                    ContactName = customerDto.ContactName,
                    ContactPhone = customerDto.ContactPhone,
                    FixPhone = customerDto.FixPhone,
                    Address = customerDto.Address,
                    WeChat = customerDto.WeChat,
                    Gender = customerDto.Gender,
                    Birthday = customerDto.Birthday,
                    QQ = customerDto.QQ,
                    Hobby = customerDto.Hobby,
                    Description = customerDto.Description
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
                    customer.ContactPhone = customerDto.ContactPhone;
                    customer.FixPhone = customerDto.FixPhone;
                    customer.Address = customerDto.Address;
                    customer.WeChat = customerDto.WeChat;
                    customer.Gender = customerDto.Gender;
                    customer.Birthday = customerDto.Birthday;
                    customer.QQ = customerDto.QQ;
                    customer.Hobby = customerDto.Hobby;
                    customer.Description = customerDto.Description;
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

        public List<CustomerDto> QueryCustomer(string customerName, string tel,string contact,string plateNum)
        {
            using (var db = new ModelContext())
            {
                var query = db.Customer.Select(i => new CustomerDto
                {
                    Id = i.Id,
                    Name = i.Name,
                    CustomerType = i.CustomerType,
                    Level = i.Level,
                    MobilePhone = i.MobilePhone,
                    ServicePassword = i.ServicePassword,
                    ContactName = i.CustomerType == CustomerType.个人 && i.ContactName == null ? i.Name : i.ContactName,
                    ContactPhone = i.CustomerType == CustomerType.个人 && i.ContactPhone == null ? i.MobilePhone : i.ContactPhone,
                    FixPhone = i.FixPhone,
                    Address = i.Address,
                    WeChat = i.WeChat,
                    Gender = i.Gender,
                    Birthday = i.Birthday,
                    QQ = i.QQ,
                    Hobby = i.Hobby,
                    Description = i.Description
                });
                if (!string.IsNullOrEmpty(customerName))
                {
                    query = query.Where(i => i.Name.Contains(customerName));
                }
                if (!string.IsNullOrEmpty(tel))
                {
                    query = query.Where(i => i.MobilePhone.Contains(tel) || i.FixPhone.Contains(tel));
                }
                if (!string.IsNullOrEmpty(contact))
                {
                    query = query.Where(i=>i.ContactName.Contains(contact));
                }

                if (!string.IsNullOrEmpty(plateNum))
                {
                    var plateNumQuery = db.Car.Where(i => i.PlateNum.Contains(plateNum)).Select(i=>i.Customer).Select(i=>new CustomerDto()
                    {
                        Id = i.Id,
                        Name = i.Name,
                        CustomerType = i.CustomerType,
                        Level = i.Level,
                        MobilePhone = i.MobilePhone,
                        ServicePassword = i.ServicePassword,
                        ContactName = i.CustomerType == CustomerType.个人 && i.ContactName == null ? i.Name : i.ContactName,
                        ContactPhone = i.CustomerType == CustomerType.个人 && i.ContactPhone == null ? i.MobilePhone : i.ContactPhone,
                        FixPhone = i.FixPhone,
                        Address = i.Address,
                        WeChat = i.WeChat,
                        Gender = i.Gender,
                        Birthday = i.Birthday,
                        QQ = i.QQ,
                        Hobby = i.Hobby,
                        Description = i.Description
                    });
                    query = query.Union(plateNumQuery);
                }
                return query.ToList();
            }
        }

        public List<CustomerPreChargeDto> GetAllCustomerPreCharges()
        {
            using (var db=new ModelContext())
            {
                var customerPreCharges = db.Customer.Select(i => new CustomerPreChargeDto()
                {
                    CustomerId = i.Id,
                    CustomerType = i.CustomerType,
                    Name = i.Name,
                    Level = i.Level,
                    ContactName = i.ContactName,
                    ContactPhone = i.ContactPhone ?? i.MobilePhone ?? i.FixPhone,
                    TotalCost = i.TotalCost,
                    PreChargeMoney = i.PreChargeMoney
                }).ToList();
                return customerPreCharges;
            }
        }

        public ResModel UpdatePreCharge(CustomerDto customerDto, UserDto operationUser)
        {
            using (var db=new ModelContext())
            {
                var customer = db.Customer.FirstOrDefault(i => i.Id == customerDto.Id);
                if (customer == null)
                {
                    return new ResModel(){Msg = "添加预存款失败，未找到该客户",Success = false};
                }

                try
                {
                    customer.PreChargeMoney += customerDto.PreChargeMoney;
                    db.SaveChanges();
                }
                catch (Exception e)
                {
                    return new ResModel() { Msg = "添加预存款失败", Success = false };
                }
                return new ResModel() { Msg = "添加预存款成功", Success = true };
            }
        }
    }
}
