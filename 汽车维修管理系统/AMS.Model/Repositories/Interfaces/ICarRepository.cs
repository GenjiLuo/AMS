using System;
using System.Collections.Generic;
using AMS.Model.dto;
using AMS.Model.ResponseModel;

namespace AMS.Model.Repositories.Interfaces
{
    public interface ICarRepository
    {
        List<CarDto> GetAllCar();
        List<CarDto> GetAllCarByCustomerId(Guid customerId);
        CarDto GetOneCar(Guid carId);
        ResModel AddCar(CarDto carDto, UserDto operationUser);
        ResModel UpdateCar(CarDto carDto, UserDto operationUser);
        ResModel DeleteCar(Guid carId);
        List<CarDto> QueryCar(string keyWord);
    }
}
