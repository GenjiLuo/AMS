using System;
using System.Collections.Generic;
using AMS.Model.dto;
using AMS.Model.poco;
using AMS.Model.ResponseModel;

namespace AMS.Model.Repositories.Interfaces
{
    public interface IPartsBuyRepository
    {
        List<PartsBuyDto> GetAllPartsBuy();
        ResModel AddPartsBuy(PartsBuyDto partsBuyDto, UserDto operationUser);
        PartsBuyDto GetOnePartsBuy(Guid partsBuyId);
        ResModel UpdatePartsBuy(PartsBuyDto partsBuyDto, UserDto operationUser);
        ResModel DeletePartsBuy(Guid partsBuyId);
        List<PartsBuyDto> QueryPartsBuy(string keyword);
        ResModel CheckPartsBuy(Guid partsBuyId, UserDto operationUser);
        ResModel UnCheckPartsBuy(Guid partsBuyId);
        ResModel Pay(Guid partsBuyId, decimal money);
    }
}
