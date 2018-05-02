using System;
using System.Collections.Generic;
using AMS.Model.dto;
using AMS.Model.Repositories.Implements;
using AMS.Model.Repositories.Interfaces;
using AMS.Model.ResponseModel;
using AMS.Service.Services.Interfaces;

namespace AMS.Service.Services.Implements
{
    public class RepairItemTypeService : IRepairItemTypeService
    {
        private readonly IRepairItemTypeRepository _repairItemTypeRepository;

        public RepairItemTypeService()
        {
            _repairItemTypeRepository = new RepairItemTypeRepository();
        }
        public List<RepairItemTypeDto> GetAllRepairItemType()
        {
            return _repairItemTypeRepository.GetAllRepairItemType();
        }

        public ResModel AddRepairItemType(RepairItemTypeDto repairItemTypeDto, UserDto operationUser)
        {
            return _repairItemTypeRepository.AddRepairItemType(repairItemTypeDto, operationUser);
        }

        public RepairItemTypeDto GetOneRepairItemType(Guid repairItemTypeId)
        {
            return _repairItemTypeRepository.GetOneRepairItemType(repairItemTypeId);
        }

        public ResModel UpdateRepairItemType(RepairItemTypeDto repairItemTypeDto, UserDto operationUser)
        {
            return _repairItemTypeRepository.UpdateRepairItemType(repairItemTypeDto, operationUser);
        }

        public ResModel DeleteRepairItemType(Guid repairItemTypeId)
        {
            return _repairItemTypeRepository.DeleteRepairItemType(repairItemTypeId);
        }
    }
}
