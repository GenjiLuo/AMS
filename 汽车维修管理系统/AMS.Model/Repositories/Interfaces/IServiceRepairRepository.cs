using System;
using System.Collections.Generic;
using AMS.Model.dto;
using AMS.Model.poco;
using AMS.Model.ResponseModel;

namespace AMS.Model.Repositories.Interfaces
{
    public interface IServiceRepairRepository
    {
        List<ServiceRepairDto> GetAllServiceRepair();
        ResModel AddServiceRepair(ServiceRepairDto serviceRepairDto, UserDto operationUser);
        ServiceRepairDto GetOneServiceRepair(Guid serviceRepairId);
        ResModel UpdateServiceRepair(ServiceRepairDto serviceRepairDto, UserDto operationUser);
        ResModel DeleteServiceRepair(Guid serviceRepairId);
        List<ServiceRepairDto> QueryServiceRepair(string keyword);
        List<ServiceRepairHistoryDto> GetAllRepairHistory();
        List<ServiceRepairHistoryDto> GetHistoryRepairByCarId(Guid carId);
        ResModel TurnToFinish(Guid serviceRepairId, UserDto operationUser);
        ResModel TurnToInvalid(Guid serviceRepairId, UserDto operationUser);
        ResModel Finish(ServiceRepairDto serviceRepairDto, UserDto operationUser);
    }
}
