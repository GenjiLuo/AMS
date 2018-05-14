using System;
using System.Collections.Generic;
using AMS.Model.dto;
using AMS.Model.Repositories.Implements;
using AMS.Model.Repositories.Interfaces;
using AMS.Model.ResponseModel;
using AMS.Service.Services.Interfaces;

namespace AMS.Service.Services.Implements
{
    public class PartsReturnService : IPartsReturnService
    {
        private readonly IPartsReturnRepository _partsReturnRepository;

        public PartsReturnService()
        {
            _partsReturnRepository=new PartsReturnRepository();
        }

        public List<PartsReturnDto> GetAllPartsReturn()
        {
            return _partsReturnRepository.GetAllPartsReturn();
        }

        public ResModel AddPartsReturn(PartsReturnDto partsReturnDto, UserDto operationUser)
        {
            return _partsReturnRepository.AddPartsReturn(partsReturnDto, operationUser);
        }

        public PartsReturnDto GetOnePartsReturn(Guid partsReturnId)
        {
            return _partsReturnRepository.GetOnePartsReturn(partsReturnId);
        }

        public ResModel UpdatePartsReturn(PartsReturnDto partsReturnDto, UserDto operationUser)
        {
            return _partsReturnRepository.UpdatePartsReturn(partsReturnDto, operationUser);
        }

        public ResModel DeletePartsReturn(Guid partsReturnId)
        {
            return _partsReturnRepository.DeletePartsReturn(partsReturnId);
        }

        public List<PartsReturnDto> QueryPartsReturn(string keyword)
        {
            return _partsReturnRepository.QueryPartsReturn(keyword);
        }

        public ResModel Check(Guid partsReturnId, UserDto operationUser)
        {
            return _partsReturnRepository.Check(partsReturnId,operationUser);
        }
    }
}
