using System;
using System.Collections.Generic;
using AMS.Model.dto;
using AMS.Model.ResponseModel;

namespace AMS.Service.Services.Interfaces
{
    public interface IServiceRepairService
    {
        List<ServiceRepairDto> GetAllServiceRepair();
        ResModel AddServiceRepair(ServiceRepairDto serviceRepairDto, UserDto operationUser);
        ServiceRepairDto GetOneServiceRepair(Guid serviceRepairId);
        ResModel UpdateServiceRepair(ServiceRepairDto serviceRepairDto, UserDto operationUser);
        ResModel DeleteServiceRepair(Guid serviceRepairId);
        List<ServiceRepairDto> QueryServiceRepair(string keyword);
        List<ServiceRepairHistoryDto> GetAllRepairHistory();
        List<ServiceRepairHistoryDto> GetHistoryRepairByCarId(Guid carId);
        ResModel TurnToFinish(Guid serviceRepairId);
    }
}
