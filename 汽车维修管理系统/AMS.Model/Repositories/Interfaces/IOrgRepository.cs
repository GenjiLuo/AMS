using System.Collections.Generic;
using AMS.Model.dto;
using AMS.Model.ResponseModel;

namespace AMS.Model.Repositories.Interfaces
{
    public interface IOrgRepository
    {
        ResModel UpdateOrgHope(OrgDto orgDto,UserDto userDto);
        ResModel GetOrgHope(OrgDto orgDto);

        List<OrgDto> GetOrganization();
        ResModel GetOneOrganization(OrgDto orgDto);
        ResModel AddOrganization(OrgDto orgDto, UserDto userDto);
        ResModel UpdateOrganization(OrgDto orgDto, UserDto userDto);
        ResModel DeleteOrganization(OrgDto orgDto);
        ResModel DisableOrganization(OrgDto orgDto, UserDto userDto);
        ResModel AcitveOrganization(OrgDto orgDto, UserDto userDto);
    }
}
