using System;
using System.Collections.Generic;
using AMS.Model.dto;
using AMS.Model.poco;
using AMS.Model.ResponseModel;

namespace AMS.Model.Repositories.Interfaces
{
    public interface IRepairItemRepository
    {
        List<RepairItemDto> GetAllRepairItem();
        ResModel AddRepairItem(RepairItemDto repairItemDto, UserDto operationUser);
        RepairItemDto GetOneRepairItem(Guid repairItemId);
        ResModel UpdateRepairItem(RepairItemDto repairItemDto, UserDto operationUser);
        ResModel DeleteRepairItem(Guid repairItemId);
    }
}
