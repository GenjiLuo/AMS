using System;
using System.Collections.Generic;
using AMS.Model.dto;
using AMS.Model.poco;
using AMS.Model.ResponseModel;

namespace AMS.Model.Repositories.Interfaces
{
    public interface IWashItemRepository
    {
        List<WashItemDto> GetAllWashItem();
        ResModel AddWashItem(WashItemDto washItemDto, UserDto operationUser);
        WashItemDto GetOneWashItem(Guid washItemId);
        ResModel UpdateWashItem(WashItemDto washItemDto, UserDto operationUser);
        ResModel DeleteWashItem(Guid washItemId);
        List<WashItemDto> QueryWashItem(string keyword);
    }
}
