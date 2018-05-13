using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using AMS.Model.dto;
using AMS.Model.poco;
using AMS.Model.Repositories.Interfaces;
using AMS.Model.ResponseModel;

namespace AMS.Model.Repositories.Implements
{
    public class ParameterControlRepository : IParameterControlRepository
    {
        public ResModel UpdateParameterControl(List<ParameterControlDto> parameterControlDtos, UserDto operationUser)
        {
            using (var db=new ModelContext())
            {
                var parameterControls = parameterControlDtos.Select(i => new ParameterControl()
                {
                    Id = i.Id,
                    ParameterName = i.ParameterName,
                    Value1 = i.Value1,
                    Value2 = i.Value2,
                    Value1Type1 = i.Value1Type1,
                    Value1Type2 = i.Value1Type2
                });
                try
                {
                    db.BulkUpdate(parameterControls);
                    db.BulkSaveChanges();
                    db.OperationLog.Add(new OperationLog()
                    {
                        Id = Guid.NewGuid(),
                        OperationUserId = operationUser.Id,
                        ModuleName = "系统设置-参数控制",
                        OperationDesc = $"操作人：【{operationUser.Name}】，功能：【系统参数控制】，操作时间：【{DateTime.Now:yyyy-MM-dd HH:mm:ss}】",
                        OperationTime = DateTime.Now,
                        IpAddress = ""
                    });
                    db.SaveChanges();
                }
                catch (Exception e)
                {
                    return new ResModel(){Msg = "更新参数控制失败",Success = false};
                }
                return new ResModel() { Msg = "更新参数控制成功", Success = true };
            }
        }

        public List<ParameterControlDto> GetAllParameterControls()
        {
            using (var db=new ModelContext())
            {
                var parameterControls = db.ParameterControl.Select(i => new ParameterControlDto()
                {
                    Id = i.Id,
                    ParameterName = i.ParameterName,
                    Value1 = i.Value1,
                    Value2 = i.Value2,
                    Value1Type1 = i.Value1Type1,
                    Value1Type2 = i.Value1Type2
                }).ToList();
                return parameterControls;
            }
        }
    }
}
