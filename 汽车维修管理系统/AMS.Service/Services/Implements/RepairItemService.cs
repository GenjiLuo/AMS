using System;
using System.Collections.Generic;
using AMS.Model.dto;
using AMS.Model.Repositories.Implements;
using AMS.Model.Repositories.Interfaces;
using AMS.Model.ResponseModel;
using AMS.Service.Services.Interfaces;

namespace AMS.Service.Services.Implements
{
    public class RepairItemService : IRepairItemService
    {
        private readonly IRepairItemRepository _repairItemRepository;

        public RepairItemService()
        {
            _repairItemRepository=new RepairItemRepository();
        }
        public List<RepairItemDto> GetAllRepairItem()
        {
            return _repairItemRepository.GetAllRepairItem();
        }

        public ResModel AddRepairItem(RepairItemDto repairItemDto, UserDto operationUser)
        {
            return _repairItemRepository.AddRepairItem(repairItemDto, operationUser);
        }

        public RepairItemDto GetOneRepairItem(Guid repairItemId)
        {
            return _repairItemRepository.GetOneRepairItem(repairItemId);
        }

        public ResModel UpdateRepairItem(RepairItemDto repairItemDto, UserDto operationUser)
        {
            return _repairItemRepository.UpdateRepairItem(repairItemDto, operationUser);
        }

        public ResModel DeleteRepairItem(Guid repairItemId)
        {
            return _repairItemRepository.DeleteRepairItem(repairItemId);
        }
    }
}
