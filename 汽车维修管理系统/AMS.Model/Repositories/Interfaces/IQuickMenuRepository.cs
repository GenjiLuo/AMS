using System.Collections.Generic;
using AMS.Model.dto;
using AMS.Model.ResponseModel;

namespace AMS.Model.Repositories.Interfaces
{
    public interface IQuickMenuRepository
    {
        List<UserQuickMenuDto> GetUserQuickMenu(UserDto userDto);
        ResModel AddUserQuickMenu(List<UserQuickMenuDto> userQuickMenuDtos, UserDto userDto);
    }
}
