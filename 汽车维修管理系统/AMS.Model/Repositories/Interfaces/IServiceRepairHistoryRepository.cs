using System;
using System.Collections.Generic;
using AMS.Model.dto;

namespace AMS.Model.Repositories.Interfaces
{
    public interface IServiceRepairHistoryRepository
    {
        List<ServiceRepairHistoryDto> GetAllHistory();
        List<ServiceRepairHistoryDto> GetHistoryRepairByCarId(Guid carId);
    }
}
