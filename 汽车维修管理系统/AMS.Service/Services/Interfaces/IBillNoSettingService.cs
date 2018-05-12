using System.Collections.Generic;
using AMS.Model.dto;
using AMS.Model.ResponseModel;

namespace AMS.Service.Services.Interfaces
{
    public interface IBillNoSettingService
    {
        List<BillNoSettingDto> GetAllBillNoSetting();
        ResModel UpdateBillNoSetting(List<BillNoSettingDto> billNoSettingDtos, UserDto operationUser);
    }
}
