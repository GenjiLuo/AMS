using System;
using System.Collections.Generic;
using AMS.Model.dto;
using AMS.Model.Repositories.Implements;
using AMS.Model.Repositories.Interfaces;
using AMS.Model.ResponseModel;
using AMS.Service.Services.Interfaces;

namespace AMS.Service.Services.Implements
{
    public class PartsTypeService : IPartsTypeService
    {
        private readonly IPartsTypeRepository _partsTypeRepository;

        public PartsTypeService()
        {
            _partsTypeRepository=new PartsTypeRepository();
        }
        public List<PartsTypeDto> GetAllPartsType()
        {
            return _partsTypeRepository.GetAllPartsType();
        }

        public PartsTypeDto GetOnePartsType(Guid partsTypeId)
        {
            return _partsTypeRepository.GetOnePartsType(partsTypeId);
        }

        public ResModel AddPartsType(PartsTypeDto partsTypeDto, UserDto operationUser)
        {
            return _partsTypeRepository.AddPartsType(partsTypeDto, operationUser);
        }

        public ResModel UpdatePartsType(PartsTypeDto partsTypeDto, UserDto operationUser)
        {
            return _partsTypeRepository.UpdatePartsType(partsTypeDto, operationUser);
        }

        public ResModel DeletePartsType(Guid partsTypeId)
        {
            return _partsTypeRepository.DeletePartsType(partsTypeId);
        }

        public List<PartsTypeDto> QueryPartsType(string keyWord)
        {
            return _partsTypeRepository.QueryPartsType(keyWord);
        }
    }
}
