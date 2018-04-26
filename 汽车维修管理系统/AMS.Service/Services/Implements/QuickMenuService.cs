using System.Collections.Generic;
using AMS.Model.dto;
using AMS.Model.Repositories.Implements;
using AMS.Model.Repositories.Interfaces;
using AMS.Model.ResponseModel;
using AMS.Service.Services.Interfaces;

namespace AMS.Service.Services.Implements
{
    public class QuickMenuService : IQuickMenuService
    {
        private readonly IQuickMenuRepository _quickMenuRepository;
        public QuickMenuService()
        {
            _quickMenuRepository=new QuickMenuRepository();
        }
        public List<UserQuickMenuDto> GetUserQuickMenu(UserDto userDto)
        {
            return _quickMenuRepository.GetUserQuickMenu(userDto);
        }

        public ResModel AddUserQuickMenu(List<UserQuickMenuDto> userQuickMenuDtos, UserDto userDto)
        {
            return _quickMenuRepository.AddUserQuickMenu(userQuickMenuDtos, userDto);
        }

        public ResModel DeleteUserQuickMenu(UserQuickMenuDto userQuickMenu)
        {
            return _quickMenuRepository.DeleteUserQuickMenu(userQuickMenu);
        }
    }
}
 