using System;
using System.Collections.Generic;
using AMS.Model.dto;
using AMS.Model.Repositories.Implements;
using AMS.Model.Repositories.Interfaces;
using AMS.Model.ResponseModel;
using AMS.Service.Services.Interfaces;

namespace AMS.Service.Services.Implements
{
    public class RepairTypeService : IRepairTypeService
    {
        private readonly IRepairTypeRepository _repairTypeRepository;

        public RepairTypeService()
        {
            _repairTypeRepository = new RepairTypeRepository();
        }

        public List<RepairTypeDto> GetAllRepairType()
        {
            return _repairTypeRepository.GetAllRepairType();
        }

        public ResModel AddRepairType(RepairTypeDto repairTypeDto, UserDto operationUser)
        {
            return _repairTypeRepository.AddRepairType(repairTypeDto, operationUser);
        }

        public RepairTypeDto GetOneRepairType(Guid repairTypeId)
        {
            return _repairTypeRepository.GetOneRepairType(repairTypeId);
        }

        public ResModel UpdateRepairType(RepairTypeDto repairTypeDto, UserDto operationUser)
        {
            return _repairTypeRepository.UpdateRepairType(repairTypeDto, operationUser);
        }

        public ResModel DeleteRepairType(Guid repairTypeId)
        {
            return _repairTypeRepository.DeleteRepairType(repairTypeId);
        }
    }
}
