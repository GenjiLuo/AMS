using System;
using System.Collections.Generic;
using System.Data.Entity.Migrations;
using System.Linq;
using AMS.Model.dto;
using AMS.Model.poco;
using AMS.Model.Repositories.Interfaces;
using AMS.Model.ResponseModel;

namespace AMS.Model.Repositories.Implements
{
    public class BillNoSettingRepository : IBillNoSettingRepository
    {
        public List<BillNoSettingDto> GetAllBillNoSetting()
        {
            using (var db=new ModelContext())
            {
                var billNoSettings = db.BillNoSetting.Select(i => new BillNoSettingDto()
                {
                    Id = i.Id,
                    Name = i.Name,
                    Prefix = i.Prefix,
                    DateFormat = i.DateFormat,
                    SerNoLength = i.SerNoLength,
                    DailyReset = i.DailyReset,
                    BillNoPreview = i.BillNoPreview
                }).ToList();
                return billNoSettings;
            }
        }

        public ResModel UpdateBillNoSetting(List<BillNoSettingDto> billNoSettingDtos, UserDto operationUser)
        {
            using (var db=new ModelContext())
            {
                var billNoSettings = billNoSettingDtos.Select(i => new BillNoSetting()
                {
                    Id = i.Id,
                    Name = i.Name,
                    Prefix = i.Prefix,
                    DateFormat = i.DateFormat,
                    SerNoLength = i.SerNoLength,
                    DailyReset = i.DailyReset,
                    BillNoPreview = i.BillNoPreview
                });
                try
                {
                    db.BulkUpdate(billNoSettings);
                    db.SaveChanges();
                }
                catch (Exception e)
                {
                    return new ResModel() { Msg = "修改失败", Success = false };
                }
                return new ResModel(){Msg = "修改成功",Success = true};
            }
        }
    }
}
