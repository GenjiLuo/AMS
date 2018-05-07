using System;
using System.Collections.Generic;
using AMS.Model.dto;
using AMS.Model.ResponseModel;

namespace AMS.Service.Services.Interfaces
{
    public interface IPartsTypeService
    {
        List<PartsTypeDto> GetAllPartsType();
        PartsTypeDto GetOnePartsType(Guid partsTypeId);
        ResModel AddPartsType(PartsTypeDto partsTypeDto, UserDto operationUser);
        ResModel UpdatePartsType(PartsTypeDto partsTypeDto, UserDto operationUser);
        ResModel DeletePartsType(Guid partsTypeId);
        List<PartsTypeDto> QueryPartsType(string keyWord);
    }
}
