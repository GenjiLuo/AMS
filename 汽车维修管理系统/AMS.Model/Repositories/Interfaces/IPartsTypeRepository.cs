using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AMS.Model.dto;
using AMS.Model.ResponseModel;

namespace AMS.Model.Repositories.Interfaces
{
    public interface IPartsTypeRepository
    {
        List<PartsTypeDto> GetAllPartsType();
        PartsTypeDto GetOnePartsType(Guid partsTypeId);
        ResModel AddPartsType(PartsTypeDto partsTypeDto, UserDto operationUser);
        ResModel UpdatePartsType(PartsTypeDto partsTypeDto, UserDto operationUser);
        ResModel DeletePartsType(Guid partsTypeId);
        List<PartsTypeDto> QueryPartsType(string keyWord);
    }
}
