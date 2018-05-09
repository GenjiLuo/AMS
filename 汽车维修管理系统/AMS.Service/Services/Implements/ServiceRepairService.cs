using System;
using System.Collections.Generic;
using AMS.Model.dto;
using AMS.Model.Repositories.Implements;
using AMS.Model.Repositories.Interfaces;
using AMS.Model.ResponseModel;
using AMS.Service.Services.Interfaces;

namespace AMS.Service.Services.Implements
{
    public class ServiceRepairService : IServiceRepairService
    {
        private readonly IServiceRepairRepository _serviceRepairRepository;

        public ServiceRepairService()
        {
            _serviceRepairRepository=new ServiceRepairRepository();
        }

        public List<ServiceRepairDto> GetAllServiceRepair()
        {
            return _serviceRepairRepository.GetAllServiceRepair();
        }

        public ResModel AddServiceRepair(ServiceRepairDto serviceRepairDto, UserDto operationUser)
        {
            return _serviceRepairRepository.AddServiceRepair(serviceRepairDto, operationUser);
        }

        public ServiceRepairDto GetOneServiceRepair(Guid serviceRepairId)
        {
            return _serviceRepairRepository.GetOneServiceRepair(serviceRepairId);
        }

        public ResModel UpdateServiceRepair(ServiceRepairDto serviceRepairDto, UserDto operationUser)
        {
            return _serviceRepairRepository.UpdateServiceRepair(serviceRepairDto, operationUser);
        }

        public ResModel DeleteServiceRepair(Guid serviceRepairId)
        {
            return _serviceRepairRepository.DeleteServiceRepair(serviceRepairId);
        }

        public List<ServiceRepairDto> QueryServiceRepair(string keyword)
        {
            return _serviceRepairRepository.QueryServiceRepair(keyword);
        }
    }
}
