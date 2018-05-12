using System.Collections.Generic;
using AMS.Model.dto;
using AMS.Model.ResponseModel;

namespace AMS.Service.Services.Interfaces
{
    public interface IOperationLogService
    {
        List<OperationLogDto> GetAllOperationLog();
        ResModel AddOperationLog(OperationLogDto operationLogDto, UserDto operationUser);
        ResModel DeleteOperationLog();
        List<OperationLogDto> QueryOperationLog(string keyword);
    }
}
