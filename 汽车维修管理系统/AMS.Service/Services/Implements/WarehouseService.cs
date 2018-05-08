using System;
using System.Collections.Generic;
using AMS.Model.dto;
using AMS.Model.Repositories.Implements;
using AMS.Model.Repositories.Interfaces;
using AMS.Model.ResponseModel;
using AMS.Service.Services.Interfaces;

namespace AMS.Service.Services.Implements
{
    public class WarehouseService : IWarehouseService
    {
        private readonly IWarehouseRepository _warehouseRepository;

        public WarehouseService()
        {
            _warehouseRepository=new WarehouseRepository();
        }

        public List<WarehouseDto> GetAllWarehouse()
        {
            return _warehouseRepository.GetAllWarehouse();
        }

        public ResModel AddWarehouse(WarehouseDto warehouseDto, UserDto operationUser)
        {
            return _warehouseRepository.AddWarehouse(warehouseDto, operationUser);
        }

        public WarehouseDto GetOneWarehouse(Guid warehouseId)
        {
            return _warehouseRepository.GetOneWarehouse(warehouseId);
        }

        public ResModel UpdateWarehouse(WarehouseDto warehouseDto, UserDto operationUser)
        {
            return _warehouseRepository.UpdateWarehouse(warehouseDto, operationUser);
        }

        public ResModel DeleteWarehouse(Guid warehouseId)
        {
            return _warehouseRepository.DeleteWarehouse(warehouseId);
        }

        public List<WarehouseDto> QueryWarehouse(string keyword)
        {
            return _warehouseRepository.QueryWarehouse(keyword);
        }
    }
}
