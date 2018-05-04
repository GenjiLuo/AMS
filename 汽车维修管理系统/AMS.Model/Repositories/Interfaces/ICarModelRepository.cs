using System;
using System.Collections.Generic;
using AMS.Model.dto;
using AMS.Model.ResponseModel;

namespace AMS.Model.Repositories.Interfaces
{
    public interface ICarModelRepository
    {
        List<CarModelDto> GetAllCarModel();
        CarModelDto GetOneCarModel(Guid carModelId);
        ResModel AddCarModel(CarModelDto carModelDto, UserDto operationUser);
        ResModel UpdateCarModel(CarModelDto carModelDto, UserDto operationUser);
        ResModel DeleteCarModel(Guid carModelId);
        List<CarModelDto> QueryCarModel(string keyWord);
        List<string> GetBrandNameByKeyWord(string brandKeyWord);
        List<string> GetSeriesNameByBrandAndKeyWord(string brandName, string seriesKeyWord);
        List<string> GetModelNameBySeriesAndKeyWord(string seriesName, string modelKeyWord);
    }
}
