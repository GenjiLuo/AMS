using System;
using System.Collections.Generic;
using AMS.Model.dto;
using AMS.Model.Repositories.Implements;
using AMS.Model.Repositories.Interfaces;
using AMS.Model.ResponseModel;
using AMS.Service.Services.Interfaces;

namespace AMS.Service.Services.Implements
{
    public class ServiceAccountTypeService : IServiceAccountTypeService
    {
        private readonly IServiceAccountTypeRepository _serviceAccountTypeRepository;

        public ServiceAccountTypeService()
        {
            _serviceAccountTypeRepository=new ServiceAccountTypeRepository();
        }

        public List<ServiceAccountTypeDto> GetAllServiceAccountType()
        {
            return _serviceAccountTypeRepository.GetAllServiceAccountType();
        }

        public ResModel AddServiceAccountType(ServiceAccountTypeDto serviceAccountTypeDto, UserDto operationUser)
        {
            return _serviceAccountTypeRepository.AddServiceAccountType(serviceAccountTypeDto, operationUser);
        }

        public ServiceAccountTypeDto GetOneServiceAccountType(Guid serviceAccountTypeId)
        {
            return _serviceAccountTypeRepository.GetOneServiceAccountType(serviceAccountTypeId);
        }

        public ResModel UpdateServiceAccountType(ServiceAccountTypeDto serviceAccountTypeDto, UserDto operationUser)
        {
            return _serviceAccountTypeRepository.UpdateServiceAccountType(serviceAccountTypeDto, operationUser);
        }

        public ResModel DeleteServiceAccountType(Guid serviceAccountTypeId)
        {
            return _serviceAccountTypeRepository.DeleteServiceAccountType(serviceAccountTypeId);
        }

        public List<ServiceAccountTypeDto> QueryServiceAccountType(string keyword)
        {
            return _serviceAccountTypeRepository.QueryServiceAccountType(keyword);
        }
    }
}
