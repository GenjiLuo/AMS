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
        ResModel AddOrganization(OrgDto orgDto, UserDto userDto);
        ResModel UpdateOranization(OrgDto orgDto, UserDto userDto);
        ResModel DeleteOranization(OrgDto orgDto, UserDto userDto);

    }
}
