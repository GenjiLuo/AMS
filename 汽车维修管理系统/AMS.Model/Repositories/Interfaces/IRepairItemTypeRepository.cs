using System;
using System.Collections.Generic;
using AMS.Model.dto;
using AMS.Model.poco;
using AMS.Model.ResponseModel;

namespace AMS.Model.Repositories.Interfaces
{
    public interface IRepairItemTypeRepository
    {
        List<RepairItemTypeDto> GetAllRepairItemType();
        ResModel AddRepairItemType(RepairItemTypeDto repairItemTypeDto, UserDto operationUser);
        RepairItemTypeDto GetOneRepairItemType(Guid repairItemTypeId);
        ResModel UpdateRepairItemType(RepairItemTypeDto repairItemTypeDto, UserDto operationUser);
        ResModel DeleteRepairItemType(Guid repairItemTypeId);
    }
}
