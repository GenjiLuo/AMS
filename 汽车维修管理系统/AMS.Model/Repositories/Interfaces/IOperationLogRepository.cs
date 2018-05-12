using System;
using System.Collections.Generic;
using AMS.Model.dto;
using AMS.Model.poco;
using AMS.Model.ResponseModel;

namespace AMS.Model.Repositories.Interfaces
{
    public interface IOperationLogRepository
    {
        List<OperationLogDto> GetAllOperationLog();
        ResModel AddOperationLog(OperationLogDto operationLogDto, UserDto operationUser);
        ResModel DeleteOperationLog();
        List<OperationLogDto> QueryOperationLog(string keyword);
    }
}
