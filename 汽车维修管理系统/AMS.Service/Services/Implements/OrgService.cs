using System.Collections.Generic;
using AMS.Model.dto;
using AMS.Model.Repositories.Implements;
using AMS.Model.Repositories.Interfaces;
using AMS.Model.ResponseModel;
using AMS.Service.Services.Interfaces;

namespace AMS.Service.Services.Implements
{
    public class OrgService : IOrgService
    {
        private readonly IOrgRepository _orgRepository;

        public OrgService()
        {
            _orgRepository=new OrgRepository();
        }
        public ResModel UpdateOrgHope(OrgDto orgDto, UserDto userDto)
        {
            return _orgRepository.UpdateOrgHope(orgDto, userDto);
        }

        public ResModel GetOrgHope(OrgDto orgDto)
        {
            return _orgRepository.GetOrgHope(orgDto);
        }

        public List<OrgDto> GetOrganization()
        {
            return _orgRepository.GetOrganization();
        }

        public ResModel GetOneOrganization(OrgDto orgDto)
        {
            return _orgRepository.GetOneOrganization(orgDto);
        }

        public ResModel AddOrganization(OrgDto orgDto, UserDto userDto)
        {
            return _orgRepository.AddOrganization(orgDto, userDto);
        }

        public ResModel UpdateOrganization(OrgDto orgDto, UserDto userDto)
        {
            return _orgRepository.UpdateOrganization(orgDto, userDto);
        }

        public ResModel DeleteOrganization(OrgDto orgDto)
        {
            return _orgRepository.DeleteOrganization(orgDto);
        }

        public ResModel DisableOrganization(OrgDto orgDto, UserDto userDto)
        {
            return _orgRepository.DisableOrganization(orgDto, userDto);
        }

        public ResModel AcitveOrganization(OrgDto orgDto, UserDto userDto)
        {
            return _orgRepository.AcitveOrganization(orgDto, userDto);
        }
    }
}
