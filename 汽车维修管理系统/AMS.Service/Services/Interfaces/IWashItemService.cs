using System;
using System.Collections.Generic;
using AMS.Model.dto;
using AMS.Model.ResponseModel;

namespace AMS.Service.Services.Interfaces
{
    public interface IWashItemService
    {
        List<WashItemDto> GetAllWashItem();
        ResModel AddWashItem(WashItemDto washItemDto, UserDto operationUser);
        WashItemDto GetOneWashItem(Guid washItemId);
        ResModel UpdateWashItem(WashItemDto washItemDto, UserDto operationUser);
        ResModel DeleteWashItem(Guid washItemId);
        List<WashItemDto> QueryWashItem(string keyword);
    }
}
