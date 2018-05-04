using System;
using System.Collections.Generic;
using AMS.Model.dto;
using AMS.Model.Repositories.Implements;
using AMS.Model.Repositories.Interfaces;
using AMS.Model.ResponseModel;
using AMS.Service.Services.Interfaces;

namespace AMS.Service.Services.Implements
{
    public class CarService : ICarService
    {
        private readonly ICarRepository _carRepository;

        public CarService()
        {
            _carRepository = new CarRepository();
        }

        public List<CarDto> GetAllCar()
        {
            return _carRepository.GetAllCar();
        }

        public List<CarDto> GetAllCarByCustomerId(Guid customerId)
        {
            return _carRepository.GetAllCarByCustomerId(customerId);
        }

        public CarDto GetOneCar(Guid carId)
        {
            return _carRepository.GetOneCar(carId);
        }

        public ResModel AddCar(CarDto carDto, UserDto operationUser)
        {
            return _carRepository.AddCar(carDto, operationUser);
        }

        public ResModel UpdateCar(CarDto carDto, UserDto operationUser)
        {
            return _carRepository.UpdateCar(carDto, operationUser);
        }

        public ResModel DeleteCar(Guid carId)
        {
            return _carRepository.DeleteCar(carId);
        }

        public List<CarDto> QueryCar(string keyWord)
        {
            return _carRepository.QueryCar(keyWord);
        }
    }
}
