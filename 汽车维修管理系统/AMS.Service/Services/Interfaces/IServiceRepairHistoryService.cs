using System;
using System.Collections.Generic;
using AMS.Model.dto;
using AMS.Model.ResponseModel;

namespace AMS.Service.Services.Interfaces
{
    public interface IServiceRepairHistoryService
    {
        List<ServiceRepairHistoryDto> GetAllHistory();
        List<ServiceRepairHistoryDto> GetHistoryRepairByCarId(Guid carId);
    }
}
