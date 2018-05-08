using System;
using System.Collections.Generic;
using AMS.Model.dto;
using AMS.Model.poco;
using AMS.Model.ResponseModel;

namespace AMS.Model.Repositories.Interfaces
{
    public interface IWarehouseRepository
    {
        List<WarehouseDto> GetAllWarehouse();
        ResModel AddWarehouse(WarehouseDto warehouseDto, UserDto operationUser);
        WarehouseDto GetOneWarehouse(Guid warehouseId);
        ResModel UpdateWarehouse(WarehouseDto warehouseDto, UserDto operationUser);
        ResModel DeleteWarehouse(Guid warehouseId);
        List<WarehouseDto> QueryWarehouse(string keyword);
    }
}
