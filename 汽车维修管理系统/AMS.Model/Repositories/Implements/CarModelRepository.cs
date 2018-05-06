using System;
using System.Collections.Generic;
using System.Data.Entity.Migrations;
using System.Linq;
using System.Transactions;
using AMS.Model.dto;
using AMS.Model.poco;
using AMS.Model.Repositories.Interfaces;
using AMS.Model.ResponseModel;

namespace AMS.Model.Repositories.Implements
{
    public class CarModelRepository : ICarModelRepository
    {
        public List<CarModelDto> GetAllCarModel()
        {
            using (var db=new ModelContext())
            {
                var carModels = db.CarModel.Select(i => new CarModelDto()
                {
                    Id = i.Id,
                    Name = i.Name,
                    Price = i.Price,
                    FullName = i.FullName,
                    Color = i.Color,
                    BrandId = i.Series.BrandId,
                    BrandName = i.Series.Brand.Name,
                    SeriesId = i.SeriesId,
                    SeriesName = i.Series.Name
                }).ToList();
                return carModels;
            }
        }

        public CarModelDto GetOneCarModel(Guid carModelId)
        {
            using (var db = new ModelContext())
            {
                var carModel = db.CarModel.Where(i=>i.Id == carModelId).Select(i => new CarModelDto()
                {
                    Id = i.Id,
                    Name = i.Name,
                    Price = i.Price,
                    FullName = i.FullName,
                    Color = i.Color,
                    BrandId = i.Series.BrandId,
                    BrandName = i.Series.Brand.Name,
                    SeriesId = i.SeriesId,
                    SeriesName = i.Series.Name
                }).FirstOrDefault();
                return carModel;
            }
        }

        public ResModel AddCarModel(CarModelDto carModelDto, UserDto operationUser)
        {
            using (var db=new ModelContext())
            {
                //判断车型全称是否有相同的，如果有，则存在相同的品牌名、系列名、型号名，即车型相同
                if (db.CarModel.Any(i => i.FullName == carModelDto.FullName))
                {
                    return new ResModel(){Msg = "添加车型信息失败，已存在该车型信息",Success = false};
                }
                var carBrand = db.CarBrand.FirstOrDefault(i => i.Name == carModelDto.BrandName) ?? new CarBrand()
                {
                    Id = Guid.NewGuid(),
                    Name = carModelDto.BrandName
                };
                //判断同一个品牌下，是否存在相同的系列名
                var carSeries = db.CarSeries.FirstOrDefault(i => i.Name == carModelDto.SeriesName && i.Brand.Name == carModelDto.BrandName) ?? new CarSeries()
                {
                    Id = Guid.NewGuid(),
                    Name = carModelDto.SeriesName,
                    BrandId = carBrand.Id
                };
                var carModel=new CarModel()
                {
                    Id = Guid.NewGuid(),
                    Name = carModelDto.Name,
                    Price = carModelDto.Price,
                    FullName = carModelDto.FullName,
                    Color = carModelDto.Color,
                    SeriesId = carSeries.Id
                };
                using (var scope=new TransactionScope())
                {
                    try
                    {
                        db.CarBrand.AddOrUpdate(carBrand);
                        db.CarSeries.AddOrUpdate(carSeries);
                        db.CarModel.Add(carModel);
                        db.SaveChanges();
                        scope.Complete();
                    }
                    catch (Exception e)
                    {
                        return new ResModel(){Msg = "添加车型信息失败",Success = false};
                    }
                    return new ResModel() { Msg = "添加车型信息成功", Success = true };
                }
            }
        }

        public ResModel UpdateCarModel(CarModelDto carModelDto, UserDto operationUser)
        {
            using (var db=new ModelContext())
            {
                var carModel = db.CarModel.FirstOrDefault(i => i.Id == carModelDto.Id);
                if (carModel == null)
                {
                    return new ResModel(){Msg = "更新车型信息失败，未找到该车型",Success = false};
                }
                //判断车型全称是否有相同的，如果有，则存在相同的品牌名、系列名、型号名，即车型相同
                if (db.CarModel.Any(i => i.FullName == carModelDto.FullName))
                {
                    return new ResModel() { Msg = "更新车型信息失败，已存在相同车型信息", Success = false };
                }
                var carBrand = db.CarBrand.FirstOrDefault(i => i.Name == carModelDto.BrandName) ?? new CarBrand()
                {
                    Id = Guid.NewGuid(),
                    Name = carModelDto.BrandName
                };
                //判断同一个品牌下，是否存在该系列
                var carSeries = db.CarSeries.FirstOrDefault(i => i.Name == carModelDto.SeriesName && i.Brand.Name == carModelDto.BrandName) ?? new CarSeries()
                {
                    Id = Guid.NewGuid(),
                    Name = carModelDto.SeriesName,
                    BrandId = carBrand.Id
                };
                carModel.Name = carModelDto.Name;
                carModel.Price = carModelDto.Price;
                carModel.FullName = carModelDto.FullName;
                carModel.Color = carModelDto.Color;
                carModel.SeriesId = carSeries.Id;
                using (var scope=new TransactionScope())
                {
                    try
                    {
                        db.CarBrand.AddOrUpdate(carBrand);
                        db.CarSeries.AddOrUpdate(carSeries);
                        db.SaveChanges();
                        scope.Complete();
                    }
                    catch (Exception e)
                    {
                        return new ResModel() { Msg = "更新车型信息失败", Success = false };
                    }
                    return new ResModel() { Msg = "更新车型信息成功", Success = true };
                }
            }
        }

        public ResModel DeleteCarModel(Guid carModelId)
        {
            using (var db = new ModelContext())
            {
                var carModel = db.CarModel.FirstOrDefault(i => i.Id == carModelId);
                if (carModel == null)
                {
                    return new ResModel() { Msg = "删除车型信息失败，未找到该车型", Success = false };
                }

                try
                {
                    db.CarModel.Remove(carModel);
                    db.SaveChanges();
                }
                catch (Exception e)
                {
                    return new ResModel() { Msg = "删除车型信息失败", Success = false };
                }
                return new ResModel() { Msg = "删除车型信息成功", Success = true };
            }
        }

        public List<CarModelDto> QueryCarModel(string keyWord)
        {
            using (var db = new ModelContext())
            {
                var carModels = db.CarModel.Where(i=>i.FullName.Contains(keyWord)).Select(i => new CarModelDto()
                {
                    Id = i.Id,
                    Name = i.Name,
                    Price = i.Price,
                    FullName = i.FullName,
                    Color = i.Color,
                    BrandId = i.Series.BrandId,
                    BrandName = i.Series.Brand.Name,
                    SeriesId = i.SeriesId,
                    SeriesName = i.Series.Name
                }).ToList();
                return carModels;
            }
        }

        public List<CarBrandDto> GetBrandByKeyWord(string brandKeyWord)
        {
            using (var db=new ModelContext())
            {
                var brands = db.CarBrand.Where(i => i.Name.Contains(brandKeyWord))
                    .Select(i => new CarBrandDto()
                    {
                        Id = i.Id,
                        Name = i.Name
                    }).ToList();
                return brands;
            }
        }

        public List<CarSeriesDto> GetSeriesByBrandAndKeyWord(string brandName, string seriesKeyWord)
        {
            using (var db=new ModelContext())
            {
                var series = db.CarSeries.Where(i => i.Brand.Name == brandName && i.Name.Contains(seriesKeyWord))
                    .Select(i => new CarSeriesDto()
                    {
                        Id = i.Id,
                        Name = i.Name,
                        BrandId = i.BrandId,
                        BrandName = i.Brand.Name
                    }).ToList();
                return series;
            }
        }

        public List<CarModelDto> GetModelBySeriesAndKeyWord(string seriesName, string modelKeyWord)
        {
            using (var db = new ModelContext())
            {
                var models = db.CarModel.Where(i => i.Series.Name == seriesName && i.Name.Contains(modelKeyWord))
                    .Select(i => new CarModelDto()
                    {
                        Id = i.Id,
                        Name = i.Name,
                        SeriesId = i.SeriesId,
                        SeriesName = i.Series.Name,
                        BrandId = i.Series.BrandId,
                        BrandName = i.Series.Brand.Name
                    }).ToList();
                return models;
            }
        }
    }
}
