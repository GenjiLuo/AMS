using System;
using System.Collections.Generic;
using AMS.Model.dto;
using AMS.Model.Repositories.Implements;
using AMS.Model.Repositories.Interfaces;
using AMS.Model.ResponseModel;
using AMS.Service.Services.Interfaces;

namespace AMS.Service.Services.Implements
{
    public class WashItemService : IWashItemService
    {
        private readonly IWashItemRepository _washItemRepository;

        public WashItemService()
        {
            _washItemRepository=new WashItemRepository();
        }

        public List<WashItemDto> GetAllWashItem()
        {
            return _washItemRepository.GetAllWashItem();
        }

        public ResModel AddWashItem(WashItemDto washItemDto, UserDto operationUser)
        {
            return _washItemRepository.AddWashItem(washItemDto, operationUser);
        }

        public WashItemDto GetOneWashItem(Guid washItemId)
        {
            return _washItemRepository.GetOneWashItem(washItemId);
        }

        public ResModel UpdateWashItem(WashItemDto washItemDto, UserDto operationUser)
        {
            return _washItemRepository.UpdateWashItem(washItemDto, operationUser);
        }

        public ResModel DeleteWashItem(Guid washItemId)
        {
            return _washItemRepository.DeleteWashItem(washItemId);
        }

        public List<WashItemDto> QueryWashItem(string keyword)
        {
            return _washItemRepository.QueryWashItem(keyword);
        }
    }
}
