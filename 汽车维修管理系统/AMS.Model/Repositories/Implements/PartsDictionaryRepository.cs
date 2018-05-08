using System;
using System.Collections.Generic;
using System.Linq;
using System.Transactions;
using AMS.Model.dto;
using AMS.Model.poco;
using AMS.Model.Repositories.Interfaces;
using AMS.Model.ResponseModel;

namespace AMS.Model.Repositories.Implements
{
    public class PartsDictionaryRepository : IPartsDictionaryRepository
    {
        public List<PartsDictionaryDto> GetAllPartsDictionary()
        {
            using (var db = new ModelContext())
            {
                var partsDictionaries = db.PartsDictionary.Select(i => new PartsDictionaryDto()
                {
                    Id = i.Id,
                    Name = i.Name,
                    Code = i.Code,
                    PartsTypeId = i.PartsTypeId,
                    PartsTypeName = i.PartsType.Name,
                    MeasurementUnit = i.MeasurementUnit,
                    PartsDictionarySuitedCarModelDtos = i.PartsDictionarySuitedCarModel.Select(j => new PartsDictionarySuitedCarModelDto()
                    {
                        Id = j.Id,
                        PartsDictionaryId = j.PartsDictionaryId,
                        BrandId = j.BrandId,
                        CarBrandName = j.CarBrand.Name,
                        SeriesId = j.SeriesId,
                        CarSeriesName = j.CarSeries.Name,
                        ModelId = j.ModelId,
                        CarModelName = j.CarModel.Name,
                        CreateTime = j.CreateTime
                    }).ToList().OrderBy(k=>k.CreateTime).ToList(),
                    SupplierPrice = i.SupplierPrice,
                    RetailPrice = i.RetailPrice,
                    TradePrice = i.TradePrice,
                    AdjustPrice = i.AdjustPrice,
                    ClaimPrice = i.ClaimPrice,
                    BrandName = i.BrandName,
                    Specifications = i.Specifications,
                    ProducedAddress = i.ProducedAddress,
                    Label = i.Label,
                    Description = i.Description
                }).ToList();
                return partsDictionaries;
            }
        }

        public PartsDictionaryDto GetOnePartsDictionary(Guid partsDictionaryId)
        {
            using (var db = new ModelContext())
            {
                var partsDictionary = db.PartsDictionary.Where(i=>i.Id == partsDictionaryId).Select(i => new PartsDictionaryDto()
                {
                    Id = i.Id,
                    Name = i.Name,
                    Code = i.Code,
                    PartsTypeId = i.PartsTypeId,
                    PartsTypeName = i.PartsType.Name,
                    MeasurementUnit = i.MeasurementUnit,
                    PartsDictionarySuitedCarModelDtos = i.PartsDictionarySuitedCarModel.Select(j => new PartsDictionarySuitedCarModelDto()
                    {
                        Id = j.Id,
                        PartsDictionaryId = j.PartsDictionaryId,
                        PartsDictionaryName = j.PartsDictionary.Name,
                        BrandId = j.BrandId,
                        CarBrandName = j.CarBrand.Name,
                        SeriesId = j.SeriesId,
                        CarSeriesName = j.CarSeries.Name,
                        ModelId = j.ModelId,
                        CarModelName = j.CarModel.Name,
                        CreateTime = j.CreateTime
                    }).ToList().OrderBy(k => k.CreateTime).ToList(),
                    SupplierPrice = i.SupplierPrice,
                    RetailPrice = i.RetailPrice,
                    TradePrice = i.TradePrice,
                    AdjustPrice = i.AdjustPrice,
                    ClaimPrice = i.ClaimPrice,
                    BrandName = i.BrandName,
                    Specifications = i.Specifications,
                    ProducedAddress = i.ProducedAddress,
                    Label = i.Label,
                    Description = i.Description
                }).FirstOrDefault();
                return partsDictionary;
            }
        }

        public ResModel AddPartsDictionary(PartsDictionaryDto partsDictionaryDto, UserDto operationUser)
        {
            using (var db=new ModelContext())
            {
                var partsDictionary = new PartsDictionary()
                {
                    Id = Guid.NewGuid(),
                    Name = partsDictionaryDto.Name,
                    Code = partsDictionaryDto.Code,
                    PartsTypeId = partsDictionaryDto.PartsTypeId,
                    MeasurementUnit = partsDictionaryDto.MeasurementUnit,
                    SupplierPrice = partsDictionaryDto.SupplierPrice,
                    RetailPrice = partsDictionaryDto.RetailPrice,
                    TradePrice = partsDictionaryDto.TradePrice,
                    AdjustPrice = partsDictionaryDto.AdjustPrice,
                    ClaimPrice = partsDictionaryDto.ClaimPrice,
                    BrandName = partsDictionaryDto.BrandName,
                    Specifications = partsDictionaryDto.Specifications,
                    ProducedAddress = partsDictionaryDto.ProducedAddress,
                    Label = partsDictionaryDto.Label,
                    Description = partsDictionaryDto.Description
                };
                var partsDictionaySuitedCarModels = partsDictionaryDto.PartsDictionarySuitedCarModelDtos.Select(
                        i => new PartsDictionarySuitedCarModel()
                        {
                            Id = Guid.NewGuid(),
                            PartsDictionaryId = partsDictionary.Id,
                            BrandId = i.BrandId,
                            SeriesId = i.SeriesId,
                            ModelId = i.ModelId,
                            CreateTime = DateTime.Now
                        });
                using (var scope=new TransactionScope())
                {
                    try
                    {
                        db.PartsDictionary.Add(partsDictionary);
                        db.PartsDictionarySuitedCarModel.AddRange(partsDictionaySuitedCarModels);
                        db.SaveChanges();
                        scope.Complete();
                    }
                    catch (Exception e)
                    {
                        return new ResModel(){Msg = "添加失败",Success = false};
                    }
                    return new ResModel() { Msg = "添加成功", Success = true };
                }
            }
        }

        public ResModel UpdatePartsDictionary(PartsDictionaryDto partsDictionaryDto, UserDto operationUser)
        {
            using (var db=new ModelContext())
            {
                var partsDictionary = db.PartsDictionary.FirstOrDefault(i => i.Id == partsDictionaryDto.Id);
                if (partsDictionary == null)
                {
                    return new ResModel(){Msg = "更新失败,未找到该配件档案",Success = false};
                }

                var partsDictionaySuitedCarModels = partsDictionaryDto.PartsDictionarySuitedCarModelDtos.Select(
                        i => new PartsDictionarySuitedCarModel()
                        {
                            Id = Guid.NewGuid(),
                            PartsDictionaryId = partsDictionary.Id,
                            BrandId = i.BrandId,
                            SeriesId = i.SeriesId,
                            ModelId = i.ModelId,
                            CreateTime = DateTime.Now
                        });
                using (var scope=new TransactionScope())
                {
                    try
                    {
                        partsDictionary.Name = partsDictionaryDto.Name;
                        partsDictionary.Code = partsDictionaryDto.Code;
                        partsDictionary.PartsTypeId = partsDictionaryDto.PartsTypeId;
                        partsDictionary.MeasurementUnit = partsDictionaryDto.MeasurementUnit;
                        partsDictionary.SupplierPrice = partsDictionaryDto.SupplierPrice;
                        partsDictionary.RetailPrice = partsDictionaryDto.RetailPrice;
                        partsDictionary.TradePrice = partsDictionaryDto.TradePrice;
                        partsDictionary.AdjustPrice = partsDictionaryDto.AdjustPrice;
                        partsDictionary.ClaimPrice = partsDictionaryDto.ClaimPrice;
                        partsDictionary.BrandName = partsDictionaryDto.BrandName;
                        partsDictionary.Specifications = partsDictionaryDto.Specifications;
                        partsDictionary.ProducedAddress = partsDictionaryDto.ProducedAddress;
                        partsDictionary.Label = partsDictionaryDto.Label;
                        partsDictionary.Description = partsDictionaryDto.Description;

                        db.PartsDictionarySuitedCarModel.RemoveRange(partsDictionary.PartsDictionarySuitedCarModel);
                        db.SaveChanges();
                        db.PartsDictionarySuitedCarModel.AddRange(partsDictionaySuitedCarModels);
                        db.SaveChanges();
                        scope.Complete();
                    }
                    catch (Exception e)
                    {
                        return new ResModel(){Msg = "更新失败",Success = false};
                    }
                    return new ResModel() { Msg = "更新成功", Success = true };
                }
            }
        }

        public ResModel DeletePartsDictionary(Guid partsDictionaryId)
        {
            using (var db = new ModelContext())
            {
                var partsDictionary = db.PartsDictionary.FirstOrDefault(i => i.Id == partsDictionaryId);
                if (partsDictionary == null)
                {
                    return new ResModel() { Msg = "删除失败,未找到该配件档案", Success = false };
                }

                using (var scope = new TransactionScope())
                {
                    try
                    {
                        db.PartsDictionarySuitedCarModel.RemoveRange(partsDictionary.PartsDictionarySuitedCarModel);
                        db.SaveChanges();
                        db.PartsDictionary.Remove(partsDictionary);
                        db.SaveChanges();
                        scope.Complete();
                    }
                    catch (Exception e)
                    {
                        return new ResModel() { Msg = "删除失败", Success = false };
                    }
                    return new ResModel() { Msg = "删除成功", Success = true };
                }
            }
        }

        public List<PartsDictionaryDto> QueryPartsDictionary(string keyWord)
        {
            using (var db = new ModelContext())
            {
                var partsDictionaries = db.PartsDictionary.Where(i=>i.Name.Contains(keyWord)).Select(i => new PartsDictionaryDto()
                {
                    Id = i.Id,
                    Name = i.Name,
                    Code = i.Code,
                    PartsTypeId = i.PartsTypeId,
                    PartsTypeName = i.PartsType.Name,
                    MeasurementUnit = i.MeasurementUnit,
                    PartsDictionarySuitedCarModelDtos = i.PartsDictionarySuitedCarModel.Select(j => new PartsDictionarySuitedCarModelDto()
                    {
                        Id = j.Id,
                        PartsDictionaryId = j.PartsDictionaryId,
                        BrandId = j.BrandId,
                        CarBrandName = j.CarBrand.Name,
                        SeriesId = j.SeriesId,
                        CarSeriesName = j.CarSeries.Name,
                        ModelId = j.ModelId,
                        CarModelName = j.CarModel.Name
                    }).ToList().OrderBy(k => k.CreateTime).ToList(),
                    SupplierPrice = i.SupplierPrice,
                    RetailPrice = i.RetailPrice,
                    TradePrice = i.TradePrice,
                    AdjustPrice = i.AdjustPrice,
                    ClaimPrice = i.ClaimPrice,
                    BrandName = i.BrandName,
                    Specifications = i.Specifications,
                    ProducedAddress = i.ProducedAddress,
                    Label = i.Label,
                    Description = i.Description
                }).ToList();
                return partsDictionaries;
            }
        }
    }
}
