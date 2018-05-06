using System;
using System.Collections.Generic;
using System.Linq;
using AMS.Model.dto;
using AMS.Model.poco;
using AMS.Model.Repositories.Interfaces;
using AMS.Model.ResponseModel;

namespace AMS.Model.Repositories.Implements
{
    public class CarRepository : ICarRepository
    {
        public List<CarDto> GetAllCar()
        {
            using (var db=new ModelContext())
            {
                var cars = db.Car.Select(i => new CarDto()
                {
                    Id = i.Id,
                    CustomerId = i.CustomerId,
                    CustomerName = i.Customer.Name,
                    CustomerPhone = i.Customer.MobilePhone ?? i.Customer.FixPhone,

                    CarOwnerName = i.CarOwnerName,
                    CarOwnerPhone = i.CarOwnerPhone,

                    VIN = i.VIN,
                    PlateNum = i.PlateNum,
                    ModelId = i.ModelId,
                    BrandName = i.Model.Series.Brand.Name,
                    SeriesName = i.Model.Series.Name,
                    ModelName = i.Model.Name,
                    Price = i.Model.Price,
                    FullName = i.Model.FullName,
                    Color = i.Color,
                    EngineModelNo = i.EngineModelNo,
                    EngineNo = i.EngineNo,
                    CarLabel = i.CarLabel,
                    CarImg = i.CarImg,
                    CarRegisterTime = i.CarRegisterTime,
                    MaintainExpireTime = i.MaintainExpireTime,
                    CurrentMileage = i.CurrentMileage,
                    NextMaintainMileage = i.NextMaintainMileage,
                    YearlyCheckTime = i.YearlyCheckTime,
                    SecondLevelMaintainTime = i.SecondLevelMaintainTime,
                    LevelCheckTime = i.LevelCheckTime,
                    TailCheckTime = i.TailCheckTime,
                    InsuranceExpireTime = i.InsuranceExpireTime,
                    InsuranceOrg = i.InsuranceOrg,
                    InsuranceNo = i.InsuranceNo,
                    Description = i.Description,

                    FirstServiceTime = i.FirstServiceTime,
                    LastServiceTime = i.LastServiceTime
                }).ToList();
                return cars;
            }
        }

        public List<CarDto> GetAllCarByCustomerId(Guid customerId)
        {
            using (var db = new ModelContext())
            {
                var customerCars = db.Car.Where(i=>i.CustomerId == customerId).Select(i => new CarDto()
                {
                    Id = i.Id,
                    CustomerId = i.CustomerId,
                    CustomerName = i.Customer.Name,
                    CustomerPhone = i.Customer.MobilePhone ?? i.Customer.FixPhone,

                    CarOwnerName = i.CarOwnerName,
                    CarOwnerPhone = i.CarOwnerPhone,

                    VIN = i.VIN,
                    PlateNum = i.PlateNum,
                    ModelId = i.ModelId,
                    BrandName = i.Model.Series.Brand.Name,
                    SeriesName = i.Model.Series.Name,
                    ModelName = i.Model.Name,
                    Price = i.Model.Price,
                    FullName = i.Model.FullName,
                    Color = i.Color,
                    EngineModelNo = i.EngineModelNo,
                    EngineNo = i.EngineNo,
                    CarLabel = i.CarLabel,
                    CarImg = i.CarImg,
                    CarRegisterTime = i.CarRegisterTime,
                    MaintainExpireTime = i.MaintainExpireTime,
                    CurrentMileage = i.CurrentMileage,
                    NextMaintainMileage = i.NextMaintainMileage,
                    YearlyCheckTime = i.YearlyCheckTime,
                    SecondLevelMaintainTime = i.SecondLevelMaintainTime,
                    LevelCheckTime = i.LevelCheckTime,
                    TailCheckTime = i.TailCheckTime,
                    InsuranceExpireTime = i.InsuranceExpireTime,
                    InsuranceOrg = i.InsuranceOrg,
                    InsuranceNo = i.InsuranceNo,
                    Description = i.Description,

                    FirstServiceTime = i.FirstServiceTime,
                    LastServiceTime = i.LastServiceTime
                }).ToList();
                return customerCars;
            }
        }

        public CarDto GetOneCar(Guid carId)
        {
            using (var db=new ModelContext())
            {
                var customerCar = db.Car.Where(i => i.Id == carId).Select(i => new CarDto()
                {
                    Id = i.Id,
                    CustomerId = i.CustomerId,
                    CustomerName = i.Customer.Name,
                    CustomerPhone = i.Customer.MobilePhone ?? i.Customer.FixPhone,

                    CarOwnerName = i.CarOwnerName,
                    CarOwnerPhone = i.CarOwnerPhone,

                    VIN = i.VIN,
                    PlateNum = i.PlateNum,
                    ModelId = i.ModelId,
                    BrandName = i.Model.Series.Brand.Name,
                    SeriesName = i.Model.Series.Name,
                    ModelName = i.Model.Name,
                    Price = i.Model.Price,
                    FullName = i.Model.FullName,
                    Color = i.Color,
                    EngineModelNo = i.EngineModelNo,
                    EngineNo = i.EngineNo,
                    CarLabel = i.CarLabel,
                    CarImg = i.CarImg,
                    CarRegisterTime = i.CarRegisterTime,
                    MaintainExpireTime = i.MaintainExpireTime,
                    CurrentMileage = i.CurrentMileage,
                    NextMaintainMileage = i.NextMaintainMileage,
                    YearlyCheckTime = i.YearlyCheckTime,
                    SecondLevelMaintainTime = i.SecondLevelMaintainTime,
                    LevelCheckTime = i.LevelCheckTime,
                    TailCheckTime = i.TailCheckTime,
                    InsuranceExpireTime = i.InsuranceExpireTime,
                    InsuranceOrg = i.InsuranceOrg,
                    InsuranceNo = i.InsuranceNo,
                    Description = i.Description,

                    FirstServiceTime = i.FirstServiceTime,
                    LastServiceTime = i.LastServiceTime
                }).FirstOrDefault();
                return customerCar;
            }
        }

        public ResModel AddCar(CarDto carDto, UserDto operationUser)
        {
            using (var db=new ModelContext())
            {
                var car = new Car()
                {
                    Id = Guid.NewGuid(),
                    CustomerId = carDto.CustomerId,
                    CarOwnerName = carDto.CarOwnerName,
                    CarOwnerPhone = carDto.CarOwnerPhone,
                    Color = carDto.Color,
                    VIN = carDto.VIN,
                    PlateNum = carDto.PlateNum,
                    ModelId = carDto.ModelId,
                    EngineModelNo = carDto.EngineModelNo,
                    EngineNo = carDto.EngineNo,
                    CarLabel = carDto.CarLabel,
                    CarImg = carDto.CarImg,
                    CarRegisterTime = carDto.CarRegisterTime,
                    MaintainExpireTime = carDto.MaintainExpireTime,
                    CurrentMileage = carDto.CurrentMileage,
                    NextMaintainMileage = carDto.NextMaintainMileage,
                    YearlyCheckTime = carDto.YearlyCheckTime,
                    SecondLevelMaintainTime = carDto.SecondLevelMaintainTime,
                    LevelCheckTime = carDto.LevelCheckTime,
                    TailCheckTime = carDto.TailCheckTime,
                    InsuranceExpireTime = carDto.InsuranceExpireTime,
                    InsuranceOrg = carDto.InsuranceOrg,
                    InsuranceNo = carDto.InsuranceNo,
                    Description = carDto.Description
                };
                try
                {
                    db.Car.Add(car);
                    db.SaveChanges();
                }
                catch (Exception e)
                {
                    return new ResModel(){Msg = "添加车辆信息失败",Success = false};
                }
                return new ResModel() { Msg = "添加车辆信息成功", Success = true };
            }
        }

        public ResModel UpdateCar(CarDto carDto, UserDto operationUser)
        {
            using (var db=new ModelContext())
            {
                var car = db.Car.FirstOrDefault(i => i.Id == carDto.Id);
                if (car == null)
                {
                    return new ResModel(){Msg = "更新车辆信息失败，未找到该车辆信息",Success = false};
                }

                try
                {
                    car.CustomerId = carDto.CustomerId;
                    car.CarOwnerName = carDto.CarOwnerName;
                    car.CarOwnerPhone = carDto.CarOwnerPhone;
                    car.VIN = carDto.VIN;
                    car.PlateNum = carDto.PlateNum;
                    car.ModelId = carDto.ModelId;
                    car.EngineModelNo = carDto.EngineModelNo;
                    car.EngineNo = carDto.EngineNo;
                    car.CarLabel = carDto.CarLabel;
                    car.CarImg = carDto.CarImg;
                    car.CarRegisterTime = carDto.CarRegisterTime;
                    car.MaintainExpireTime = carDto.MaintainExpireTime;
                    car.CurrentMileage = carDto.CurrentMileage;
                    car.NextMaintainMileage = carDto.NextMaintainMileage;
                    car.YearlyCheckTime = carDto.YearlyCheckTime;
                    car.SecondLevelMaintainTime = carDto.SecondLevelMaintainTime;
                    car.LevelCheckTime = carDto.LevelCheckTime;
                    car.TailCheckTime = carDto.TailCheckTime;
                    car.InsuranceExpireTime = carDto.InsuranceExpireTime;
                    car.InsuranceOrg = carDto.InsuranceOrg;
                    car.InsuranceNo = carDto.InsuranceNo;
                    car.Description = carDto.Description;
                    db.SaveChanges();
                }
                catch (Exception e)
                {
                    return new ResModel() { Msg = "更新车辆信息失败", Success = false };
                }
                return new ResModel() { Msg = "更新车辆信息成功", Success = true };
            }
        }

        public ResModel DeleteCar(Guid carId)
        {
            using (var db = new ModelContext())
            {
                var car = db.Car.FirstOrDefault(i => i.Id == carId);
                if (car == null)
                {
                    return new ResModel() { Msg = "删除车辆信息失败，未找到该车辆信息", Success = false };
                }

                try
                {
                    db.Car.Remove(car);
                    db.SaveChanges();
                }
                catch (Exception e)
                {
                    return new ResModel() { Msg = "删除车辆信息失败", Success = false };
                }
                return new ResModel() { Msg = "删除车辆信息成功", Success = true };
            }
        }

        public List<CarDto> QueryCar(string keyWord)
        {
            using (var db=new ModelContext())
            {
                var cars = db.Car.Where(i => i.CarFullName.Contains(keyWord)).Select(i => new CarDto()
                {
                    Id = i.Id,
                    CustomerId = i.CustomerId,
                    CustomerName = i.Customer.Name,
                    CustomerPhone = i.Customer.MobilePhone ?? i.Customer.FixPhone,

                    CarOwnerName = i.CarOwnerName,
                    CarOwnerPhone = i.CarOwnerPhone,

                    VIN = i.VIN,
                    PlateNum = i.PlateNum,
                    ModelId = i.ModelId,
                    BrandName = i.Model.Series.Brand.Name,
                    SeriesName = i.Model.Series.Name,
                    ModelName = i.Model.Name,
                    Price = i.Model.Price,
                    FullName = i.Model.FullName,
                    Color = i.Color,
                    EngineModelNo = i.EngineModelNo,
                    EngineNo = i.EngineNo,
                    CarLabel = i.CarLabel,
                    CarImg = i.CarImg,
                    CarRegisterTime = i.CarRegisterTime,
                    MaintainExpireTime = i.MaintainExpireTime,
                    CurrentMileage = i.CurrentMileage,
                    NextMaintainMileage = i.NextMaintainMileage,
                    YearlyCheckTime = i.YearlyCheckTime,
                    SecondLevelMaintainTime = i.SecondLevelMaintainTime,
                    LevelCheckTime = i.LevelCheckTime,
                    TailCheckTime = i.TailCheckTime,
                    InsuranceExpireTime = i.InsuranceExpireTime,
                    InsuranceOrg = i.InsuranceOrg,
                    InsuranceNo = i.InsuranceNo,
                    Description = i.Description,

                    FirstServiceTime = i.FirstServiceTime,
                    LastServiceTime = i.LastServiceTime
                }).ToList();
                return cars;
            }
        }
    }
}
