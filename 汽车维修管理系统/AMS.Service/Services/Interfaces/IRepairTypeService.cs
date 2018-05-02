using System;
using System.Collections.Generic;
using AMS.Model.dto;
using AMS.Model.ResponseModel;

namespace AMS.Service.Services.Interfaces
{
    public interface IRepairTypeService
    {
        List<RepairTypeDto> GetAllRepairType();
        ResModel AddRepairType(RepairTypeDto repairTypeDto, UserDto operationUser);
        RepairTypeDto GetOneRepairType(Guid repairTypeId);
        ResModel UpdateRepairType(RepairTypeDto repairTypeDto, UserDto operationUser);
        ResModel DeleteRepairType(Guid repairTypeId);
    }
}
