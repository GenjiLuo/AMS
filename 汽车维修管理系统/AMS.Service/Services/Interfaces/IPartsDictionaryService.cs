using System;
using System.Collections.Generic;
using AMS.Model.dto;
using AMS.Model.ResponseModel;

namespace AMS.Service.Services.Interfaces
{
    public interface IPartsDictionaryService
    {
        List<PartsDictionaryDto> GetAllPartsDictionary();
        PartsDictionaryDto GetOnePartsDictionary(Guid partsDictionaryId);
        ResModel AddPartsDictionary(PartsDictionaryDto partsDictionaryDto, UserDto operationUser);
        ResModel UpdatePartsDictionary(PartsDictionaryDto partsDictionaryDto, UserDto operationUser);
        ResModel DeletePartsDictionary(Guid partsDictionaryId);
        List<PartsDictionaryDto> QueryPartsDictionary(string keyWord);
        ResModel UpdatePartsAlertCount(PartsDictionaryDto partsDictionaryDto, UserDto operationUser);
    }
}
