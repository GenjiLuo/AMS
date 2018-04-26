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
    }
}
