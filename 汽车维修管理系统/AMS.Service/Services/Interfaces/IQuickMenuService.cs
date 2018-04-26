using System.Collections.Generic;
using AMS.Model.dto;
using AMS.Model.ResponseModel;

namespace AMS.Service.Services.Interfaces
{
    public interface IQuickMenuService
    {
        List<UserQuickMenuDto> GetUserQuickMenu(UserDto userDto);
        ResModel AddUserQuickMenu(List<UserQuickMenuDto> userQuickMenuDtos, UserDto userDto);
        ResModel DeleteUserQuickMenu(UserQuickMenuDto userQuickMenu);
    }
}
