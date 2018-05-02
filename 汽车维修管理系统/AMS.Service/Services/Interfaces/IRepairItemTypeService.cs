using System;
using System.Collections.Generic;
using AMS.Model.dto;
using AMS.Model.ResponseModel;

namespace AMS.Service.Services.Interfaces
{
    public interface IRepairItemTypeService
    {
        List<RepairItemTypeDto> GetAllRepairItemType();
        ResModel AddRepairItemType(RepairItemTypeDto repairItemTypeDto, UserDto operationUser);
        RepairItemTypeDto GetOneRepairItemType(Guid repairItemTypeId);
        ResModel UpdateRepairItemType(RepairItemTypeDto repairItemTypeDto, UserDto operationUser);
        ResModel DeleteRepairItemType(Guid repairItemTypeId);
    }
}
