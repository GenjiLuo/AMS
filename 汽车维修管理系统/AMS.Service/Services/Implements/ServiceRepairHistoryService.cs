using System.Collections.Generic;
using AMS.Model.dto;
using AMS.Model.Repositories.Implements;
using AMS.Model.Repositories.Interfaces;
using AMS.Service.Services.Interfaces;

namespace AMS.Service.Services.Implements
{
    public class ServiceRepairHistoryService : IServiceRepairHistoryService
    {
        private readonly IServiceRepairHistoryRepository _serviceRepairHistoryRepository;
        public ServiceRepairHistoryService()
        {
            _serviceRepairHistoryRepository=new ServiceRepairHistoryRepository();
        }

        public List<ServiceRepairHistoryDto> GetAllHistory()
        {
            return _serviceRepairHistoryRepository.GetAllHistory();
        }
    }
}
