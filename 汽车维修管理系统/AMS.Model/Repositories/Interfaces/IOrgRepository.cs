using AMS.Model.dto;
using AMS.Model.ResponseModel;

namespace AMS.Model.Repositories.Interfaces
{
    public interface IOrgRepository
    {
        ResModel UpdateOrgHope(OrgDto orgDto,UserDto userDto);
        ResModel GetOrgHope(OrgDto orgDto);
    }
}
