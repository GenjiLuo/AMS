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
                    BrandName = i.BrandName,
                    SeriesName = i.SeriesName,
                    ModelNo = i.ModelNo,
                    Price = i.Price,
                    FullName = i.FullName,
                    Color = i.Color 
                }).ToList();
                return cars;
            }
        }

        public CarDto GetOneCar(Guid carId)
        {
            using (var db=new ModelContext())
            {
                var car = db.Car.Where(i => i.Id == carId).Select(i=>new CarDto()
                {
                    Id = i.Id,
                    BrandName = i.BrandName,
                    SeriesName = i.SeriesName,
                    ModelNo = i.ModelNo,
                    Price = i.Price,
                    FullName = i.FullName,
                    Color = i.Color
                }).FirstOrDefault();
                return car;
            }
        }

        public ResModel AddCar(CarDto carDto, UserDto operationUser)
        {
            using (var db=new ModelContext())
            {
                var car = new Car()
                {
                    Id = Guid.NewGuid(),
                    BrandName = carDto.BrandName,
                    SeriesName = carDto.SeriesName,
                    ModelNo = carDto.ModelNo,
                    Price = carDto.Price,
                    FullName = carDto.FullName,
                    Color = carDto.Color
                };
                try
                {
                    db.Car.Add(car);
                    db.SaveChanges();
                }
                catch (Exception e)
                {
                    return new ResModel(){Msg = "添加车型信息失败",Success = false};
                }
                return new ResModel() { Msg = "添加车型信息成功", Success = true };
            }
        }

        public ResModel UpdateCar(CarDto carDto, UserDto operationUser)
        {
            using (var db=new ModelContext())
            {
                var car = db.Car.FirstOrDefault(i => i.Id == carDto.Id);
                if (car == null)
                {
                    return new ResModel(){Msg = "更新车型信息失败,未找到该车辆",Success = false};
                }

                try
                {
                    car.BrandName = carDto.BrandName;
                    car.SeriesName = carDto.SeriesName;
                    car.ModelNo = carDto.ModelNo;
                    car.Price = carDto.Price;
                    car.FullName = carDto.FullName;
                    car.Color = carDto.Color;
                    db.SaveChanges();
                }
                catch (Exception e)
                {
                    return new ResModel() { Msg = "更新车型信息失败", Success = false };
                }
                return new ResModel() { Msg = "更新车型信息成功", Success = true };
            }
        }

        public ResModel DeleteCar(Guid carId)
        {
            using (var db = new ModelContext())
            {
                var car = db.Car.FirstOrDefault(i => i.Id == carId);
                if (car == null)
                {
                    return new ResModel() { Msg = "删除车型信息失败,未找到该车辆", Success = false };
                }

                try
                {
                    db.Car.Remove(car);
                    db.SaveChanges();
                }
                catch (Exception e)
                {
                    return new ResModel() { Msg = "删除车型信息失败", Success = false };
                }
                return new ResModel() { Msg = "删除车型信息成功", Success = true };
            }
        }

        public List<CarDto> QueryCar(string keyWord)
        {
            using (var db=new ModelContext())
            {
                var cars = db.Car.Where(i => i.FullName.Contains(keyWord)).Select(i => new CarDto()
                {
                    Id = i.Id,
                    BrandName = i.BrandName,
                    SeriesName = i.SeriesName,
                    ModelNo = i.ModelNo,
                    Price = i.Price,
                    FullName = i.FullName,
                    Color = i.Color
                }).ToList();
                return cars;
            }
        }
    }
}
