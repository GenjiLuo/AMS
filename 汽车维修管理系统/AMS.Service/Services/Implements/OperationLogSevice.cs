using System.Collections.Generic;
using AMS.Model.dto;
using AMS.Model.Repositories.Implements;
using AMS.Model.Repositories.Interfaces;
using AMS.Model.ResponseModel;
using AMS.Service.Services.Interfaces;

namespace AMS.Service.Services.Implements
{
    public class OperationLogService : IOperationLogService
    {
        private readonly IOperationLogRepository _operationLogRepository;

        public OperationLogService()
        {
            _operationLogRepository = new OperationLogRepository();
        }

        public List<OperationLogDto> GetAllOperationLog()
        {
            return _operationLogRepository.GetAllOperationLog();
        }

        public ResModel AddOperationLog(OperationLogDto operationLogDto, UserDto operationUser)
        {
            return _operationLogRepository.AddOperationLog(operationLogDto, operationUser);
        }

        public ResModel DeleteOperationLog()
        {
            return _operationLogRepository.DeleteOperationLog();
        }

        public List<OperationLogDto> QueryOperationLog(string keyword)
        {
            return _operationLogRepository.QueryOperationLog(keyword);
        }
    }
}
