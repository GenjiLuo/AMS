using System;
using System.Collections.Generic;
using AMS.Model.dto;
using AMS.Model.poco;
using AMS.Model.ResponseModel;

namespace AMS.Model.Repositories.Interfaces
{
    public interface IServiceAccountTypeRepository
    {
        List<ServiceAccountTypeDto> GetAllServiceAccountType();
        ResModel AddServiceAccountType(ServiceAccountTypeDto serviceAccountTypeDto, UserDto operationUser);
        ServiceAccountTypeDto GetOneServiceAccountType(Guid serviceAccountTypeId);
        ResModel UpdateServiceAccountType(ServiceAccountTypeDto serviceAccountTypeDto, UserDto operationUser);
        ResModel DeleteServiceAccountType(Guid serviceAccountTypeId);
        List<ServiceAccountTypeDto> QueryServiceAccountType(string keyword);
    }
}
