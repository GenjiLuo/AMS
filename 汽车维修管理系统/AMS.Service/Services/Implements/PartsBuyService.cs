using System;
using System.Collections.Generic;
using AMS.Model.dto;
using AMS.Model.Repositories.Implements;
using AMS.Model.Repositories.Interfaces;
using AMS.Model.ResponseModel;
using AMS.Service.Services.Interfaces;

namespace AMS.Service.Services.Implements
{
    public class PartsBuyService : IPartsBuyService
    {
        private readonly IPartsBuyRepository _partsBuyRepository;

        public PartsBuyService()
        {
            _partsBuyRepository=new PartsBuyRepository();
        }

        public List<PartsBuyDto> GetAllPartsBuy()
        {
            return _partsBuyRepository.GetAllPartsBuy();
        }

        public ResModel AddPartsBuy(PartsBuyDto partsBuyDto, UserDto operationUser)
        {
            return _partsBuyRepository.AddPartsBuy(partsBuyDto, operationUser);
        }

        public PartsBuyDto GetOnePartsBuy(Guid partsBuyId)
        {
            return _partsBuyRepository.GetOnePartsBuy(partsBuyId);
        }

        public ResModel UpdatePartsBuy(PartsBuyDto partsBuyDto, UserDto operationUser)
        {
            return _partsBuyRepository.UpdatePartsBuy(partsBuyDto, operationUser);
        }

        public ResModel DeletePartsBuy(Guid partsBuyId)
        {
            return _partsBuyRepository.DeletePartsBuy(partsBuyId);
        }

        public List<PartsBuyDto> QueryPartsBuy(string keyword)
        {
            return _partsBuyRepository.QueryPartsBuy(keyword);
        }

        public ResModel CheckPartsBuy(Guid partsBuyId, UserDto operationUser)
        {
            return _partsBuyRepository.CheckPartsBuy(partsBuyId, operationUser);
        }

        public ResModel UnCheckPartsBuy(Guid partsBuyId)
        {
            return _partsBuyRepository.UnCheckPartsBuy(partsBuyId);
        }

        public ResModel Pay(Guid partsBuyId, decimal money)
        {
            return _partsBuyRepository.Pay(partsBuyId,money);
        }
    }
}
