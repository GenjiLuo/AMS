using System.Collections.Generic;
using AMS.Model.dto;
using AMS.Model.Repositories.Implements;
using AMS.Model.Repositories.Interfaces;
using AMS.Model.ResponseModel;
using AMS.Service.Services.Interfaces;

namespace AMS.Service.Services.Implements
{
    public class BillNoSettingService : IBillNoSettingService
    {
        private readonly IBillNoSettingRepository _billNoSettingRepository;

        public BillNoSettingService()
        {
            _billNoSettingRepository=new BillNoSettingRepository();
        }

        public List<BillNoSettingDto> GetAllBillNoSetting()
        {
            return _billNoSettingRepository.GetAllBillNoSetting();
        }

        public ResModel UpdateBillNoSetting(List<BillNoSettingDto> billNoSettingDtos, UserDto operationUser)
        {
            return _billNoSettingRepository.UpdateBillNoSetting(billNoSettingDtos, operationUser);
        }
    }
}
