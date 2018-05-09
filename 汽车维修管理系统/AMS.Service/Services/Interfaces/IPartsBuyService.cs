using System;
using System.Collections.Generic;
using AMS.Model.dto;
using AMS.Model.ResponseModel;

namespace AMS.Service.Services.Interfaces
{
    public interface IPartsBuyService
    {
        List<PartsBuyDto> GetAllPartsBuy();
        ResModel AddPartsBuy(PartsBuyDto partsBuyDto, UserDto operationUser);
        PartsBuyDto GetOnePartsBuy(Guid partsBuyId);
        ResModel UpdatePartsBuy(PartsBuyDto partsBuyDto, UserDto operationUser);
        ResModel DeletePartsBuy(Guid partsBuyId);
        List<PartsBuyDto> QueryPartsBuy(string keyword);
    }
}
