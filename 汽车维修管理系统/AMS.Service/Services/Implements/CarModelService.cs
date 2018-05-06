using System;
using System.Collections.Generic;
using AMS.Model.dto;
using AMS.Model.Repositories.Implements;
using AMS.Model.Repositories.Interfaces;
using AMS.Model.ResponseModel;
using AMS.Service.Services.Interfaces;

namespace AMS.Service.Services.Implements
{
    public class CarModelService : ICarModelService
    {
        private readonly ICarModelRepository _carModelRepository;

        public CarModelService()
        {
            _carModelRepository=new CarModelRepository();
        }
        public List<CarModelDto> GetAllCarModel()
        {
            return _carModelRepository.GetAllCarModel();
        }

        public CarModelDto GetOneCarModel(Guid carModelId)
        {
            return _carModelRepository.GetOneCarModel(carModelId);
        }

        public ResModel AddCarModel(CarModelDto carModelDto, UserDto operationUser)
        {
            return _carModelRepository.AddCarModel(carModelDto, operationUser);
        }

        public ResModel UpdateCarModel(CarModelDto carModelDto, UserDto operationUser)
        {
            return _carModelRepository.UpdateCarModel(carModelDto, operationUser);
        }

        public ResModel DeleteCarModel(Guid carModelId)
        {
            return _carModelRepository.DeleteCarModel(carModelId);
        }

        public List<CarModelDto> QueryCarModel(string keyWord)
        {
            return _carModelRepository.QueryCarModel(keyWord);
        }

        public List<CarBrandDto> GetBrandByKeyWord(string brandKeyWord)
        {
            return _carModelRepository.GetBrandByKeyWord(brandKeyWord);
        }

        public List<CarSeriesDto> GetSeriesByBrandAndKeyWord(string brandName, string seriesKeyWord)
        {
            return _carModelRepository.GetSeriesByBrandAndKeyWord(brandName,seriesKeyWord);
        }

        public List<CarModelDto> GetModelBySeriesAndKeyWord(string seriesName, string modelKeyWord)
        {
            return _carModelRepository.GetModelBySeriesAndKeyWord(seriesName,modelKeyWord);
        }
    }
}
