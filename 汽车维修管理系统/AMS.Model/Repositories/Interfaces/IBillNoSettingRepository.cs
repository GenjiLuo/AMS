using System;
using System.Collections.Generic;
using AMS.Model.dto;
using AMS.Model.poco;
using AMS.Model.ResponseModel;

namespace AMS.Model.Repositories.Interfaces
{
    public interface IBillNoSettingRepository
    {
        List<BillNoSettingDto> GetAllBillNoSetting();
        ResModel UpdateBillNoSetting(List<BillNoSettingDto> billNoSettingDtos, UserDto operationUser);
    }
}
