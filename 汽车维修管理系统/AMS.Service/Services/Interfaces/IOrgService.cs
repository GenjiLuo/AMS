using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AMS.Model.dto;
using AMS.Model.ResponseModel;

namespace AMS.Service.Services.Interfaces
{
    public interface IOrgService
    {
        ResModel UpdateOrgHope(OrgDto orgDto, UserDto userDto);
        ResModel GetOrgHope(OrgDto orgDto);
        List<OrgDto> GetOrganization();
        ResModel AddOrganization(OrgDto orgDto, UserDto userDto);
        ResModel UpdateOranization(OrgDto orgDto, UserDto userDto);
        ResModel DeleteOranization(OrgDto orgDto, UserDto userDto);
    }
}
