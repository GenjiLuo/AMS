using System;
using System.Collections.Generic;
using System.Linq;
using AMS.Model.dto;
using AMS.Model.poco;
using AMS.Model.Repositories.Interfaces;
using AMS.Model.ResponseModel;

namespace AMS.Model.Repositories.Implements
{
    public class OperationLogRepository : IOperationLogRepository
    {
        public List<OperationLogDto> GetAllOperationLog()
        {
            using (var db=new ModelContext())
            {
                var operationLogs = db.OperationLog.Select(i => new OperationLogDto()
                {
                    Id = i.Id,
                    OperatorName = i.OpertionUser.Name,
                    OperatorAccount = i.OpertionUser.Account,
                    ModuleName = i.ModuleName,
                    OperationDesc = i.OperationDesc,
                    OperationTime = i.OperationTime,
                    IpAddress = i.IpAddress
                }).ToList();
                return operationLogs;
            }
        }

        public ResModel AddOperationLog(OperationLogDto operationLogDto, UserDto operationUser)
        {
            using (var db=new ModelContext())
            {
                var operationLog = new OperationLog()
                {
                    Id = Guid.NewGuid(),
                    OperationUserId = operationUser.Id,
                    ModuleName = operationLogDto.ModuleName,
                    OperationDesc = operationLogDto.OperationDesc,
                    OperationTime = operationLogDto.OperationTime,
                    IpAddress = operationLogDto.IpAddress
                };
                try
                {
                    db.OperationLog.Add(operationLog);
                    db.SaveChanges();
                }
                catch (Exception e)
                {
                    return new ResModel(){Msg = "添加操作日志失败",Success = false};
                }
                return new ResModel() { Msg = "添加操作日志成功", Success = true };
            }
        }

        public ResModel DeleteOperationLog()
        {
            using (var db=new ModelContext())
            {
                var operationLogs = db.OperationLog.Select(i => new OperationLog());
                try
                {
                    db.BulkDelete(operationLogs);
                    db.SaveChanges();
                }
                catch (Exception e)
                {
                    return new ResModel(){Msg = "清空操作日志失败",Success = false};
                }
                return new ResModel() { Msg = "清空操作日志成功", Success = true };
            }
        }

        public List<OperationLogDto> QueryOperationLog(string keyword)
        {
            using (var db = new ModelContext())
            {
                var operationLogs = db.OperationLog.Where(i => i.OperationDesc.Contains(keyword)).Select(i => new OperationLogDto()
                {
                    Id = i.Id,
                    OperatorName = i.OpertionUser.Name,
                    OperatorAccount = i.OpertionUser.Account,
                    ModuleName = i.ModuleName,
                    OperationDesc = i.OperationDesc,
                    OperationTime = i.OperationTime,
                    IpAddress = i.IpAddress
                }).ToList();
                return operationLogs;
            }
        }
    }
}
