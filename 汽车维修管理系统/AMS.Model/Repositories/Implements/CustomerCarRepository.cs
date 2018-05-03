using System;
using System.Collections.Generic;
using System.Linq;
using AMS.Model.dto;
using AMS.Model.poco;
using AMS.Model.Repositories.Interfaces;
using AMS.Model.ResponseModel;

namespace AMS.Model.Repositories.Implements
{
    public class CustomerCarRepository : ICustomerCarRepository
    {
        public List<CustomerCarDto> GetAllCustomerCar()
        {
            using (var db=new ModelContext())
            {
                var customerCars = db.CustomerCar.Select(i => new CustomerCarDto()
                {
                    Id = i.Id,
                    CustomerId = i.CustomerId,
                    CustomerName = i.Customer.Name,
                    CustomerPhone = i.Customer.MobilePhone ?? i.Customer.FixPhone,
                    VIN = i.VIN,
                    PlateNum = i.PlateNum,
                    CarId = i.CarId,
                    BrandName = i.CarInfo.BrandName,
                    SeriesName = i.CarInfo.SeriesName,
                    ModelNo = i.CarInfo.ModelNo,
                    Price = i.CarInfo.Price,
                    FullName = i.CarInfo.FullName,
                    Color = i.CarInfo.Color,
                    EngineModelNo = i.EngineModelNo,
                    EngineNo = i.EngineNo,
                    CarLabel = i.CarLabel,
                    CarImg = i.CarImg,
                    CarRegisterTime = i.CarRegisterTime,
                    MaintainExpireTime = i.MaintainExpireTime,
                    NextMaintainMileage = i.NextMaintainMileage,
                    YearlyCheckTime = i.YearlyCheckTime,
                    SecondLevelMaintainTime = i.SecondLevelMaintainTime,
                    LevelCheckTime = i.LevelCheckTime,
                    TailCheckTime = i.TailCheckTime,
                    InsuranceExpireTime = i.InsuranceExpireTime,
                    InsuranceOrg = i.InsuranceOrg,
                    InsuranceNo = i.InsuranceNo
                }).ToList();
                return customerCars;
            }
        }

        public List<CustomerCarDto> GetAllCustomerCarByCustomerId(Guid customerId)
        {
            using (var db = new ModelContext())
            {
                var customerCars = db.CustomerCar.Where(i=>i.CustomerId == customerId).Select(i => new CustomerCarDto()
                {
                    Id = i.Id,
                    CustomerId = i.CustomerId,
                    CustomerName = i.Customer.Name,
                    CustomerPhone = i.Customer.MobilePhone ?? i.Customer.FixPhone,
                    VIN = i.VIN,
                    PlateNum = i.PlateNum,
                    CarId = i.CarId,
                    BrandName = i.CarInfo.BrandName,
                    SeriesName = i.CarInfo.SeriesName,
                    ModelNo = i.CarInfo.ModelNo,
                    Price = i.CarInfo.Price,
                    FullName = i.CarInfo.FullName,
                    Color = i.CarInfo.Color,
                    EngineModelNo = i.EngineModelNo,
                    EngineNo = i.EngineNo,
                    CarLabel = i.CarLabel,
                    CarImg = i.CarImg,
                    CarRegisterTime = i.CarRegisterTime,
                    MaintainExpireTime = i.MaintainExpireTime,
                    NextMaintainMileage = i.NextMaintainMileage,
                    YearlyCheckTime = i.YearlyCheckTime,
                    SecondLevelMaintainTime = i.SecondLevelMaintainTime,
                    LevelCheckTime = i.LevelCheckTime,
                    TailCheckTime = i.TailCheckTime,
                    InsuranceExpireTime = i.InsuranceExpireTime,
                    InsuranceOrg = i.InsuranceOrg,
                    InsuranceNo = i.InsuranceNo
                }).ToList();
                return customerCars;
            }
        }

        public CustomerCarDto GetOneCustomerCar(Guid customerCarId)
        {
            using (var db=new ModelContext())
            {
                var customerCar = db.CustomerCar.Where(i => i.Id == customerCarId).Select(i => new CustomerCarDto()
                {
                    Id = i.Id,
                    CustomerId = i.CustomerId,
                    CustomerName = i.Customer.Name,
                    CustomerPhone = i.Customer.MobilePhone ?? i.Customer.FixPhone,
                    VIN = i.VIN,
                    PlateNum = i.PlateNum,
                    CarId = i.CarId,
                    BrandName = i.CarInfo.BrandName,
                    SeriesName = i.CarInfo.SeriesName,
                    ModelNo = i.CarInfo.ModelNo,
                    Price = i.CarInfo.Price,
                    FullName = i.CarInfo.FullName,
                    Color = i.CarInfo.Color,
                    EngineModelNo = i.EngineModelNo,
                    EngineNo = i.EngineNo,
                    CarLabel = i.CarLabel,
                    CarImg = i.CarImg,
                    CarRegisterTime = i.CarRegisterTime,
                    MaintainExpireTime = i.MaintainExpireTime,
                    NextMaintainMileage = i.NextMaintainMileage,
                    YearlyCheckTime = i.YearlyCheckTime,
                    SecondLevelMaintainTime = i.SecondLevelMaintainTime,
                    LevelCheckTime = i.LevelCheckTime,
                    TailCheckTime = i.TailCheckTime,
                    InsuranceExpireTime = i.InsuranceExpireTime,
                    InsuranceOrg = i.InsuranceOrg,
                    InsuranceNo = i.InsuranceNo
                }).FirstOrDefault();
                return customerCar;
            }
        }

        public ResModel AddCustomerCar(CustomerCarDto customerCarDto, UserDto operationUser)
        {
            using (var db=new ModelContext())
            {
                var customerCar = new CustomerCar()
                {
                    Id = Guid.NewGuid(),
                    CustomerId = customerCarDto.CustomerId,
                    VIN = customerCarDto.VIN,
                    PlateNum = customerCarDto.PlateNum,
                    CarId = customerCarDto.CarId,
                    EngineModelNo = customerCarDto.EngineModelNo,
                    EngineNo = customerCarDto.EngineNo,
                    CarLabel = customerCarDto.CarLabel,
                    CarImg = customerCarDto.CarImg,
                    CarRegisterTime = customerCarDto.CarRegisterTime,
                    MaintainExpireTime = customerCarDto.MaintainExpireTime,
                    NextMaintainMileage = customerCarDto.NextMaintainMileage,
                    YearlyCheckTime = customerCarDto.YearlyCheckTime,
                    SecondLevelMaintainTime = customerCarDto.SecondLevelMaintainTime,
                    LevelCheckTime = customerCarDto.LevelCheckTime,
                    TailCheckTime = customerCarDto.TailCheckTime,
                    InsuranceExpireTime = customerCarDto.InsuranceExpireTime,
                    InsuranceOrg = customerCarDto.InsuranceOrg,
                    InsuranceNo = customerCarDto.InsuranceNo
                };
                try
                {
                    db.CustomerCar.Add(customerCar);
                    db.SaveChanges();
                }
                catch (Exception e)
                {
                    return new ResModel(){Msg = "添加车辆信息失败",Success = false};
                }
                return new ResModel() { Msg = "添加车辆信息成功", Success = true };
            }
        }

        public ResModel UpdateCustomerCar(CustomerCarDto customerCarDto, UserDto operationUser)
        {
            using (var db=new ModelContext())
            {
                var customerCar = db.CustomerCar.FirstOrDefault(i => i.Id == customerCarDto.Id);
                if (customerCar == null)
                {
                    return new ResModel(){Msg = "更新车辆信息失败，未找到该车辆信息",Success = false};
                }

                try
                {
                    customerCar.CustomerId = customerCarDto.CustomerId;
                    customerCar.VIN = customerCarDto.VIN;
                    customerCar.PlateNum = customerCarDto.PlateNum;
                    customerCar.CarId = customerCarDto.CarId;
                    customerCar.EngineModelNo = customerCarDto.EngineModelNo;
                    customerCar.EngineNo = customerCarDto.EngineNo;
                    customerCar.CarLabel = customerCarDto.CarLabel;
                    customerCar.CarImg = customerCarDto.CarImg;
                    customerCar.CarRegisterTime = customerCarDto.CarRegisterTime;
                    customerCar.MaintainExpireTime = customerCarDto.MaintainExpireTime;
                    customerCar.NextMaintainMileage = customerCarDto.NextMaintainMileage;
                    customerCar.YearlyCheckTime = customerCarDto.YearlyCheckTime;
                    customerCar.SecondLevelMaintainTime = customerCarDto.SecondLevelMaintainTime;
                    customerCar.LevelCheckTime = customerCarDto.LevelCheckTime;
                    customerCar.TailCheckTime = customerCarDto.TailCheckTime;
                    customerCar.InsuranceExpireTime = customerCarDto.InsuranceExpireTime;
                    customerCar.InsuranceOrg = customerCarDto.InsuranceOrg;
                    customerCar.InsuranceNo = customerCarDto.InsuranceNo;
                    db.SaveChanges();
                }
                catch (Exception e)
                {
                    return new ResModel() { Msg = "更新车辆信息失败", Success = false };
                }
                return new ResModel() { Msg = "更新车辆信息成功", Success = true };
            }
        }

        public ResModel DeleteCustomerCar(Guid customerCarId)
        {
            using (var db = new ModelContext())
            {
                var customerCar = db.CustomerCar.FirstOrDefault(i => i.Id == customerCarId);
                if (customerCar == null)
                {
                    return new ResModel() { Msg = "删除车辆信息失败，未找到该车辆信息", Success = false };
                }

                try
                {
                    db.CustomerCar.Remove(customerCar);
                    db.SaveChanges();
                }
                catch (Exception e)
                {
                    return new ResModel() { Msg = "删除车辆信息失败", Success = false };
                }
                return new ResModel() { Msg = "删除车辆信息成功", Success = true };
            }
        }
    }
}
