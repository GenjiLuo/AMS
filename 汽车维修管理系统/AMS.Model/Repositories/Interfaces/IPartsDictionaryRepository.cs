using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AMS.Model.dto;
using AMS.Model.ResponseModel;

namespace AMS.Model.Repositories.Interfaces
{
    public interface IPartsDictionaryRepository
    {
        List<PartsDictionaryDto> GetAllPartsDictionary();
        PartsDictionaryDto GetOnePartsDictionary(Guid partsDictionaryId);
        ResModel AddPartsDictionary(PartsDictionaryDto partsDictionaryDto, UserDto operationUser);
        ResModel UpdatePartsDictionary(PartsDictionaryDto partsDictionaryDto, UserDto operationUser);
        ResModel DeletePartsDictionary(Guid partsDictionaryId);
        List<PartsDictionaryDto> QueryPartsDictionary(string keyWord);
    }
}
