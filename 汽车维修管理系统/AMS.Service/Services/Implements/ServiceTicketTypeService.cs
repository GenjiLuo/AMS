using System;
using System.Collections.Generic;
using AMS.Model.dto;
using AMS.Model.Repositories.Implements;
using AMS.Model.Repositories.Interfaces;
using AMS.Model.ResponseModel;
using AMS.Service.Services.Interfaces;

namespace AMS.Service.Services.Implements
{
    public class ServiceTicketTypeService : IServiceTicketTypeService
    {
        private readonly IServiceTicketTypeRepository _serviceTicketTypeRepository;

        public ServiceTicketTypeService()
        {
            _serviceTicketTypeRepository=new ServiceTicketTypeRepository();
        }

        public List<ServiceTicketTypeDto> GetAllServiceTicketType()
        {
            return _serviceTicketTypeRepository.GetAllServiceTicketType();
        }

        public ResModel AddServiceTicketType(ServiceTicketTypeDto serviceTicketTypeDto, UserDto operationUser)
        {
            return _serviceTicketTypeRepository.AddServiceTicketType(serviceTicketTypeDto, operationUser);
        }

        public ServiceTicketTypeDto GetOneServiceTicketType(Guid serviceTicketTypeId)
        {
            return _serviceTicketTypeRepository.GetOneServiceTicketType(serviceTicketTypeId);
        }

        public ResModel UpdateServiceTicketType(ServiceTicketTypeDto serviceTicketTypeDto, UserDto operationUser)
        {
            return _serviceTicketTypeRepository.UpdateServiceTicketType(serviceTicketTypeDto, operationUser);
        }

        public ResModel DeleteServiceTicketType(Guid serviceTicketTypeId)
        {
            return _serviceTicketTypeRepository.DeleteServiceTicketType(serviceTicketTypeId);
        }

        public List<ServiceTicketTypeDto> QueryServiceTicketType(string keyword)
        {
            return _serviceTicketTypeRepository.QueryServiceTicketType(keyword);
        }
    }
}
