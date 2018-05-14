using System;
using System.Collections.Generic;
using AMS.Model.dto;
using AMS.Model.poco;
using AMS.Model.ResponseModel;

namespace AMS.Model.Repositories.Interfaces
{
    public interface IPartsReturnRepository
    {
        List<PartsReturnDto> GetAllPartsReturn();
        ResModel AddPartsReturn(PartsReturnDto partsReturnDto, UserDto operationUser);
        PartsReturnDto GetOnePartsReturn(Guid partsReturnId);
        ResModel UpdatePartsReturn(PartsReturnDto partsReturnDto, UserDto operationUser);
        ResModel DeletePartsReturn(Guid partsReturnId);
        List<PartsReturnDto> QueryPartsReturn(string keyword);
        ResModel Check(Guid partsReturnId, UserDto operationUser);
    }
}
