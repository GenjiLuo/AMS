using System;
using System.Collections.Generic;
using AMS.Model.dto;
using AMS.Model.ResponseModel;

namespace AMS.Service.Services.Interfaces
{
    public interface IWarehouseService
    {
        List<WarehouseDto> GetAllWarehouse();
        ResModel AddWarehouse(WarehouseDto warehouseDto, UserDto operationUser);
        WarehouseDto GetOneWarehouse(Guid warehouseId);
        ResModel UpdateWarehouse(WarehouseDto warehouseDto, UserDto operationUser);
        ResModel DeleteWarehouse(Guid warehouseId);
        List<WarehouseDto> QueryWarehouse(string keyword);
    }
}
