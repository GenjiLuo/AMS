using System;
using System.Collections.Generic;
using AMS.Model.dto;
using AMS.Model.Repositories.Implements;
using AMS.Model.Repositories.Interfaces;
using AMS.Model.ResponseModel;
using AMS.Service.Services.Interfaces;

namespace AMS.Service.Services.Implements
{
    public class PartsDictionaryService : IPartsDictionaryService
    {
        private readonly IPartsDictionaryRepository _partsDictionaryRepository;

        public PartsDictionaryService()
        {
            _partsDictionaryRepository=new PartsDictionaryRepository();
        }

        public List<PartsDictionaryDto> GetAllPartsDictionary()
        {
            return _partsDictionaryRepository.GetAllPartsDictionary();
        }

        public PartsDictionaryDto GetOnePartsDictionary(Guid partsDictionaryId)
        {
            return _partsDictionaryRepository.GetOnePartsDictionary(partsDictionaryId);
        }

        public ResModel AddPartsDictionary(PartsDictionaryDto partsDictionaryDto, UserDto operationUser)
        {
            return _partsDictionaryRepository.AddPartsDictionary(partsDictionaryDto, operationUser);
        }

        public ResModel UpdatePartsDictionary(PartsDictionaryDto partsDictionaryDto, UserDto operationUser)
        {
            return _partsDictionaryRepository.UpdatePartsDictionary(partsDictionaryDto, operationUser);
        }

        public ResModel DeletePartsDictionary(Guid partsDictionaryId)
        {
            return _partsDictionaryRepository.DeletePartsDictionary(partsDictionaryId);
        }

        public List<PartsDictionaryDto> QueryPartsDictionary(string keyWord)
        {
            return _partsDictionaryRepository.QueryPartsDictionary(keyWord);
        }
    }
}
